using UnityEngine;
//using SpriteRenderer = UnityEngine.U2D.Animation.SpriteRenderer;
using SpriteSkin = UnityEngine.U2D.Animation.SpriteSkin;

namespace PHATASS.SpriteRigging.Inspectors
{
	[RequireComponent(typeof(SpriteSkin))]
	public abstract class ArticulationBodyRiggerInspectorBase
	:
		RiggerInspectorBase,
		IArticulationBodyRiggerInspector
	{
		[Tooltip("A copy of this ArticulationBody will be added to every bone transform in the rigged SpriteSkin")]
		[SerializeField]
		private ArticulationBody _childArticulationBodySample;
		public ArticulationBody childArticulationBodySample { get { return this._childArticulationBodySample; } }

		[Tooltip("If this is defined, Root transform will be given a copy of this ArticulationBody instead.")]
		[SerializeField]
		private ArticulationBody _rootArticulationBodySample;
		public ArticulationBody rootArticulationBodySample { get { return this._rootArticulationBodySample; } }

		[Tooltip("If defined, will add a copy of this collider to every bone transform")]
		[SerializeField]
		private SphereCollider _defaultColliderSample;
		public SphereCollider defaultColliderSample { get { return this._defaultColliderSample; } }

		//[Tooltip("Root bone will have a collider only if this is true")]
		public bool rootHasCollider { get { return false; }}
	}
}