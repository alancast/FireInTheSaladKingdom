using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

/* 				Tutorial
 * ---------------------------------------
 * 
 * This script manages the flow of the tutorial level
 * Each phase is listed in the ePhase enum. 
 * 
 * Each phase has a start status and an end status.
 * During the start status, the console will output
 * some message. During the update status, the game will
 * wait until some condition is met. Once the condition is met,
 * the game will transition to the next phase 
 * 
 * ------------------------------------------*/

public class Tutorial : MonoBehaviour {
	
	/* 			Type Declarations 
	 * -------------------------------------*/
	enum eStatus {
		START,
		UPDATE
	}
	
	enum ePhase {
		MOVEMENT,
		JUMP,
		DIMENSION,
		DIMENSION_USE
	}

	/* 				Members 
	 * ------------------------------------*/

	// References to other components
	Text text;
	Typer typer;

	// Enums to track the current phase and status
	eStatus current_status;
	ePhase current_phase;

	// Function maps from phase to member function
	delegate void MemberFunction();
	Dictionary<ePhase, MemberFunction> start_funcs = new Dictionary<ePhase, MemberFunction>();
	Dictionary<ePhase, MemberFunction> update_funcs = new Dictionary<ePhase, MemberFunction>();
	
	// Members for specific phases
	public GameObject jumpTrigger;
	public GameObject dimensionTrigger;
	bool dimension_trigger_activated = false;
	bool dimension_switched = false;


	/* 			Unity Functions
	 * ----------------------------------*/
	
	void Awake(){
		text = GetComponent<Text>();
		typer = GetComponent<Typer>();
		text.text = ">_";
	}

	void Start(){
		current_phase = ePhase.DIMENSION;
		current_status = eStatus.START;

		//Initialize function maps
		start_funcs[ePhase.MOVEMENT] = start_movement;
		update_funcs[ePhase.MOVEMENT] = update_movement;
		start_funcs[ePhase.JUMP] = start_jump;
		update_funcs[ePhase.JUMP] = update_jump;
		start_funcs[ePhase.DIMENSION] = start_dimension;
		update_funcs[ePhase.DIMENSION] = update_dimension;
		start_funcs[ePhase.DIMENSION_USE] = start_dimension_use;
		update_funcs[ePhase.DIMENSION_USE] = update_dimension_use;
	}

	void Update(){
		switch(current_status){
		case eStatus.START:
			start_funcs[current_phase]();
			current_status = eStatus.UPDATE;
			break;
		case eStatus.UPDATE:
			update_funcs[current_phase]();
			break;
		}

	}

	void switch_to(ePhase phase){
		current_status = eStatus.START;
		current_phase = phase;
	}

	void start_movement(){
		typer.set_text(">Hello, welcome to your worst nightmare!\n" +
					   ">Use the left and right arrow keys to try to escape!\n", 2f);

	}

	void update_movement(){
		if (GameObject.Find("mvmtTrigger")) return;
		switch_to(ePhase.JUMP);
	}

	void start_jump(){
		typer.set_text (">Yeah, I was just kidding about that back there.\n" +
		                ">I'm actually a benevolent, hyper-intelligent trans-dimensional AI.\n" +
		                ">...Oh sorry, I forgot my manners. You're a baby carrot so maybe I shouldn't be throwing around words like that.\n" +
		                ">Basically, I'm a smart computer and I'm here to help you!\n" +
						">I couldn't help but notice you're in an impenetrable, er...a room with no doors\n" +
		                ">Try jumping using the space bar\n",2f);
		jumpTrigger.SetActive(true);
	}

	void update_jump(){
		if (GameObject.Find("jumpTrigger")) return;
		switch_to(ePhase.DIMENSION);
	}

	void start_dimension(){
		typer.set_text (">Hey, great job jumping. OK, lots to      explain; I'm going to make this quick\n" +
		                ">I was originally created to work for    Grey Matter LLC, they started out with AI research, but now they're griding upall the fruit and veggie people from   multiple universes as a cheap food       alternative (talk about a pivot)\n" +
		                ">Anyway, you have a direct connection to certain people in other Universes, and that's how we'll get you out of here\n" +
		                ">(Head to the right when you're ready)", 2f);
		StartCoroutine(add_dimension_explanation());
	}

	IEnumerator add_dimension_explanation(){
		yield return new WaitForSeconds(10);
		dimensionTrigger.SetActive(true);
		dimension_trigger_activated = true;
		yield return null;
	}

	void update_dimension(){
		if (!dimension_trigger_activated) return;
		if (dimensionTrigger) return;
		switch_to(ePhase.DIMENSION_USE);
	}

	void start_dimension_use(){
		typer.set_text (">So, it took me a lot of work, because I don't exist in the physical world and all that, but I try to put those sparklies in places where the other dimension you're connected to is different from yours\n" +
		                ">If you hit the 'D' key, you'll switch dimensions\n");

	}
	
	void update_dimension_use(){

		if (!dimension_switched && InputManager.get.swap_next_down()){
			typer.add_text(">This is Becky. Becky, Sachin; Sachin, Becky\n" +
				">You'll have a lot more time to get accustomed to one another, but for now, let's get out of here.\n" +
				">If you get stuck, just try switching dimensions!\n");

		}
	}


}
