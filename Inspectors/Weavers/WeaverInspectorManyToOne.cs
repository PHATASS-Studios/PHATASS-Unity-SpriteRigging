using UnityEngine;

namespace PHATASS.SpriteRigging.Inspectors
{
	public class WeaverInspectorManyToOne : WeaverInspectorManyToXBase
	{
		[SerializeField]
		public Transform destinationTransform;
	}
}