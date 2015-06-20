using UnityEngine;
using System.Collections;

public class KillPointDraw : MonoBehaviour {

	void OnDrawGizmos() {
		Gizmos.color = Color.red;
		Vector3 scale = transform.localScale;
		float theta = Mathf.Deg2Rad * transform.rotation.eulerAngles.z;
		float x = transform.localScale.x;
		float y = transform.localScale.y;
		scale.x = (x * Mathf.Cos(theta)) - (y * Mathf.Sin(theta));
		scale.y = (x * Mathf.Sin(theta)) + (y * Mathf.Cos(theta));
		Gizmos.DrawWireCube(transform.position, scale);
	}
}
