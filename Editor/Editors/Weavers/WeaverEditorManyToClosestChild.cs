using System.Collections.Generic;

using UnityEngine;
using UnityEditor;

using WeaverInspectorManyToClosestChild = PHATASS.SpriteRigging.Inspectors.WeaverInspectorManyToClosestChild;

using static PHATASS.Utils.Extensions.ComponentExtensions;

namespace PHATASS.SpriteRigging.Editors
{
	[CustomEditor(typeof(WeaverInspectorManyToClosestChild))]
	public class WeaverEditorManyToClosestChild : WeaverEditorBase<WeaverInspectorManyToClosestChild>
	{
	//overriden inherited methods
		public override void WeaveJoints()
		{
		//value validation
			if (this.targetInspector.destinationRootTransformList == null || this.targetInspector.destinationRootTransformList.Length == 0)
			{
				Debug.Log("WeaverEditorManyToClosestChild.WeaveJoints() requires a list of root transforms");
				return;
			}
//!!!!!!!!!!!!!!!
		//gather list of potential rigidbodies
			List<Transform> candidateList = this.FetchDestinationCandidates(
													rootTransforms: targetInspector.destinationRootTransformList,
													includeRootTransform: targetInspector.includeRootTransform
												);

		//find closest rigidbody for each rigidbody in originRigidbodyList
			foreach (Transform originTransform in this.targetInspector.originTransformList)
			{
				this.CreateJoint(
					fromTransform: originTransform,
					toTransform: FindClosestTransform(
						center: originTransform.position,
						transformList: candidateList
					)
				);
			}
		}
	//ENDOF overriden inherited methods

	//private methods
		//fetchs all potential target rigidbodies
		private List<Transform> FetchDestinationCandidates (Transform[] rootTransforms, bool includeRootTransform = false)
		{
			List<Rigidbody> rigidbodyList = new List<Rigidbody>();
			List<ArticulationBody> articulationBodyList = new List<ArticulationBody>();

			foreach (Transform rootTransform in rootTransforms)
			{
				rigidbodyList.AddRange(rootTransform.GetComponentsInChildren<Rigidbody>(includeInactive: true));	
				articulationBodyList.AddRange(rootTransform.GetComponentsInChildren<ArticulationBody>(includeInactive: true));	

				if (!includeRootTransform)
				{
					rigidbodyList.Remove(rootTransform.GetComponent<Rigidbody>());
					articulationBodyList.Remove(rootTransform.GetComponent<ArticulationBody>());
				}
			}

			List<Transform> transformList = new List<Transform>();
			foreach (Rigidbody rigidbody in rigidbodyList)
			{ transformList.Add(rigidbody.transform); }
			foreach (ArticulationBody articulationBody in articulationBodyList)
			{ transformList.Add(articulationBody.transform); }

			return transformList;
		}

		//finds and returns the rigidbody closest to 0 among rigidbodyList
		private Transform FindClosestTransform (Vector3 center, List<Transform> transformList)
		{
			return transformList.EFindClosestComponent<Transform>(center);
		}
	//ENDOF private methods
	}
}