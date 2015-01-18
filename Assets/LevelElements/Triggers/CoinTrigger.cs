using UnityEngine;
using System.Collections;

public class CoinTrigger : MonoBehaviour {

	void OnTriggerEnter(){
		Destroy (this.gameObject);
		CameraMGR.instance.score += 1;
		CameraMGR.instance.scoreGT.text = "Coins: " + CameraMGR.instance.score + "/" 
			+ (FireTrigger.instance.count - 5);
	}
}
