using UnityEngine;
using System.Collections;

public class LimitBeckySpeed : MonoBehaviour {
	public float max_x_velocity;
	public float killSpeed;

	// Update is called once per frame
	void Update () {
		Vector3 vel = GetComponent<Rigidbody>().velocity;
		if (vel.x > Mathf.Abs(max_x_velocity)) {
			vel.x += -Mathf.Sign(vel.x)* killSpeed;		
		}
		GetComponent<Rigidbody>().velocity = vel;
	}
}
