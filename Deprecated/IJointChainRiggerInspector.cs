using UnityEngine;

namespace PHATASS.SpriteRigging.Inspectors
{
	public interface IJointChainRiggerInspector : IRigidbodyRiggerInspector
	{
		//list of root anchor targets
		Transform[] additionalAnchorTransforms {get;}

		//Sample chain spring configuration
		ConfigurableJoint defaultChainJoint {get;}
	}
}