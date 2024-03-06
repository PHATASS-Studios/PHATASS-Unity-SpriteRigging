using UnityEngine;
//using SpriteRenderer = UnityEngine.U2D.Animation.SpriteRenderer;
using SpriteSkin = UnityEngine.U2D.Animation.SpriteSkin;

namespace PHATASS.SpriteRigging.Inspectors
{
	[RequireComponent(typeof(SpriteSkin))]
	public abstract class RiggerInspectorBase
	:
		ArmableInspectorBase,
		IRiggerInspector
	{
		//wether or not purging bone transform tree removes its rigidbodies too
			//[SerializeField]
			//private bool _purgeKeepsRigidbodies = true;
			//public bool purgeKeepsRigidbodies { get { return _purgeKeepsRigidbodies; }}
		//for now at least, purge will only admit NOT removing rigidbodies
		public bool purgeKeepsPhysicBodies { get { return true; }}

		//references to fundamental components
		public Sprite sprite { get { return gameObject.GetComponent<SpriteRenderer>()?.sprite; }}
		public SpriteSkin spriteSkin { get { return gameObject.GetComponent<SpriteSkin>(); }}

		//information on transform layer & tag
		[SerializeField]
		private GameObject defaultLayerSample = null;
		public int defaultLayer { get { return (defaultLayerSample != null) ? defaultLayerSample.layer : -1; }}
		public string defaultTag { get { return defaultLayerSample?.tag; }}
	}
}