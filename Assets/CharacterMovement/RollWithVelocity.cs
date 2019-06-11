using UnityEngine;
using System.Collections;

// Roll with velocity adds a rolling "Animation" to an object so that it
// rolls according to the object's velocity\
// Object must have a MoveSideways Component

public class RollWithVelocity : MonoBehaviour {


	public float roll_to_velocity_ratio;

	public float current_roll_speed;

	// Update is called once per frame
	void Update () {
		calculate_roll_speed();
		roll();
	}

	void calculate_roll_speed(){
		current_roll_speed = GetComponent<Rigidbody>().velocity.x * roll_to_velocity_ratio;
	}

	void roll(){
		transform.Rotate(new Vector3(0, 0, -current_roll_speed));
	}


}
