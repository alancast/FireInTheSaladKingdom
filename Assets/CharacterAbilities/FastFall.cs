using UnityEngine;
using System.Collections;

public class FastFall : MonoBehaviour {

	public float fast_fall_acceleration_speed;
	public float max_downward_vel;

	// Update is called once per frame
	void Update () {
		if (InputManager.get.action()) faster_fall();
	}

	void faster_fall(){
		Vector3 vel = rigidbody.velocity;
		if (vel.y <= -max_downward_vel) return;
		vel.y -= fast_fall_acceleration_speed;
		rigidbody.velocity = vel;
	}
}
