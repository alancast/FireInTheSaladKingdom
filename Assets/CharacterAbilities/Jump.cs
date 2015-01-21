using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	public float jump_vel;
	public float ground_jump_distance;

	public void jump(){
		if (!onGround()) return;
		Vector3 vel = rigidbody.velocity;
		vel.y += jump_vel;
		rigidbody.velocity = vel;
	}

	bool onGround(){
		if (Physics.Raycast(transform.position, 
		                    new Vector3(0, -1, 0), transform.collider.bounds.size.y + ground_jump_distance)) return true;
		else return false;
	}
}
