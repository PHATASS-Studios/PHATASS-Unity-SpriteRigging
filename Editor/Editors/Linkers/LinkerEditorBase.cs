using UnityEngine;
using UnityEditor;

using ILinkerInspector = PHATASS.SpriteRigging.Inspectors.ILinkerInspector;

namespace PHATASS.SpriteRigging.Editors
{
	public abstract class LinkerEditorBase<TInspector> 
	:
		ArmableEditorBase<TInspector>,
		ILinkerEditor
		where TInspector : UnityEngine.Object, ILinkerInspector
	{
	//ArmableEditorBase implementation
		protected override void DoButtons ()
		{
			this.DoButton("Initiate SpriteSkin linking", this.InitiateLinking);
		}
	//ENDOF ArmableEditorBase implementation

	//IWeaverEditor implementation
		public override void DoSetup ()
		{
			this.InitiateLinking();
		}
	//ENDOF IWeaverEditor implementation

	//private methods
	//ENDOF private methods

	//overridable methods
		protected abstract void InitiateLinking ();
	//ENDOF overridable methods
	}
}
