﻿using UnityEngine;
using System.Collections;

public class ScreamController : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
	}

	void Movement(){
		float speedX = Mathf.Abs (GetComponent<Rigidbody>().velocity.x);
		float speedY = Mathf.Abs(GetComponent<Rigidbody>().velocity.y);
	
		float curSpeed = Mathf.Max (speedX, speedY);

		anim.SetFloat ("speed", curSpeed);
	}
}
