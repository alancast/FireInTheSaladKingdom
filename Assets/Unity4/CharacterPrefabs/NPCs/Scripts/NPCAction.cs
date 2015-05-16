using UnityEngine;
using System.Collections;

abstract public class NPCAction : MonoBehaviour {

	public NPCActionMGR mgr;

	// do_action() functions will call appropriate functions to 
	// control an npc
	// If the action being performed is complete (e.g. waiting is done)
	// the function will return true. Otherwise it will return false
	virtual public bool do_action(GameObject npc){
		print ("ERROR! No NPC Trigger assigned!");
		return false;
	}

	// when an npc action is hit, it will issue a request to the action MGR
	// If this action request is well-timed, the action MGR will issue said 
	// Action to the NPC. 
	void OnTriggerEnter(Collider other){
		mgr.checkCollision(other.gameObject, gameObject);
	}
	
}
