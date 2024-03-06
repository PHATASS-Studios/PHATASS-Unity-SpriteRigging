using UnityEngine;
//using SpriteRenderer = UnityEngine.U2D.Animation.SpriteRenderer;
using SpriteSkin = UnityEngine.U2D.Animation.SpriteSkin;

namespace PHATASS.SpriteRigging.Inspectors
{
	[RequireComponent(typeof(SpriteSkin))]
	public abstract class RigidbodyRiggerInspectorBase
	:
		RiggerInspectorBase,
		IRigidbodyRiggerInspector
	{
		//anchor rigidbody: every bone will be connected to this rigidbody with an anchor joint 
		[SerializeField]
		private Transform _anchorTransform = null;
		public Transform anchorTransform { get { return this._anchorTransform; }}
		
		//Sample anchor joint configuration
		[SerializeField]
		private ConfigurableJoint _defaultAnchorJoint = null;
		public ConfigurableJoint defaultAnchorJoint { get { return _defaultAnchorJoint; }}

		//Desired rigidbody configuration
		[SerializeField]
		private Rigidbody _defaultRigidbody = null;
		public Rigidbody defaultRigidbody { get { return _defaultRigidbody; }}

		//Collider to include with each bone
		[SerializeField]
		private SphereCollider _defaultCollider = null;
		public SphereCollider defaultCollider { get { return _defaultCollider; }}
	}
}