using UnityEngine;

namespace PHATASS.SpriteRigging.Inspectors
{
	public class WeaverInspectorManyToClosestChild : WeaverInspectorManyToXBase
	{
		public Transform[] destinationRootTransformList = null;
		public bool includeRootTransform = false;
	}
}