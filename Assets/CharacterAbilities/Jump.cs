using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	public float jump_vel;
	public float ground_jump_distance;
	
	// Update is called once per frame
	void Update () {
		if (!onGround()) return;
		if (InputManager.get.action_down()){
			jump();
		}
	}

	bool onGround(){
		if (Physics.Raycast(transform.position, 
			new Vector3(0, -1, 0), transform.collider.bounds.size.y + ground_jump_distance)) return true;
		else return false;
	}

	void jump(){
		Vector3 vel = rigidbody.velocity;
		vel.y += jump_vel;
		rigidbody.velocity = vel;
	}
}
