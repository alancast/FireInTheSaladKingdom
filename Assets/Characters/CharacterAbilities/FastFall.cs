using UnityEngine;
using System.Collections;

public class FastFall : MonoBehaviour {

	public float fast_fall_acceleration_speed;
	public float max_downward_vel;

	public void Awake(){
		toggle_emission(false);
		GetComponentInChildren<ParticleSystem>().Play();
	}

	void OnEnable(){
		toggle_emission(false);
		GetComponentInChildren<ParticleSystem>().Play();
	}

	// Allows us to emit particles when fast-falling
	bool emission_on = false;

	public void faster_fall(){
		toggle_emission(true);
		Vector3 vel = GetComponent<Rigidbody>().velocity;
		if (vel.y <= -max_downward_vel) return;
		vel.y -= fast_fall_acceleration_speed;
		GetComponent<Rigidbody>().velocity = vel;
	}

	public void no_faster_fall(){
		if (emission_on) {
			toggle_emission(false);
		}
	}

	void toggle_emission(bool value){
		emission_on = value;
		ParticleSystem particles = GetComponentInChildren<ParticleSystem>();
		if (particles){
			particles.enableEmission = value;
		}
		else print ("Error");
	}
}
