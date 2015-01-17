using UnityEngine;
using System.Collections;

public class SpawnPointDraw : MonoBehaviour {

	void OnDrawGizmos() {
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(transform.position, transform.localScale.x);
	}
}
