using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {

	public static CameraZoom instance;
	public Rigidbody target;
	Camera cam;

	public float min_zoom;
	public float max_zoom;
	public float zoom_factor;

	void Start(){
		instance = this;
		cam = GetComponent<Camera>();
	}

	// Update is called once per frame
	void Update () {
		float vel_factor = Mathf.Abs(Mathf.Max(target.velocity.x, target.velocity.y));
		cam.orthographicSize = Mathf.Lerp(min_zoom, max_zoom, zoom_factor/ vel_factor);
	}
}
