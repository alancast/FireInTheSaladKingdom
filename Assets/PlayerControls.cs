using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

	MoveSideways ms;
	Jump jump;
	FastFall ff;

	// Use this for initialization
	void Start () {
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
		if (InputManager.get.backward())
			ms.set_acceleration(MoveSideways.accel_setting.BACKWARD);
		if (InputManager.get.forward())
			ms.set_acceleration(MoveSideways.accel_setting.FORWARD);
		if (!InputManager.get.forward() && !InputManager.get.backward()) 
			ms.set_acceleration(MoveSideways.accel_setting.STOP);
	}

	void handle_jump_input(){
		if (InputManager.get.action_down()) jump.jump();
	}

	void handle_fast_fall_input(){
		if (InputManager.get.action()) ff.faster_fall();
	}

	void handle_swap_character_input(){
		if (InputManager.get.swap_next_down()) {
			SwapCharacter.instance.swapNextChar();
		}
		if (InputManager.get.swap_prev_down()){
			SwapCharacter.instance.swapPrevChar();
		}
	}

	
}
