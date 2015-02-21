using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class RecordedInputReader : MonoBehaviour {

	public string filename;
	StreamReader recordfile;
	public bool disabled;

	public GameObject character;

	// Use this for initialization
	void Start () {
		if (disabled) Destroy(gameObject);
		else fill_time_input_pairs();
	}

	void fill_time_input_pairs(){
		string filepath = Application.dataPath + "/NPCs/Recordings/" + filename;
		print (filepath);
		recordfile = new StreamReader(filepath);

		string line = recordfile.ReadLine();
		while (line != null){
			int time = Convert.ToInt32(line);
			line = recordfile.ReadLine();
			time_input_pairs.Add(new KeyValuePair<int, string>(time, line));
			line = recordfile.ReadLine();
		}
	}

	List<KeyValuePair<int, string>> time_input_pairs = new List<KeyValuePair<int, string>>();


	

}
