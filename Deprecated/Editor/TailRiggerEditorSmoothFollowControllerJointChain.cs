using UnityEngine;
using UnityEditor;

using static PHATASS.Utils.Extensions.TransformExtensions;

using TInspector = PHATASS.SpriteRigging.Inspectors.TailRiggerInspectorSmoothFollowControllerJointChain;

using TElementController = PHATASS.TailSystem.TailElementJointSmoothFollow;

namespace PHATASS.SpriteRigging.Editors
{
//rigs a chain of bones with required components
	[CustomEditor(typeof(TInspector))]
	public class TailRiggerEditorSmoothFollowControllerJointChain
		: TailRiggerEditorJointChainBase<TInspector>
	{
	//overrides
		//rig an individual element of the transform chain
		protected override void RigTailBone (Transform bone)
		{
			base.RigTailBone(bone);
			//after rigging physics components create a chain element controller unless this is the last element in chain
			if (bone.childCount > 0)
			{
				bone.ESetupComponent<TElementController>(this.targetInspector.defaultTailElementController);
			}
		}

		//rig a connection between two elements. also store the joint in the controller
		protected override ConfigurableJoint RigTailBonePairConnection (Transform bone, Transform nextBone)
		{
			ConfigurableJoint connectionJoint = base.RigTailBonePairConnection(bone, nextBone);
			TElementController elementController = bone.GetComponent<TElementController>();
			if (elementController != null) { elementController.joint = connectionJoint; }
			return connectionJoint;
		}
	//ENDOF overrides
	}
}