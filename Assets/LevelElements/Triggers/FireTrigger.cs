using UnityEngine;
using System.Collections;

public class FireTrigger : MonoBehaviour {
	public static FireTrigger instance;
	public int count;

	void Awake(){
		count = GetComponentsInChildren<Transform> ().Length - 1;
		instance = this;
		
	}

	void Start(){
		CameraMGR.instance.scoreGT.text = "Coins: " +
			CameraMGR.instance.score + "/" + (count - 5);
	}

	void OnTriggerEnter(Collider other){
		if (CameraMGR.instance.score >= count - 5) {
			print ("win");			
		}
	}
}
