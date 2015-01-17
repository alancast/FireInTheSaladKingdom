using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

	public static InputManager get;

	void Start(){
		get = this;
	}

	public bool action(){
		return Input.GetKey(KeyCode.Space);
	}

	public bool action_down(){
		return Input.GetKeyDown(KeyCode.Space);
	}

	public bool swap_next_down(){
		return Input.GetKeyDown(KeyCode.D);
	}

	public bool swap_prev_down(){
		return Input.GetKeyDown(KeyCode.A);
	}

}

