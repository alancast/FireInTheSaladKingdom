using UnityEngine;
using System.Collections;

public class LimitBeckySpeed : MonoBehaviour {
	public float max_x_velocity;
	public float killSpeed;

	// Update is called once per frame
	void Update () {
		Vector3 vel = rigidbody.velocity;
		if (vel.x < -max_x_velocity) {
			vel.x += killSpeed;		
		}
		if (vel.x > max_x_velocity) {
			vel.x -= killSpeed;		
		}
		rigidbody.velocity = vel;
	}
}
