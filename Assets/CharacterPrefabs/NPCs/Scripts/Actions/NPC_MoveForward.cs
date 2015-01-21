using UnityEngine;
using System.Collections;

public class NPC_MoveForward : NPCAction {

	public MoveSideways.accel_setting direction;
	public float max_vel;
	public float turn_around_threshold;

	public override bool do_action (GameObject npc)
	{
		MoveSideways ms = npc.GetComponent<MoveSideways>();
		if (going_in_opposite_direction(npc)){
			ms.set_acceleration(MoveSideways.accel_setting.STOP);
			return false;
		}
		ms.set_acceleration(direction);
		return false;
	}

	public bool going_in_opposite_direction(GameObject npc){
		Rigidbody rb = npc.GetComponent<Rigidbody>();
		if (direction == MoveSideways.accel_setting.FORWARD) 
			return (rb.velocity.x >= max_vel || rb.velocity.x <-turn_around_threshold);
		else return (Mathf.Abs(rb.velocity.x) >= max_vel || rb.velocity.x > turn_around_threshold);
	}

	void OnDrawGizmos(){
		Gizmos.color = new Color(0, 80, 220);
		Gizmos.DrawIcon(transform.position, "Move_forward.png", false);
	}
}

