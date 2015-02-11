using UnityEngine;
using System.Collections;

public class InstructionTrigger : MonoBehaviour {
	void OnTriggerEnter(Collider other){
		Application.LoadLevel("_Scene_HowTo_1");
	}
}
