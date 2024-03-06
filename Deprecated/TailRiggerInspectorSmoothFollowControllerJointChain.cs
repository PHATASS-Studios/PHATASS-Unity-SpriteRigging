using TailElementJointSmoothFollow = PHATASS.TailSystem.TailElementJointSmoothFollow;

namespace PHATASS.SpriteRigging.Inspectors
{
	[UnityEngine.RequireComponent(typeof(UnityEngine.U2D.Animation.SpriteSkin))]
	public class TailRiggerInspectorSmoothFollowControllerJointChain : TailRiggerInspectorJointChain
	{
		public TailElementJointSmoothFollow defaultTailElementController;	//default tail element controller
	}
}