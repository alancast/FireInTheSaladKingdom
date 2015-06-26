using UnityEngine;
using System.Collections;

/*				KillUpwardVelocity
 * --------------------------------------
 * 
 * Creates an invisible 'ceiling' that kills upward velocity
 * Attach to objects with box colliders set to trigger
 * --------------------------------------*/

public class KillUpwardVelocity : MonoBehaviour {

	[Range (0, 1)]
	public float kill_factor =.5f;

	void OnDrawGizmos() {
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireCube(transform.position, transform.localScale);
	}

	void OnTriggerEnter(Collider other){
		Rigidbody object_to_kill = other.GetComponent<Rigidbody>();
		if (!object_to_kill) return;
		if (object_to_kill.velocity.y <= 0) return;
		StartCoroutine("kill_velocity", object_to_kill);
	}

	IEnumerator kill_velocity(Rigidbody obj_to_kill){
		while (obj_to_kill && obj_to_kill.velocity.y > 0){
			Vector3 vel = obj_to_kill.velocity;
			vel.y = vel.y / (1 + kill_factor);
			obj_to_kill.velocity = vel;
			yield return null;
		}
		yield return null;
	}
}
