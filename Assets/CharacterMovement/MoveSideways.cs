using UnityEngine;
using System.Collections;

public class MoveSideways : MonoBehaviour {

	public float max_velocity;
	public float max_acceleration;
	public float accel_speed;
	public float slow_down_factor;


	//	For physics
	public float acceleration;

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		handle_input();

	}

	void FixedUpdate(){
		change_velocity();
		//change_position();
	}

	void handle_input(){
		if (Input.GetKey(KeyCode.LeftArrow))
			change_acceleration(-accel_speed);
		if (Input.GetKey(KeyCode.RightArrow))
			change_acceleration(accel_speed);
		if (!Input.GetKey(KeyCode.RightArrow) &&
		    !Input.GetKey(KeyCode.LeftArrow)) 
				acceleration= 0;
	}

	// Adds the value of change to the current acceleration
	// If the new acceleration is 
	void change_acceleration(float change){
		if (acceleration < -max_acceleration && change < 0) return;
		if (acceleration > max_acceleration && change > 0) return;
		// If we're within bounds, add to the acceleration
		acceleration += change * Time.deltaTime;
		// If we're trying to accelerate in the opposite direction of
		// the way we're moving, set acceleration to 0
		if (Mathf.Sign(change) != Mathf.Sign(acceleration))
			acceleration = 0;
	}

	void change_velocity(){
		if (rigidbody.velocity.x < -max_velocity && acceleration < 0) return;
		if (rigidbody.velocity.x > max_velocity && acceleration > 0) return;
		Vector3 vel = rigidbody.velocity;
		vel.x += acceleration * Time.deltaTime;
		if (Mathf.Sign(rigidbody.velocity.x) != Mathf.Sign(acceleration)) 
			vel.x += acceleration * Time.deltaTime * slow_down_factor; 
		rigidbody.velocity = vel;
			
	}
	
//	void change_position(){
//		Vector3 pos = transform.position;
//		pos.x += velocity * Time.deltaTime;
//		transform.position = pos;
//	}

}
