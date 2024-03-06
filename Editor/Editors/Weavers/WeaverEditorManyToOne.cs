using UnityEngine;
using UnityEditor;

using WeaverInspectorManyToOne = PHATASS.SpriteRigging.Inspectors.WeaverInspectorManyToOne;

namespace PHATASS.SpriteRigging.Editors
{
	[CustomEditor(typeof(WeaverInspectorManyToOne))]
	public class WeaverEditorManyToOne : WeaverEditorBase<WeaverInspectorManyToOne>
	{
	//private method declaration
		public override void WeaveJoints()
		{
			foreach (Transform originTransform in targetInspector.originTransformList)
			{
				this.CreateJoint(originTransform, targetInspector.destinationTransform);
			}
			Debug.Log(targetInspector.name + " Weaved ManyToOne joints");
		}
	//ENDOF private method declaration
	}
}
