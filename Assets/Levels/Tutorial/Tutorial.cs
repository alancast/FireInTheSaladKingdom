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
		DIMENSION_USE,
		DEATH
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
	public GameObject dimension_kill_trick;

	public GameObject dimension_particles; // Turn on at beginning of DEATH phase


	/* 			Unity Functions
	 * ----------------------------------*/
	
	void Awake(){
		text = GetComponent<Text>();
		typer = GetComponent<Typer>();
		text.text = ">_";
	}

	void Start(){
		current_phase = ePhase.MOVEMENT;
		current_status = eStatus.START;

		// Disable inputs that aren't ready yet
		InputManager.get.disable_input("swap_next_down");
		InputManager.get.disable_input("action");
		InputManager.get.disable_input("action_down");
		//Initialize function maps
		start_funcs[ePhase.MOVEMENT] = start_movement;
		update_funcs[ePhase.MOVEMENT] = update_movement;
		start_funcs[ePhase.JUMP] = start_jump;
		update_funcs[ePhase.JUMP] = update_jump;
		start_funcs[ePhase.DIMENSION] = start_dimension;
		update_funcs[ePhase.DIMENSION] = update_dimension;
		start_funcs[ePhase.DIMENSION_USE] = start_dimension_use;
		update_funcs[ePhase.DIMENSION_USE] = update_dimension_use;
		start_funcs[ePhase.DEATH] = start_death;
		update_funcs[ePhase.DEATH] = update_death;
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
		typer.set_text(">>>Greetings Sachin, whom they call the\n" +
		               "Speedy One.\n" +
		               ">>>Welcome to your worst nightmare.\n" +
		               ">>>You have 10 seconds. Use the arrow keys\n" +
		               "to escape your doom.\n", 2f);
	}

	void update_movement(){
		if (GameObject.Find("mvmtTrigger")) return;
		switch_to(ePhase.JUMP);
	}

	void start_jump(){
		typer.set_text (">>>Yeah, I was just kidding about that\n" +
		                "back there. I can be a bit theatrical.\n" +
		                ">>>I’m Operation Queequeg, a benevolent,\n" +
		                "hyper-intelligent, trans-dimensional AI\n" +
		                ">>>Oh, sorry, I forgot my manners. You’re\n" +
		                "a baby carrot, so maybe I shouldn’t be\n" +
		                "using words like that. Basically I’m a\n" +
		                "smart computer who’s here to help you\n" +
		                ">>>Use the space bar to try to jump your\n" +
		                "way out of here",2f);
		jumpTrigger.SetActive(true);
		StartCoroutine(delay_jump_start());
	}

	IEnumerator delay_jump_start(){
		while (typer.is_typing()) yield return null;
		InputManager.get.enable_input("action");
		InputManager.get.enable_input("action_down");
	}

	void update_jump(){
		if (GameObject.Find("jumpTrigger")) return;
		switch_to(ePhase.DIMENSION);
	}

	void start_dimension(){
		typer.set_text (">>>Hahahahahahahahahahahahahaha; classic.\n" +
		                ">>>Did you really think you could jump\n" +
		                "over the walls? You absolutely slay me.\n" +
		                ">>>OK, sorry. I’ll help for real now.\n" +
		                ">>>Let me explain. Grey Matter, LLC made\n" +
		                "me to solve problems in my dimension, but\n" +
		                "they’ve pivoted a bit, and now they’re\n" +
		                "capturing fruit & veggie people to make\n" +
		                "grey matter, an alternative food source\n" +
		                ">>>Hit those sparkles when you’re ready\n", 2f);
		StartCoroutine(add_dimension_triggers());
	}

	IEnumerator add_dimension_triggers(){
		// Spin every second until the text is done displaying 
		while (typer.is_typing()){
			yield return new WaitForSeconds(1);
		}
		dimensionTrigger.SetActive(true);
		dimension_trigger_activated = true;
		yield return null;
	}

	void update_dimension(){
		if (!dimension_trigger_activated) return;
		if (GameObject.Find("dimensionTrigger")) return;
		switch_to(ePhase.DIMENSION_USE);
	}

	void start_dimension_use(){
		typer.set_text (">>>Alright, in order to get out of here,\n" +
		                "you’ll have to focus all of your energy\n" +
		                "and connect to ANOTHER DIMENSION!\n" +
		                ">>>Just hit ‘D’ any time you want to\n" +
		                "switch between dimensions\n");
		dimension_switched = false;
		StartCoroutine(enable_dimension_change());
	}

	IEnumerator enable_dimension_change(){
		while (typer.is_typing()){ 
			yield return new WaitForSeconds(.5f);
		}
		InputManager.get.enable_input("swap_next_down");
		yield return null;
	}
	
	void update_dimension_use(){

		if (!dimension_switched && InputManager.get.swap_next_down()){
			typer.add_text(">>>Meet Becky. Becky, Sachin\n" +
						   "Sachin, Becky.\n" +
			               ">>>You can get caught up later, but just,`\n" +
			               "uh,` roll around switching dimensions while\n" +
			               "I figure a few more things out.\n");
			dimension_kill_trick.SetActive(true);
			dimension_switched = true;
		}
		if (dimension_switched && RespawnMGR.instance.is_respawning()){
			print ("Switching");
			switch_to(ePhase.DEATH);
		}
	}

	void start_death(){
		dimension_kill_trick.SetActive(true);
		Destroy(dimension_kill_trick, Fader.instance.delay);
		dimension_particles.SetActive(true);
		typer.set_text (">>>Shoot! I forgot to carry a 1 somewhere.\n" +
		                ">>>I would apologize, but I’m executing\n" +
		                "trans-dimensional code at 32.5 exaflops so\n" +
		                "please excuse the occasional mistake.\n" +
		                ">>>You’re just going to have to avoid\n" +
		                "switching dimensions into solid things\n" +
		                ">>>I’ll help you out by marking areas with\n" +
		                "sparkles if there’s a solid in another\n" +
		                "dimension. OK. Enough talk, go find the\n" +
		                "door and get out of here.");
	}
	

	void update_death(){

	}

}
