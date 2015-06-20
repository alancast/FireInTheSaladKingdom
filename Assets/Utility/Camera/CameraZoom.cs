using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {

	public static CameraZoom instance;
	[HideInInspector]
	public Rigidbody target;
	Camera cam;
	// Minimum velocity at which we start zooming
	public float zoom_start;
	public float min_zoom;
	public float max_zoom;
	public float max_vel;
	public float cam_easing;
	public float min_change;


	void Awake(){
		instance = this;
		cam = GetComponent<Camera>();
	}

	// Update is called once per frame
	void Update () {
		float vel_factor = Mathf.Max(Mathf.Abs(target.velocity.x), Mathf.Abs(target.velocity.y));
		if (vel_factor < min_change) vel_factor = 0;
		float desiredSize = Mathf.Lerp(min_zoom, max_zoom, vel_factor / max_vel);
		cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, desiredSize, cam_easing);
	}

	public void reset(){
		cam.orthographicSize = min_zoom;
	}
}
