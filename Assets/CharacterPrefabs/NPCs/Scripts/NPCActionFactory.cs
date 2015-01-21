//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using UnityEngine;
using System;

public class NPCActionFactory
{
	public enum NPCActionTypes {
		MOVE_FORWARD,
		MOVE_BACKWARD,
		WAIT
	}
	
	static public GameObject get_npc_action(NPCActionTypes action){
		GameObject actionGo = new GameObject();

		switch(action){
		case NPCActionTypes.MOVE_FORWARD:
			actionGo.AddComponent("NPC_MoveForward");
			actionGo.name = "Move Forward";
			break;
		case NPCActionTypes.MOVE_BACKWARD:
			actionGo.AddComponent("NPC_MoveBackward");
			actionGo.name = "Move Backward";
			break;
		case NPCActionTypes.WAIT:
			actionGo.AddComponent("NPC_Wait");
			actionGo.name = "Wait";
			break;

		}
		actionGo.AddComponent("BoxCollider");
		BoxCollider bc = actionGo.GetComponent("BoxCollider") as BoxCollider;
		bc.isTrigger = true;
		return actionGo;
	}


}


