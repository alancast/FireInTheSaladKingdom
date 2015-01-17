using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public static CameraFollow instance;

	public GameObject target;
	public float cam_easing;

	Vector3 desired_camera_position;


	void Start(){
		instance = this;
	}


	// Update is called once per frame
	void FixedUpdate () {
		desired_camera_position = target.transform.position;
		desired_camera_position.z = transform.position.z;
		transform.position = Vector3.Lerp(transform.position, desired_camera_position, cam_easing);
	}
}
