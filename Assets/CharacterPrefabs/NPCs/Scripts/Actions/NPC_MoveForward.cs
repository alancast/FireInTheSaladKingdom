using UnityEngine;
using System.Collections;

public class NPC_MoveForward : NPCAction {

	public override bool do_action (GameObject npc)
	{
		MoveSideways ms = npc.GetComponent<MoveSideways>();
		ms.set_acceleration(MoveSideways.accel_setting.FORWARD);
		return false;
	}
}

