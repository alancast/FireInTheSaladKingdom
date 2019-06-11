using UnityEngine;
using System.Collections;

public class FastFall : MonoBehaviour {

	public float fast_fall_acceleration_speed;
	public float max_downward_vel;


	public void faster_fall(){
		Vector3 vel = GetComponent<Rigidbody>().velocity;
		if (vel.y <= -max_downward_vel) return;
		vel.y -= fast_fall_acceleration_speed;
		GetComponent<Rigidbody>().velocity = vel;
	}
}
