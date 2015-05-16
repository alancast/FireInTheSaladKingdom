using UnityEngine;
using System.Collections;

public class NPC_Wait : NPCAction {

	public float waitTime;
	bool count_begun;

	void Awake(){
		count_begun = false;
	}

	float startTime;

	public override bool do_action (GameObject npc)
	{
		if (!count_begun) startTime = Time.time;
		if (Time.time - startTime >= waitTime) return true;
		return false;
	}
}
