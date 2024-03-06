using UnityEngine;

using IRigidbodyRiggerInspector = PHATASS.SpriteRigging.Inspectors.IRigidbodyRiggerInspector;

namespace PHATASS.SpriteRigging.Editors
{
//rigs a chain of bones with required components
	public abstract class TailRiggerEditorBase<TInspector>
	:
		RigidbodyRiggerEditorBase<TInspector>
		where TInspector : UnityEngine.Object, IRigidbodyRiggerInspector
	{
	//inherited abstract method implementation
		protected override void RigBones ()
		{
			this.RigTail();
			Debug.Log("Rigged bones of " + this.targetInspector.name);
		}
	//ENDOF inherited abstract method implementation

	//private methods
		//extracts all the data from rigger object and calls a properly parametrized RigTailBoneRecursive
		private void RigTail ()
		{	
			this.RigTailRoot(targetInspector.spriteSkin.rootBone);
			this.RigTailBoneElementRecursive(targetInspector.spriteSkin.rootBone);
		}

		//Recursively populate every transform with adequate controller and components
		private	void RigTailBoneElementRecursive (Transform bone)
		{
			Debug.Log("Rigging tail bone: " + bone.name);
			this.RigTailBone(bone);
			//loop over this element's transform children, recursively rigging each of them
			for (int i = 0, iLimit = bone.childCount; i < iLimit; i++)
			{
				Transform nextBone = bone.GetChild(i);
				//recursively rig each child so required rigidbodies exist
				RigTailBoneElementRecursive(nextBone);
				//finally create required joints between the elements
				RigTailBonePairConnection(bone, nextBone);
			}
		}
	//ENDOF private methods

	//abstract method declaration
		//rig the base/root of the transform chain
		protected abstract void RigTailRoot (Transform rootBone);

		//rig an individual element of the transform chain
		protected abstract void RigTailBone (Transform bone);

		//rig a connection between two elements
		protected abstract ConfigurableJoint RigTailBonePairConnection (Transform bone, Transform nextBone);
	//ENDOF abstract method declaration
	}
}