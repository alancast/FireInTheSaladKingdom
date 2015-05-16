using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {


	public InputManagerBase input;

	MoveSideways ms;
	Jump jump;
	FastFall ff;

	// Use this for initialization
	void Start () {
		if (!input) input = InputManager.get;

		ms = GetComponent<MoveSideways>();
		jump = GetComponent<Jump>();
		ff = GetComponent<FastFall>();
	}
	
	// Update is called once per frame
	void Update () {
		if (ms) handle_movement_input();
		if (jump) handle_jump_input();
		if (ff) handle_fast_fall_input();
		handle_swap_character_input();
	}

	void handle_movement_input(){
		if (input.backward())
			ms.set_acceleration(MoveSideways.accel_setting.BACKWARD);
		if (input.forward())
			ms.set_acceleration(MoveSideways.accel_setting.FORWARD);
		if (!input.forward() && !input.backward()) 
			ms.set_acceleration(MoveSideways.accel_setting.STOP);
	}

	void handle_jump_input(){
		if (input.action_down()) jump.jump();
	}

	void handle_fast_fall_input(){
		if (input.action()) ff.faster_fall();
	}

	void handle_swap_character_input(){
		if (input.swap_next_down()) {
			SwapCharacter.instance.swapNextChar();
		}
		if (input.swap_prev_down()){
			SwapCharacter.instance.swapPrevChar();
		}
	}

	
}
