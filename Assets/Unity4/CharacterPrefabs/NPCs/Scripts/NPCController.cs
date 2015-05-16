using UnityEngine;
using System.Collections;

public class NPCController : MonoBehaviour {

	public NPCActionMGR actionMGR;
	public NPCAction currentAction;

	// Update is called once per frame
	void Update () {
		if (!currentAction) return;
		if (currentAction.do_action(gameObject)) currentAction = null;
	}

	public void set_action(GameObject npcActionGo){
		NPCAction npcAction = npcActionGo.GetComponent<NPCAction>();
		currentAction = npcAction;
	}


	// For Editor
	//=================================================================

	public void create_action_mgr(){
		if (actionMGR) {
			print("ActionMGR already exists");
			return;
		}
		GameObject actionMGRgo = new GameObject();
		actionMGRgo.AddComponent<NPCActionMGR>();
		actionMGRgo.name = gameObject.name + "ActionManager";
		GameObject actionMGRfolder = get_action_mgr_folder();
		actionMGRgo.transform.parent = actionMGRfolder.transform;
		NPCActionMGR newActionMGR = actionMGRgo.GetComponent("NPCActionMGR") as NPCActionMGR;
		actionMGR = newActionMGR;
		actionMGR.NPC = this;
	}

	GameObject get_action_mgr_folder(){
		GameObject actionMGRfolder = GameObject.Find("ActionManagers");
		if (actionMGRfolder) return actionMGRfolder;

		actionMGRfolder = new GameObject();
		actionMGRfolder.name = "ActionManagers";
		return actionMGRfolder;
	}
}
