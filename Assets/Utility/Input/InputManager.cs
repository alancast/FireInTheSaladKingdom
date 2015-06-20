using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

/* 				InputManager 
 * -------------------------------------------
 * 
 * Input Manager is an implementation of the 
 * InputManagerBase. The inputManager allows 
 * input calls to be disabled by name. If a 
 * call is disabled, it always returns false 
 * until it is enabled again
 * 
 * InputManager is a singleton class, accessed
 * by the "get" method
 ---------------------------------------------	*/

public class InputManager : InputManagerBase {

	/* Singleton Accessor */
	public static InputManager get;

	/* Enabled Dictionary */
	HashSet<string> disabled = new HashSet<string>();

	void Awake(){
		get = this;
		init_funcs_map();
	}

	public KeyCode resetButton;
	public override bool reset(){
		if (disabled.Contains("reset")) return false;
		return Input.GetKeyDown(resetButton);
	}

	public KeyCode actionButton;
	public override bool action(){
		if (disabled.Contains("action")) return false;
		return Input.GetKey(actionButton);
	}

	public override bool action_down(){
		if (disabled.Contains("action_down")) return false;
		return Input.GetKeyDown(actionButton);
	}

	public KeyCode swapNextButton;
	public override bool swap_next_down(){
		if (disabled.Contains("swap_next_down")) return false;
		return Input.GetKeyDown(swapNextButton);
	}

	public KeyCode swapPrevButton;
	public override bool swap_prev_down(){
		if (disabled.Contains("swap_prev_down")) return false;
		return Input.GetKeyDown(swapPrevButton);
	}

	public KeyCode forwardButton;
	public override bool forward(){
		if (disabled.Contains("forward")) return false;
		return Input.GetKey(forwardButton);
	}

	public KeyCode backwardButton;
	public override bool backward(){
		if (disabled.Contains("backward")) return false;
		return Input.GetKey(backwardButton);
	}

	/* Disable/Enable functions by name */
		
	public void disable_input(string input){
		if (!disabled.Contains(input)){
			disabled.Add(input);
		}
	}


	public void enable_input(string input){
		//If the key isn't in the dictionary,
		// nothing is happening, so we just return
		if (!disabled.Contains(input)) return;
		// If it is in there, get rid of it
		disabled.Remove(input);
	}

	/* Get functions by name for dynamic accessing */
	/*----------------------------------------------*/

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

