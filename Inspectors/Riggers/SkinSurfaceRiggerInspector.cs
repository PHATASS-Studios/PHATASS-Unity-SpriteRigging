using UnityEngine;
using UnityEngine.U2D.Animation;

namespace PHATASS.SpriteRigging.Inspectors
{
	[RequireComponent(typeof(SpriteRenderer))]
	[RequireComponent(typeof(SpriteSkin))]
	public class SkinSurfaceRiggerInspector : RigidbodyRiggerInspectorBase
	{
		//Sample inter-vertex joint configuration
		[SerializeField]
		private ConfigurableJoint _defaultMeshJoint;
		public ConfigurableJoint defaultMeshJoint { get { return this._defaultMeshJoint; }}
	}
}