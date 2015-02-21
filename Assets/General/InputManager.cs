using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class InputManager : InputManagerBase {

	public static InputManager get;

	void Awake(){
		print ("Happening");
		get = this;
		init_funcs_map();
	}

	public KeyCode resetButton;
	public override bool reset(){
		return Input.GetKeyDown(resetButton);
	}

	public KeyCode actionButton;
	public override bool action(){
		return Input.GetKey(actionButton);
	}

	public override bool action_down(){
		return Input.GetKeyDown(actionButton);
	}

	public KeyCode swapNextButton;
	public override bool swap_next_down(){
		return Input.GetKeyDown(swapNextButton);
	}

	public KeyCode swapPrevButton;
	public override bool swap_prev_down(){
		return Input.GetKeyDown(swapPrevButton);
	}

	public KeyCode forwardButton;
	public override bool forward(){
		return Input.GetKey(forwardButton);
	}

	public KeyCode backwardButton;
	public override bool backward(){
		return Input.GetKey(backwardButton);
	}

	Dictionary<string, Func<bool>> funcs = new Dictionary<string, Func<bool>>();
	public string[] function_names = {
		"reset", 
		"action",
		"action_down",
		"swap_next_down",
		"swap_prev_down",
		"forward",
		"backward"
	};


	void init_funcs_map(){
		funcs["reset"] = reset;
		funcs["action"] = action;
		funcs["action_down"] = action_down;
		funcs["swap_next_down"] = swap_next_down;
		funcs["swap_prev_down"] = swap_prev_down;
		funcs["forward"] = forward;
		funcs["backward"] = backward;
	}

	public bool by_name(string func_name){
		return funcs[func_name]();
	}

}

