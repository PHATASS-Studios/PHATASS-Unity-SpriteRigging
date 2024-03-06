using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;

using static UnityEngine.U2D.SpriteDataAccessExtensions; //Sprite.GetIndices();

using static PHATASS.Utils.Extensions.TransformExtensions;
//using static PHATASS.Utils.Extensions.TransformJointRiggingExtensions;

//using Unity.Collections;	//nativeArray<T>

using ArticulationBodyRiggerInspector = PHATASS.SpriteRigging.Inspectors.ArticulationBodyRiggerInspector;

namespace PHATASS.SpriteRigging.Editors
{
	[CustomEditor(typeof(ArticulationBodyRiggerInspector))]
	public class ArticulationBodyRiggerEditor : ArticulationBodyRiggerEditorBase<ArticulationBodyRiggerInspector>
	{
	//inherited abstract method implementation
		protected override void RigBones ()
		{
			Debug.Log("Rigging bone components for " + this.targetInspector.name);

			ArticulationBody rootArticulationBody = UnityEngine.Object.Instantiate(this.targetInspector.rootArticulationBodySample);
			ArticulationBody childArticulationBody = UnityEngine.Object.Instantiate(this.targetInspector.childArticulationBodySample, rootArticulationBody.transform);

			ArticulationBody articulationBody;
			SphereCollider collider;

			foreach (Transform bone in this.targetInspector.spriteSkin.boneTransforms)
			{
				articulationBody = childArticulationBody;
				collider = this.targetInspector.defaultColliderSample;

				//change configuration for root component
				if (bone == this.targetInspector.spriteSkin.rootBone)
				{
					if (this.targetInspector.rootArticulationBodySample != null)
					{ articulationBody = rootArticulationBody; }
					if (!this.targetInspector.rootHasCollider)
					{ collider = null; }
				}

				this.RigBone(bone, articulationBody, collider);
			}

			Debug.Log("Rigged bones of " + targetInspector.name);

			UnityEngine.Object.DestroyImmediate(rootArticulationBody.gameObject);
		}
	//ENDOF inherited abstract method implementation

	//private methods
		private void RigBone <TCollider> (Transform bone, ArticulationBody articulationBody, TCollider collider)
			where TCollider : UnityEngine.Collider
		{
			bone.ESetTagAndLayer(
				targetTag: this.targetInspector.defaultTag,
				targetLayer: this.targetInspector.defaultLayer
			);

			bone.ESetupComponent<ArticulationBody>(articulationBody);

			if (collider != null)
			{ bone.ESetupComponent<TCollider>(collider); }
		}
	//ENDOF private methods
	}
}