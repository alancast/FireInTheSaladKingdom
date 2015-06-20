using UnityEngine;
using System.Collections;

public class GizmoArrow : MonoBehaviour {

	void OnDrawGizmos() {
		Gizmos.color = Color.white;
		Gizmos.DrawRay(transform.position, GetComponent<Rigidbody>().velocity);
	}
}
