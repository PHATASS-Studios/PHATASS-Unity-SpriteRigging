using UnityEngine;
using UnityEditor;

using IArticulationBodyRiggerInspector = PHATASS.SpriteRigging.Inspectors.IArticulationBodyRiggerInspector;

namespace PHATASS.SpriteRigging.Editors
{
	public abstract class ArticulationBodyRiggerEditorBase<TInspector>
	:
		RiggerEditorBase<TInspector>
		where TInspector : UnityEngine.Object, IArticulationBodyRiggerInspector
	{
	//overridable methods and properties
	//ENDOF overridable methods
	}
}