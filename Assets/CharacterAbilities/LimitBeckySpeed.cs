using UnityEngine;
using System.Collections;

public class LimitBeckySpeed : MonoBehaviour {
	public int max_x_velocity;

	// Update is called once per frame
	void Update () {
		Vector3 vel = rigidbody.velocity;
		if (vel.x < -max_x_velocity) {
			vel.x = -max_x_velocity;		
		}
		if (vel.x > max_x_velocity) {
			vel.x = max_x_velocity;		
		}
		rigidbody.velocity = vel;
	}
}
