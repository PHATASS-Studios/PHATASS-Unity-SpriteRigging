using UnityEngine;
using UnityEditor;

using static PHATASS.Utils.Extensions.TransformJointRiggingExtensions;

using IRigidbodyRiggerInspector = PHATASS.SpriteRigging.Inspectors.IRigidbodyRiggerInspector;

namespace PHATASS.SpriteRigging.Editors
{
	public abstract class RigidbodyRiggerEditorBase<TInspector>
	:
		RiggerEditorBase<TInspector>
		where TInspector : UnityEngine.Object, IRigidbodyRiggerInspector
	{
	//overridable methods and properties
		protected virtual void BoneCreateAnchor (Transform bone)
		{
			if (this.targetInspector.defaultAnchorJoint != null)
			{ bone.ESetupJointConnectingTo(targetInspector.anchorTransform, targetInspector.defaultAnchorJoint); }
		}
	//ENDOF overridable methods
	}
}