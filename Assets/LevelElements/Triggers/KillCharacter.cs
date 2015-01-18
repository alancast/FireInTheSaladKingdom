using UnityEngine;
using System.Collections;

public class KillCharacter : MonoBehaviour {
	
	void OnTriggerEnter(Collider other){
		SwapCharacter.instance.disabled = true;
		GameObject objToSpawn = other.gameObject;
		if (!objToSpawn) return;
		StartCoroutine("delayRespawn", objToSpawn);
	}
	
	IEnumerator delayRespawn(GameObject objToSpawn){
		yield return new WaitForSeconds(.5f);
		RespawnMGR.instance.respawn (objToSpawn);
	}
}
