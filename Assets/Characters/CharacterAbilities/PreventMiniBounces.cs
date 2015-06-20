using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/* 			PreventMiniBounces
 * ======================================
 * 
 * Helps to keep a character from bouncing a minimal amount
 * quickly close to the floor
 * 
 */

public class PreventMiniBounces : MonoBehaviour {

	// Control Bounciness
	public float max_bounciness = .86f;
	public int max_bounce_time = 30;
	public int no_bounce_threshold = 4;
	public PhysicMaterial bouncy_material;

	// Managing current/previous direction
	int last_change_frame;

	// Keep track of some previous frames
	// If true, means moving downward
	int kFrames_to_track = 16;
	List<bool> previous_frames = new List<bool>();
	bool previously_downward;

	// Manage physics frames
	int current_frame;

	// Bookkeeping
	Rigidbody rigid;

	void Start() {
		current_frame = 0;
		reset();
	}

	void OnEnable(){
		reset();
	}

	void reset(){
		bouncy_material.bounciness = max_bounciness;
		rigid = GetComponent<Rigidbody>();
		last_change_frame = 0;
		bool downward = is_moving_downward();
		previously_downward = downward;
		if (previous_frames.Count == 0) init_frames(downward);
		else reset_frames(downward);

	}

	void init_frames(bool downward){
		for (int i = 0; i < kFrames_to_track; ++i){
			previous_frames.Add(downward);
		}
	}

	void reset_frames(bool downward){
		for (int i = 0; i < kFrames_to_track; ++i){
			previous_frames[i] = downward;
		}
	}


	void FixedUpdate(){
		++current_frame;

		bool currently_downward = is_moving_downward();
		if (previously_downward && !currently_downward){
			handle_direction_change();
		}
		previously_downward = currently_downward;
		update_previous_frames(currently_downward);
		if (in_free_fall()){
			Debug.DrawRay(transform.position, Vector3.down, Color.magenta, 2f);
			bouncy_material.bounciness = max_bounciness;
		}
	}

	int index = 0;
	void update_previous_frames(bool currently_downward){
		if (current_frame % 2 == 0) return;
		previous_frames[index] = currently_downward;
		if (++index >= previous_frames.Count) index = 0;
	}

	bool in_free_fall(){
		foreach (bool downward in previous_frames){
			if (!downward) return false;
		}
		return true;
	}

	float kMovementThreshold = .01f;
	/* Returns true if the rigidbody is moving downward at
	 * a significant speed,
	 * returns false otherwise */
	bool is_moving_downward(){
		float vertical_vel = rigid.velocity.y;
		if (Mathf.Abs(vertical_vel) < kMovementThreshold) return false;
		if (vertical_vel >= 0) return false;
		return true;
	}

	void handle_direction_change(){
		// Update bounciness based on last change
		float frames_since_last_change = current_frame - last_change_frame;
		print ("frames since last: " + frames_since_last_change);
		float percent_of_max_bounce = Mathf.Min(frames_since_last_change/max_bounce_time, 1f);
		if (frames_since_last_change < no_bounce_threshold) percent_of_max_bounce = 0f;
		bouncy_material.bounciness = percent_of_max_bounce * max_bounciness;
		// Update maintainence 
		last_change_frame = current_frame;
	}




}
