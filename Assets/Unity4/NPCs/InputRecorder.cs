using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class InputRecorder : MonoBehaviour {
	
	
	public List<string> functions_to_listen_for = new List<string>();
	public string filename;
	StreamWriter recordfile;
	public bool disabled;

	void Start(){
		if (disabled) Destroy(gameObject);
		else secure_file();
	}

	void secure_file(){
		string filepath = Application.dataPath + "/NPCs/Recordings/" + filename;
		print (filepath);
		recordfile = new StreamWriter(filepath);
	}

	// Update is called once per frame
	void Update () {
		foreach (string function in functions_to_listen_for){
			if (InputManager.get.by_name(function)){
				recordfile.Write(Time.frameCount + "\n" + function + "\n");
			}
			if (Input.GetKey(KeyCode.Escape)){
				recordfile.Close();
				print("closing file");
				Destroy(gameObject);
			}
		}
	}
}
