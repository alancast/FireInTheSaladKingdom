using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


/* 			Typer
 * -----------------------------------------------------------
 * Typer is a class attached to UI text objects
 * that allows the text to be "typed" out rather than 
 * instantly appear all at the same time
 * 
 * Typer provides three public functions:
 * 	
 * set_text(string text, float<optional> start_delay) sets the
 * 	text that the typer will begin typing
 * 	if the typer is currently busy, the call will wait on 
 * 	a 'thread' until the typer has finished its typing.
 * 	Each time that a new text is set, the old text is cleared
 * 
 * add_text(string text, float<optional> start_delay) adds 
 * 	text to a queue so that once the typer has finished typing,
 * 	it will type the additional text at the end of the current text.
 * 	unlike set_text, add_text does not erase the existing text
 * 
 * is_typing() 
 * 	returns true if the typer is currently typing something
 * 	returns false otherwise
 * 	
 * Typing text markup:
 * 	The back tick will add a 1 second wait in the middle of the 
 * 	text. So "Bob` Gross" would type Bob, wait one second, then type Gross
 * 
 * CAVEAT: Although Typer handles some multi-threaded style interactions
 * it is not intended to handle race conditions, and no behavior is
 * guaranteed when more than 1 set_text calls is placed in a single update frame
 * -----------------------------------------------------------*/

public class Typer : MonoBehaviour {

	/* 			Public Methods
	 * ---------------------------------------------------------*/

	public bool is_typing(){
		return typing_locked;
	}

	public void set_text(string new_text, float start_delay = 0f){
		StartCoroutine(perform_set_text(new_text, start_delay));
	}
	
	public void add_text(string additional_text){
		if (text_to_type == ""){
			text_to_type = additional_text;
			StartCoroutine(type_text());
		}
		else text_queue.Enqueue(additional_text);
	}

	/* 				Helper Functions
	 * ------------------------------------------------------------*/

	/* perform_set_text allows for waiting on the "lock" */
	IEnumerator perform_set_text(string new_text, float start_delay){
		while(typing_locked) yield return null;
		typing_locked = true;
		yield return new WaitForSeconds(start_delay);
		text_to_type = new_text;
		text.text = "";
		StartCoroutine(type_text());
	}
	
	IEnumerator type_text(){
		typing_locked = true; // We relock here to cover additions
		for (int i = 0; i < text_to_type.Length; ++i){
			if (text_to_type[i] == '`'){ // Add in second-long pauses
				yield return new WaitForSeconds(1);
				continue;
			}
			string current_text = text.text;
			current_text += text_to_type[i];
			text.text = current_text;
			yield return new WaitForSeconds(pause_between_characters);
		}
		queue_next_text();
	}

	void queue_next_text(){
		if (text_queue.Count == 0){
			text_to_type = "";
			typing_locked = false;
			return;
		}
		text_to_type = text_queue.Dequeue();
		StartCoroutine(type_text());
	}



	/* 				Members
	 * --------------------------------------------*/

	/* Tuning Parameters */
	public float pause_between_characters = .1f;
	public int chars_per_line = 42;
	
	// Keep track of te
	string text_to_type;
	Queue<string> text_queue = new Queue<string>();

	// Typing 'lock'
	bool typing_locked = false;

	// Convinient Access
	Text text;

	/* 			Unity Functions 
	 * ------------------------------------------------*/
	void Awake(){ text = GetComponent<Text>(); }
	







}
