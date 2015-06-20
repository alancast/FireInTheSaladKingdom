using UnityEngine;
using System.Collections;

public class GroundAreaTrigger : MonoBehaviour {

	public GroundArea parent;
	public int triggerNumber; // 0 For Left, 1 for right

	public void OnTriggerEnter(Collider other){
		parent.notify(triggerNumber, GroundArea.State.ENTERING, other);
	}

	public void OnTriggerExit(Collider other){
		parent.notify(triggerNumber, GroundArea.State.EXITING, other);
	}

}
