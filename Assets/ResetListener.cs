using UnityEngine;
using System.Collections;

public class ResetListener : MonoBehaviour {

	void Update(){
		if (InputManager.get.reset()) reset ();
	}

	void reset(){
		RespawnMGR.instance.respawn(SwapCharacter.instance.currentChar);
	}
}
