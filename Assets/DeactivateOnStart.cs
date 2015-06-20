using UnityEngine;
using System.Collections;

public class DeactivateOnStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.SetActive(false);
	}
}
