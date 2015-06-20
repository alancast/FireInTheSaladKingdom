using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RespawnMGR : MonoBehaviour {
	public List<GameObject> spawnPoints = new List<GameObject>();
	public int spawnIndex;
	
	bool swapping_allowed;
	public bool is_respawning(){ return !swapping_allowed; }

	public static RespawnMGR instance;

	void Awake(){
		instance = this;
		spawnIndex = 0;
		swapping_allowed = true;
	}
	
	public void respawn(GameObject objToSpawn){
		swapping_allowed = false;
		Fader.instance.fade_out_and_in();
		StartCoroutine(delayed_respawn(objToSpawn));
	}

	IEnumerator delayed_respawn(GameObject objToSpawn){

		yield return new WaitForSeconds(Fader.instance.delay);

		// Move object to spawn point and kill motion
		Vector3 pos = spawnPoints [spawnIndex].transform.position;
		objToSpawn.GetComponent<Rigidbody>().velocity = Vector3.zero;
		objToSpawn.transform.position = pos;
		// Jump the camera to the right point
		CameraMGR.instance.reset ();

		swapping_allowed = true;
	}

}
