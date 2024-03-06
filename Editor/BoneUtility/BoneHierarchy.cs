using UnityEngine;
using UnityEditor;

using UnityEngine.U2D.Animation; //SpriteSkin
using U2DAnimationAccessor;	//SpriteSkin.

using IRiggerInspector = PHATASS.SpriteRigging.Inspectors.IRiggerInspector;

namespace PHATASS.SpriteRigging.BoneUtility
{
	public static class BoneHierarchy
	{
		//creates gameobjects for every bone and stores them in spriteskin
		public static void CreateBoneHierarchy (SpriteSkin spriteSkin)
		{
			if (spriteSkin.rootBone != null)
			{
				Debug.LogWarning("SpriteSkin root bone pre-existing, aborting bone hierarchy initialization @" + spriteSkin.gameObject.name);
				return;
			}

			Undo.RegisterCompleteObjectUndo(spriteSkin, "Create Bones");

			//call accessor-exposed CreateBoneHierarchy method on the sprite skin
			//this is what creates the transform structure
			spriteSkin.ECreateBoneHierarchy();

			foreach (Transform transform in spriteSkin.boneTransforms) 
			{
				Undo.RegisterCreatedObjectUndo(transform.gameObject, "Create Bones");
			}

			//reset bounds if needed
			spriteSkin.ECalculateBoundsIfNecessary();
			EditorUtility.SetDirty(spriteSkin);
		}
	}
}