using UnityEngine;
using System.Collections;

public class KillCharacter : MonoBehaviour {
	
	void OnTriggerEnter(Collider other){
		GameObject objToSpawn = other.gameObject;
		if (!objToSpawn) return;
		RespawnMGR.instance.respawn(objToSpawn);
	}
}
