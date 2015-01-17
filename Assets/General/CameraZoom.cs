﻿using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {

	public static CameraZoom instance;
	[HideInInspector]
	public Rigidbody target;
	Camera cam;

	public float min_zoom;
	public float max_zoom;
	public float max_vel;
	public float cam_easing;

	void Start(){
		instance = this;
		cam = GetComponent<Camera>();
	}

	// Update is called once per frame
	void Update () {
		float vel_factor = Mathf.Max(Mathf.Abs(target.velocity.x), Mathf.Abs(target.velocity.y));
		float desiredSize = Mathf.Lerp(min_zoom, max_zoom, vel_factor / max_vel);
		cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, desiredSize, cam_easing);
	}
}
