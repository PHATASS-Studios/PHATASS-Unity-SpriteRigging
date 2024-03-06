using RequireComponentAttribute = UnityEngine.RequireComponent;

using SpriteSkin = UnityEngine.U2D.Animation.SpriteSkin;

namespace PHATASS.SpriteRigging.Inspectors
{
	[RequireComponent(typeof(SpriteSkin))]
	public abstract class LinkerInspectorBase :
		ArmableInspectorBase,
		ILinkerInspector
	{
	//ILinkerInspector
		public SpriteSkin managedSpriteSkin { get { return this.GetComponent<SpriteSkin>(); }}
	//ENDOF ILinkerInspector
	}
}