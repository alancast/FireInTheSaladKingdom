using UnityEngine;
using System.Collections;

public class DestroyOnCollision : MonoBehaviour {

	void OnTriggerEnter(){
		Destroy(gameObject);
	}
}
