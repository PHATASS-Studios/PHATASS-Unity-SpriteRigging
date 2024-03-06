using static PHATASS.Utils.Extensions.ComponentExtensions;
using static PHATASS.Utils.Extensions.TransformExtensions;
using static U2DAnimationAccessor.SpriteSkinAccessor;

using CustomEditorAttribute = UnityEditor.CustomEditor;

using Debug = UnityEngine.Debug;

using Transform = UnityEngine.Transform;
using SpriteSkin = UnityEngine.U2D.Animation.SpriteSkin;

using BoneHierarchy = PHATASS.SpriteRigging.BoneUtility.BoneHierarchy;

using SpriteSkinToSpriteSkinLinkerInspector = PHATASS.SpriteRigging.Inspectors.SpriteSkinToSpriteSkinLinkerInspector;

namespace PHATASS.SpriteRigging.Editors
{
	[CustomEditor(typeof(SpriteSkinToSpriteSkinLinkerInspector))]
	public class SpriteSkinToSpriteSkinLinkerEditor : LinkerEditorBase<SpriteSkinToSpriteSkinLinkerInspector>
	{
	//inherited method overrides
		protected override void InitiateLinking ()
		{
			if (this.targetInspector.linkedSpriteSkin == null) { Debug.Log("HOLA DEA"); }

			//ensure base bone structure exists
			BoneHierarchy.CreateBoneHierarchy(this.targetInspector.managedSpriteSkin);

			//iterate over every bone in managed SpriteSkin replacing it with desired bone in linked spriteskin
			for (int i = 0, iLimit = this.targetInspector.managedSpriteSkin.boneTransforms.Length; i < iLimit; i++)
			{
				this.targetInspector.managedSpriteSkin.boneTransforms[i]
					= this.targetInspector.linkedSpriteSkin.boneTransforms.EFindClosestComponent<Transform>(
						this.targetInspector.managedSpriteSkin.boneTransforms[i].position);
			}

			//after bone list is replaced, replace root bone
			this.targetInspector.managedSpriteSkin.ESetRootBone(
				this.targetInspector.linkedSpriteSkin.boneTransforms.EFindClosestComponent<Transform>(
					this.targetInspector.managedSpriteSkin.rootBone.position
			));

			//finally remove this transform's children as they are UNWORTHY
			if (this.targetInspector.deleteChildTransforms)
			{
				this.targetInspector.transform.EDestroyImmediateAllChildren();
			}
		}
	//inherited method overrides
	}
}
