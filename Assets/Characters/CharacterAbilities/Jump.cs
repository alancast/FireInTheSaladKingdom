using UnityEngine;
using System.Collections;

/* 				Jump
 * 
 * Add this class to a character to allow them to jump. 
 *
 * Requirements:
 * =====================================================
 * 1. Must be used in conjunction with "ground_area" triggers which designate the ends of 
 *     an area with ground at a certain height
 * 2. Must be used on a character with a Capsule Collider
 * 

 */

public class Jump : MonoBehaviour {

	// Jump parameters
	public float jump_vel;

	// Members to manage when the character is on the ground
	float base_height;
	public float forgiveness = -1f;

	public void new_region(float height){
		print ("old base_height: " + base_height);
		base_height = height;
		print ("new base height: " + height);
	}

	public void jump(){
		if (!isGrounded()) return;
		Vector3 vel = GetComponent<Rigidbody>().velocity;
		vel.y += jump_vel;
		GetComponent<Rigidbody>().velocity = vel;
		//GetComponentInChildren<ParticleSystem>().Play();

	}

	bool isGrounded(){
		SphereCollider col = GetComponent<SphereCollider>();
		float ray_length = (transform.lossyScale.y * col.radius) + forgiveness;
		if (Physics.Raycast(transform.position, Vector3.down, ray_length)) return true;
		else return false;
	}

}
