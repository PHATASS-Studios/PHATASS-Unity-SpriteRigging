using UnityEngine;
using UnityEditor;

using IInspectorBase = PHATASS.SpriteRigging.Inspectors.IInspectorBase;

namespace PHATASS.SpriteRigging.Editors
{
	public abstract class EditorBase<TInspector>
	:
		Editor,
		IEditorBase
		where TInspector : UnityEngine.Object, IInspectorBase
	{
	//inheritable properties
		protected TInspector targetInspector { get { return (TInspector) target; }}
	//ENDOF inheritable properties

	//inheritable methods
		//draws a button that performs an action if pressed
		protected delegate void EditorActionDelegate();
		protected virtual void DoButton (string buttonText, EditorActionDelegate action)
		{
			if (GUILayout.Button(buttonText))
			{
				action();
			}
		}
	//ENDOF inheritable methods

	//Setup GUI layout
		public override void OnInspectorGUI ()
		{
			base.OnInspectorGUI();

			//InspectorInitialization();
			DoButtons();
		}
	//ENDOF Setup GUI layout

	//IEditorBase declaration
		public abstract void DoSetup ();
	//ENDOF IEditorBase declaration

	//overridable methods and properties
		//protected abstract void InspectorInitialization ();
		protected abstract void DoButtons ();
	//ENDOF overridable methods
	}
}