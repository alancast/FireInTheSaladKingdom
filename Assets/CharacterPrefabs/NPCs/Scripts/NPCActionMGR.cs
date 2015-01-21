using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPCActionMGR : MonoBehaviour {
	public bool loop;
	public NPCController NPC;
	public List<GameObject> npcActions = new List<GameObject>();
	public int current_action_index;

	void Awake(){
		current_action_index = 0;
	}

	// When something collides with a NPC Trigger, we want to 
	// Check 2 things:
	//		1. It must be the NPC Associated with this Trigger
	//		2. This trigger is the one that should be activated
	// 			by the NPC

	public void checkCollision(GameObject potential_npc, GameObject calling_action){
		if (current_action_index >= npcActions.Count) return;
		NPCController potential_npc_controller 
			= potential_npc.GetComponent<NPCController>();
		if (potential_npc_controller != NPC) return;
		if (calling_action != npcActions[current_action_index]) return;
		NPC.set_action(calling_action);
		++current_action_index;
		if (loop && current_action_index >= npcActions.Count) current_action_index = 0;
	}


	// For editor
	//=======================================================


	public NPCActionFactory.NPCActionTypes actionType;

	public void create_npc_action(){
		GameObject newAction = NPCActionFactory.get_npc_action(actionType);
		newAction.transform.parent = transform;
		npcActions.Add(newAction);
		NPCAction action = newAction.GetComponent("NPCAction") as NPCAction;
		action.mgr = this;
	}

}
