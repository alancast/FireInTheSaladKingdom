using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RespawnMGR : MonoBehaviour {
	public List<GameObject> spawnPoints = new List<GameObject>();
	public int spawnIndex;

	public static RespawnMGR instance;

	void Awake(){
		instance = this;
		spawnIndex = 0;
	}


	public void respawn(GameObject objToSpawn){
		// Get the correct point to spawn at
		Vector3 pos = spawnPoints [spawnIndex].transform.position;
		// Kill all the movement and such for the object we're spawning
		objToSpawn.rigidbody.velocity = Vector3.zero;
		// Reset the acceleration ______________________________________________________________________________

		// Move the thing to the spawn point
		objToSpawn.transform.position = pos;
		// Jump the camera to the right point
		CameraMGR.instance.reset ();
		SwapCharacter.instance.disabled = false;
	}

}
