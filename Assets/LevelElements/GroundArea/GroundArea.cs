using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*    GroundArea
 * =====================================
 * 
 * A class to manage where the ground is. 
 * This makes a character's ability to jump more consistent
 * and allows us to do things based on how far the character
 * is from the ground
 */

public class GroundArea : MonoBehaviour {

	public List<float> area_heights = new List<float>();

	public enum State{
		ENTERING,
		EXITING
	}

	List<bool> currentTriggers = new List<bool>();
	void Start(){
		currentTriggers.Add(false);
		currentTriggers.Add(false);
	}

	public void notify(int trigger, State state, Collider other){
		switch (state){
		case State.ENTERING:
			currentTriggers[trigger] = true;
			break;
		case State.EXITING:
			currentTriggers[trigger] = false;
			if (!currentTriggers[0] && !currentTriggers[1])
				notify_jumper(trigger, other);
			break;
		}
	}

	void notify_jumper(int trigger, Collider other){
		Jump jumper = other.GetComponent<Jump>();
		if (!jumper) return;
		jumper.new_region(area_heights[trigger]);
	}

}
