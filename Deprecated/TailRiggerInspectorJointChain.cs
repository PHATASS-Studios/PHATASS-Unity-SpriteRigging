using UnityEngine;

namespace PHATASS.SpriteRigging.Inspectors
{
	[RequireComponent(typeof(UnityEngine.U2D.Animation.SpriteSkin))]
	public abstract class TailRiggerInspectorJointChain
	:
		RigidbodyRiggerInspectorBase,
		IJointChainRiggerInspector
	{
		//list of additional root anchor targets
		[SerializeField]
		private Transform[] _additionalAnchorTransforms = {};
		public Transform[] additionalAnchorTransforms { get { return _additionalAnchorTransforms; }}


		//Sample chain spring configuration
		[SerializeField]
		private ConfigurableJoint _defaultChainJoint = null;
		public ConfigurableJoint defaultChainJoint { get { return _defaultChainJoint; }}
	}
}