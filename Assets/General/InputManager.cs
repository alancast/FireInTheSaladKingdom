using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	public static InputManager get;

	void Start(){
		get = this;
	}

	public KeyCode resetButton;
	public bool reset(){
		return Input.GetKeyDown(resetButton);
	}

	public KeyCode actionButton;
	public bool action(){
		return Input.GetKey(actionButton);
	}

	public bool action_down(){
		return Input.GetKeyDown(actionButton);
	}

	public KeyCode swapNextButton;
	public bool swap_next_down(){
		return Input.GetKeyDown(swapNextButton);
	}

	public KeyCode swapPrevButton;
	public bool swap_prev_down(){
		return Input.GetKeyDown(swapPrevButton);
	}

	public KeyCode forwardButton;
	public bool forward(){
		return Input.GetKey(KeyCode.RightArrow);
	}

	public KeyCode backwardButton;
	public bool backward(){
		return Input.GetKey(KeyCode.LeftArrow);
	}

}

