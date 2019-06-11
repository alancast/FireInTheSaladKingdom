﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraMGR : MonoBehaviour {

	public static CameraMGR instance;
	public Text scoreGT;
	public int score;

	public GameObject camera_target;

	void Awake(){
		instance = this;
	}

	void Start(){
		score = 0;
		GameObject scoreGO = GameObject.Find("ScoreLabel"); 
		if (!scoreGO) return;
		scoreGT = scoreGO.GetComponent<Text>();
		scoreGT.text = "Water: " + score;
	}

	public void setNewTarget(GameObject new_target){
		camera_target = new_target;
		GetComponent<CameraZoom>().target = camera_target.GetComponent<Rigidbody>();
		GetComponent<CameraFollow>().target = camera_target;
	}

	public void reset(){
		GetComponent<CameraZoom>().reset ();
		GetComponent<CameraFollow>().reset ();
	}

}
