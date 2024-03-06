using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;

using static UnityEngine.U2D.SpriteDataAccessExtensions; //Sprite.GetIndices();

using static PHATASS.Utils.Extensions.TransformExtensions;
using static PHATASS.Utils.Extensions.TransformJointRiggingExtensions;

using Unity.Collections;	//nativeArray<T>

using SkinSurfaceRiggerInspector = PHATASS.SpriteRigging.Inspectors.SkinSurfaceRiggerInspector;

namespace PHATASS.SpriteRigging.Editors
{
	[CustomEditor(typeof(SkinSurfaceRiggerInspector))]
	public class SkinSurfaceRiggerEditor : RigidbodyRiggerEditorBase<SkinSurfaceRiggerInspector>
	{
	//inherited abstract method implementation
		protected override void RigBones ()
		{
			Debug.Log("Rigging bone components for " + targetInspector.name);

			this.RigBoneMesh(
				boneList: targetInspector.spriteSkin.boneTransforms,
				triangles: targetInspector.sprite.GetIndices(),
				defaultRigidbody: targetInspector.defaultRigidbody,
				defaultMeshJoint: targetInspector.defaultMeshJoint,
				defaultCollider: targetInspector.defaultCollider,
				defaultTag: targetInspector.defaultTag,
				defaultLayer: targetInspector.defaultLayer
			);

			Debug.Log("Rigged bones of " + targetInspector.name);
		}
	//ENDOF inherited abstract method implementation

	//private methods
		private void RigBoneMesh <
			TMeshJoint,
			TCollider
		> (
			Transform[] boneList,
			NativeArray<ushort> triangles,
			Rigidbody defaultRigidbody,
			TMeshJoint defaultMeshJoint,
			TCollider defaultCollider,
			string defaultTag = null,
			int defaultLayer = -1
		)
			where TMeshJoint: Joint
			where TCollider: Collider
		{
			foreach (Transform bone in boneList)
			{
				this.RigBoneIndividualElements<
					TCollider
				> (
					bone: bone,
					defaultRigidbody: defaultRigidbody,
					defaultCollider: defaultCollider,
					defaultTag: defaultTag,
					defaultLayer: defaultLayer
				);
			}

			Debug.Log ("Individual components rigged, deploying spring mesh");

			RigBoneSpringMesh<TMeshJoint>(boneList, triangles, defaultMeshJoint);

			Debug.Log ("Rigging bones finished");
		}

		//creates components that affect a single bone: rigidbodies and disconnected anchors/joints
		private void RigBoneIndividualElements <
			TCollider
		> (
			Transform bone,
			Rigidbody defaultRigidbody,
			TCollider defaultCollider,
			string defaultTag = null,
			int defaultLayer = -1
		) 
			where TCollider: Collider
		{
			//set the object tag and physics layer of the bone transform
			bone.ESetTagAndLayer(defaultTag, defaultLayer);

			//give it a rigidbody and a collider
			bone.ESetupComponent<Rigidbody>(defaultRigidbody);
			if (defaultCollider != null)
			{ bone.ESetupComponent<TCollider>(defaultCollider);	}

			//try to create a joint anchoring the bone to target anchor rigidbody
			this.BoneCreateAnchor(bone);
		}

		//Generate springs between bones connected according to a triangle list
		//triangleList contains a multiple of 3 entries, and each 3 entries define a triangle
		private void RigBoneSpringMesh 
			<TJoint>
			(Transform[] boneList, NativeArray<ushort> triangleList, TJoint sample)
			where TJoint: Joint
		{
			if ((triangleList.Length % 3) != 0) { Debug.LogWarning("RigBoneSpringMesh() triangles.Length is not a multiple of 3"); }
			for (int i = 0, iLimit = triangleList.Length; i < iLimit; i += 3)
			{
				//for every 3 vertex entries, process them as a triangle
				BoneGenerateSpringPolygon (boneList, triangleList.GetSubArray(i, 3), sample);
			}
		}

		//Generates the springs for a single polygon
		private void BoneGenerateSpringPolygon
			<TJoint>
			(Transform[] boneList, NativeArray<ushort> polygon, TJoint sample)
			where TJoint: Joint
		{
			//first element will connect to the last enclosing the polygon
			int previousBone = polygon.Length - 1;

			for (int i = 0, iLimit = polygon.Length; i < iLimit; i++)
			{
				//connect every bone to the previous bone in the polygon
				boneList[polygon[i]].ESetupJointInterconnection<TJoint>(
					transform2: boneList[polygon[previousBone]],
					sample: sample,
					mutual: false
				);
				previousBone = i;
			}
		}
	}
}