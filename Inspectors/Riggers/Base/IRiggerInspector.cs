using UnityEngine;
using SpriteSkin = UnityEngine.U2D.Animation.SpriteSkin;

namespace PHATASS.SpriteRigging.Inspectors
{
	public interface IRiggerInspector : IArmableInspector
	{
		//wether or not purging bone transform tree removes its rigidbodies too
		bool purgeKeepsPhysicBodies { get; }

		//references to fundamental components
		Sprite sprite { get; }
		SpriteSkin spriteSkin { get; }

		//information on transform layer & tag
		int defaultLayer { get; }
		string defaultTag { get; }
	}
}