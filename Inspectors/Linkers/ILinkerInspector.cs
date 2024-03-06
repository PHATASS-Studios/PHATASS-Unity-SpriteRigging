using SpriteSkin = UnityEngine.U2D.Animation.SpriteSkin;

namespace PHATASS.SpriteRigging.Inspectors
{
	public interface ILinkerInspector : IArmableInspector
	{
		SpriteSkin managedSpriteSkin { get; }
	}
}