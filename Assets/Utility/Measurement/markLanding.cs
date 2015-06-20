using UnityEngine;
using System.Collections;

public class markLanding : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		print(other.transform.position.x);
	}
}
