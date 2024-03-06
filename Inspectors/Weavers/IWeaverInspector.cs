using ConfigurableJoint = UnityEngine.ConfigurableJoint;

namespace PHATASS.SpriteRigging.Inspectors
{
	public interface IWeaverInspector : IArmableInspector
	{
		ConfigurableJoint defaultWeavingJoint {get;}	//Sample joint configuration
	}
}