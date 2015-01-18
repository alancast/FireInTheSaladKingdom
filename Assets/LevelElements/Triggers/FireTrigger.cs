using UnityEngine;
using System.Collections;

public class FireTrigger : MonoBehaviour {
	private int count;

	void Awake(){
		count = GetComponentsInChildren<Transform> ().Length - 1;
	}

	void OnTriggerEnter(Collider other){
		if (CameraMGR.instance.score == count) {
			print ("win");			
		}
	}
}
