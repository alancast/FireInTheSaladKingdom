﻿using UnityEngine;
using System.Collections;

public class CameraMGR : MonoBehaviour {

	public static CameraMGR instance;

	public GameObject camera_target;

	void Start(){
		instance = this;
	}

	public void setNewTarget(GameObject new_target){
		camera_target = new_target;
		GetComponent<CameraZoom>().target = camera_target.rigidbody;
		GetComponent<CameraFollow>().target = camera_target;
	}

	public void reset(){
		GetComponent<CameraZoom>().reset ();
		GetComponent<CameraFollow>().reset ();
	}

}
