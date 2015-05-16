using UnityEngine;
using System.Collections;

public class MoveSideways : MonoBehaviour {

	public float max_velocity;
	public float max_acceleration;
	public float accel_speed;
	public float slow_down_factor;


	//	For physics
	float acceleration;
	
	// Update is called once per frame

	void FixedUpdate(){
		change_velocity();
		//change_position();
	}

	public enum accel_setting {
		STOP,
		FORWARD,
		BACKWARD
	}

	public void set_acceleration(accel_setting setting){
		switch(setting){
		case accel_setting.STOP:
			acceleration = 0;
			break;
		case accel_setting.FORWARD:
			acceleration = accel_speed;
			break;
		case accel_setting.BACKWARD:
			acceleration = -accel_speed;
			break;
		}
	}

	public accel_setting get_acceleration(){
		if (acceleration == accel_speed) return accel_setting.FORWARD;
		else if (acceleration == -accel_speed) return accel_setting.BACKWARD;
		else return accel_setting.STOP;
	}

	void change_velocity(){
		if (GetComponent<Rigidbody>().velocity.x < -max_velocity && acceleration < 0) return;
		if (GetComponent<Rigidbody>().velocity.x > max_velocity && acceleration > 0) return;
		Vector3 vel = GetComponent<Rigidbody>().velocity;
		vel.x += acceleration * Time.deltaTime;
		if (Mathf.Sign(GetComponent<Rigidbody>().velocity.x) != Mathf.Sign(acceleration)) 
			vel.x += acceleration * Time.deltaTime * slow_down_factor; 
		GetComponent<Rigidbody>().velocity = vel;
			
	}


}
