using UnityEngine;

using static PHATASS.Utils.Extensions.TransformExtensions;
using static PHATASS.Utils.Extensions.JointConfigurationExtensions; //ConfigurableJoint extension methods
using static PHATASS.Utils.Extensions.TransformJointRiggingExtensions;

using IJointChainRiggerInspector = PHATASS.SpriteRigging.Inspectors.IJointChainRiggerInspector;

namespace PHATASS.SpriteRigging.Editors
{
//rigs a chain of bones with required components
	public abstract class TailRiggerEditorJointChainBase<TInspector>
	:
		TailRiggerEditorBase<TInspector>
		where TInspector : UnityEngine.Object, IJointChainRiggerInspector
	{
	//abstract method implementation
		//rig the base/root of the transform chain
		protected override void RigTailRoot (Transform rootBone)
		{ this.BoneCreateAnchor(rootBone); }

		//rig an individual element of the transform chain
		protected override void RigTailBone (Transform bone)
		{
			bone.ESetTagAndLayer(this.targetInspector.defaultTag, this.targetInspector.defaultLayer);
			bone.ESetupComponent<Rigidbody>(this.targetInspector.defaultRigidbody);

			//[TO-DO] MAYBE make a generic version that accepts any kind of collider? it would require manually checking collider type as generic methods types can only be created at compilation time, OR using reflection
			if (this.targetInspector.defaultCollider != null)
			{ bone.ESetupComponent<SphereCollider>(this.targetInspector.defaultCollider); }
		}

		//rig a connection between two elements
		protected override ConfigurableJoint RigTailBonePairConnection (Transform bone, Transform nextBone)
		{
			Debug.Log("TailRiggerEditorJointChainBase.RigTailBonePairConnection();");
			//create a joint and initialize its anchors as a chain setup then return the joint
			return bone
				.ESetupJointConnectingTo<ConfigurableJoint>(nextBone, this.targetInspector.defaultChainJoint)
				.ESetAnchorAsChain();
		}
	//ENDOF abstract method implementation

	//virtual method overrides
		protected override void BoneCreateAnchor (Transform bone)
		{
			if (this.targetInspector.defaultAnchorJoint == null) { return; }
			base.BoneCreateAnchor(bone);
			if (this.targetInspector.additionalAnchorTransforms == null) { return; }
			foreach (Transform additionalAnchor in this.targetInspector.additionalAnchorTransforms)
			{ bone.ESetupJointConnectingTo(additionalAnchor, targetInspector.defaultAnchorJoint); }
		}
	//ENDOF virtual method overrides
	}
}