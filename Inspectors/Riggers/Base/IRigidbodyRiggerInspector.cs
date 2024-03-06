using UnityEngine;

namespace PHATASS.SpriteRigging.Inspectors
{
	public interface IRigidbodyRiggerInspector : IRiggerInspector
	{
		//anchor information: bone will be connected to this transform with sample joint as their anchor joint
		Transform anchorTransform { get; }
		ConfigurableJoint defaultAnchorJoint { get; }

		//Desired rigidbody configuration
		Rigidbody defaultRigidbody { get; }

		//Collider to include with each bone
		SphereCollider defaultCollider { get; }
	}
}