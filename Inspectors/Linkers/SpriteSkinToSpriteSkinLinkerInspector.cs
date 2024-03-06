using UnityEngine;
using SpriteSkin = UnityEngine.U2D.Animation.SpriteSkin;

namespace PHATASS.SpriteRigging.Inspectors
{
	public class SpriteSkinToSpriteSkinLinkerInspector :
		LinkerInspectorBase
	{
		[SerializeField]
		[Tooltip("SpriteSkin used as root. Managed SpriteSkin's bones will now point to this SpriteSkin's bones")]
		public SpriteSkin linkedSpriteSkin;

		[SerializeField]
		[Tooltip("All children transforms will be delete")]
		public bool deleteChildTransforms = true;
	}
}
