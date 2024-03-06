using UnityEngine;
using UnityEditor;

using static PHATASS.Utils.Extensions.TransformJointRiggingExtensions;

using IWeaverInspector = PHATASS.SpriteRigging.Inspectors.IWeaverInspector;

namespace PHATASS.SpriteRigging.Editors
{
	public abstract class WeaverEditorBase<TInspector> 
	:
		ArmableEditorBase<TInspector>,
		IWeaverEditor
		where TInspector : UnityEngine.Object, IWeaverInspector
	{
	//ArmableEditorBase implementation
		protected override void DoButtons ()
		{
			DoButton("Setup weaving joints", WeaveJoints);
		}
	//ENDOF ArmableEditorBase implementation

	//IWeaverEditor implementation
		public override void DoSetup ()
		{
			WeaveJoints();
		}
	//ENDOF IWeaverEditor implementation

	//private methods
		protected void CreateJoint (Transform fromTransform, Transform toTransform)
		{
			fromTransform.ESetupJointConnectingTo<ConfigurableJoint>(
				target: toTransform,
				sample: targetInspector.defaultWeavingJoint
			);
		}
	//ENDOF private methods

	//overridable methods
		public abstract void WeaveJoints();
	//ENDOF overridable methods
	}
}