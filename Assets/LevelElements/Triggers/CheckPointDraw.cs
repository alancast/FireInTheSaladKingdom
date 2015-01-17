using UnityEngine;
using System.Collections;

public class CheckPointDraw : MonoBehaviour {

	void OnDrawGizmos() {
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube(transform.position, transform.localScale);
	}
}
