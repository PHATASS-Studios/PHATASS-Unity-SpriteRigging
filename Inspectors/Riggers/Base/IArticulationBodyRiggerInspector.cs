using UnityEngine;

namespace PHATASS.SpriteRigging.Inspectors
{
	public interface IArticulationBodyRiggerInspector : IRiggerInspector
	{
		//A copy of this ArticulationBody will be added to every bone transform in the rigged SpriteSkin
		ArticulationBody rootArticulationBodySample { get; }

		//If this is defined, Root transform will be given a copy of this ArticulationBody instead.
		ArticulationBody childArticulationBodySample { get; }

		//If defined, will add a copy of this collider to every bone transform
		SphereCollider defaultColliderSample { get; }

		//Root bone will have a collider only if this is true
		bool rootHasCollider { get; }
	}
}