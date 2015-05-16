using UnityEngine;
using System.Collections;

public class CheckPointTrigger : MonoBehaviour {
	public int checkPointID;

	void OnTriggerEnter(Collider other){
		RespawnMGR.instance.spawnIndex = checkPointID;
	}
}
