using UnityEngine;
using UnityEditor;

using WeaverInspectorManyToMany = PHATASS.SpriteRigging.Inspectors.WeaverInspectorManyToMany;

namespace PHATASS.SpriteRigging.Editors
{
	[CustomEditor(typeof(WeaverInspectorManyToMany))]
	public class WeaverEditorManyToMany : WeaverEditorBase<WeaverInspectorManyToMany>
	{
	//private method declaration
		public override void WeaveJoints()
		{
			if (targetInspector.originTransformList.Length != targetInspector.destinationTransformList.Length)
			{
				Debug.LogError("WeaverEditorManyToMany: Origin and Target rigidbody lists MUST be equal length");
				return;
			}

			for (int i = 0, iLimit = targetInspector.originTransformList.Length; i < iLimit; i++)
			{
				this.CreateJoint(targetInspector.originTransformList[i], targetInspector.destinationTransformList[i]);
			}
			Debug.Log(targetInspector.name + " Weaved ManyToMany joints");
		}
	//ENDOF private method declaration
	}
}
