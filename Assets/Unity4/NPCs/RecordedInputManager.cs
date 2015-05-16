using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


public class RecordedInputManager : InputManagerBase {

	public string filename;
	StreamReader recordfile;
	public bool disabled;
	int offset;

	Dictionary<int, List<string>> inputs_at_time = new Dictionary<int, List<string>>();
	
	// Use this for initialization
	void Start () {
		// Initialize offset to 0 for base case where we want input to start immediately
		offset = 0;
		// If the recorded input manager is enabled and  the object doesn't have a collider,
		// this means that the character is supposed to start the recorded task upon start
		// we then fill the time_input_pairs without an offset
		if (!disabled && !gameObject.GetComponent<Collider>()) fill_time_input_pairs();
	}

	// If we want the action to start only after we enter the trigger of the input manager, 
	// We will wait to fill_time_input_pairs();
	void OnTriggerEnter(){
		offset = Time.frameCount;
		fill_time_input_pairs();
	}

	
	void fill_time_input_pairs(){
		// Load the recorded data
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
	}

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
		int current_frame = Time.frameCount - offset;
		if (!inputs_at_time.ContainsKey(current_frame)) return false;
		if (inputs_at_time[current_frame].Contains(input)) return true;
		else return false;
	}




}
