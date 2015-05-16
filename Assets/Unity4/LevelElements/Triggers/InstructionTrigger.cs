using UnityEngine;
using System.Collections;

public class InstructionTrigger : MonoBehaviour {
	void OnTriggerEnter(Collider other){
		print ("triggered Instructions");
	}
}
