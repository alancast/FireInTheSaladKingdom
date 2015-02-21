using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


public class RecordedInputManager : InputManagerBase {

	public string filename;
	StreamReader recordfile;
	public bool disabled;

	
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
			string input = recordfile.ReadLine();
			if (!inputs_at_time.ContainsKey(time))
				inputs_at_time.Add(time, new List<string>());
			inputs_at_time[time].Add(input);
			line = recordfile.ReadLine();
		}
		print(inputs_at_time[70][0]);
	}

	Dictionary<int, List<string>> inputs_at_time = new Dictionary<int, List<string>>();

	public override bool reset(){
		return check_input("reset");
	}

	public override bool action(){
		return check_input("action");
	}

	public override bool action_down(){
		return check_input("action_down");
	}

	public override bool swap_next_down(){
		return check_input("swap_next_down");
	}

	public override bool swap_prev_down(){
		return check_input("swap_prev_down");
	}

	public override bool forward(){
		return check_input("forward");
	}

	public override bool backward(){
		return check_input("backward");
	}

	bool check_input(string input){
		if (!inputs_at_time.ContainsKey(Time.frameCount)) return false;
		if (inputs_at_time[Time.frameCount].Contains(input)) return true;
		else return false;
	}




}
