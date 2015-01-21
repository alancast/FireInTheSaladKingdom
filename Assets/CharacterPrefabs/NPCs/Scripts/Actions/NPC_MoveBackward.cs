using UnityEngine;
using System.Collections;

public class NPC_MoveBackward : NPCAction {
	
	public float max_vel;
	public float turn_around_threshold;

	bool prepared_to_finish;

	void Awake(){
		prepared_to_finish = false;
	}
	
	public override bool do_action (GameObject npc)
	{
		Rigidbody rb = npc.GetComponent<Rigidbody>();
		MoveSideways ms = npc.GetComponent<MoveSideways>();
		
		if (Mathf.Abs(rb.velocity.x) >= max_vel || rb.velocity.x > turn_around_threshold ){
			ms.set_acceleration(MoveSideways.accel_setting.STOP);
			prepared_to_finish = true;
			return false;
		}
		if (prepared_to_finish){
			prepared_to_finish = false;
			return true;
		}
		ms.set_acceleration(MoveSideways.accel_setting.BACKWARD);
		return false;
	}
	
	void OnDrawGizmos(){
		Gizmos.color = new Color(0, 80, 220);
		Gizmos.DrawIcon(transform.position, "Move_forward.png", false);
	}
}