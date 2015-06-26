using UnityEngine;
using System.Collections;

/* 			PlayerControls
 * ------------------------------------------
 * PlayerControls manages control of the currently controlled
 * character.
 * 
 * unless an InputManagerBase object is specified, the 
 * script will call the Singleton accessor for 
 * InputManager.
 * 
 * In order to use alternative input, simply
 * drag the object with an inputmanager base
 * onto the input field in the inspector 
 * ------------------------------------------*/

public class PlayerControls : MonoBehaviour {


	public InputManagerBase input;

	MoveSideways ms;
	Jump jump;
	FastFall ff;


	/*			Unity Functions
	 * ----------------------------------------*/

	void Start () {
		if (!input) input = InputManager.get;

		ms = GetComponent<MoveSideways>();
		jump = GetComponent<Jump>();
		ff = GetComponent<FastFall>();
	}
	
	void Update () {
		if (ms) handle_movement_input();
		if (jump) handle_jump_input();
		if (ff) handle_fast_fall_input();
		handle_swap_character_input();
	}


	/*			Helpers
	 * -------------------------------------*/

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
		else ff.no_faster_fall();
	}

	void handle_swap_character_input(){
		if (RespawnMGR.instance.is_respawning()) return;
		if (input.swap_next_down()) {
			SwapCharacter.instance.swapNextChar();
			DimensionMGR.instance.swap_dimension();
		}
		if (input.swap_prev_down()){
			SwapCharacter.instance.swapPrevChar();
			DimensionMGR.instance.swap_dimension();
		}
	}

	
}
