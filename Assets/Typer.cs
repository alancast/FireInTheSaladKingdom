using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Typer : MonoBehaviour {

	/* The typer has a single public function set_text(string)
	 * 
	 * When a user calls set text, the Typer will start a 
	 * Coroutine to "type" the text to the Text element on
	 * this GameObject */

	/* Tuning Parameters */
	public float pause_between_characters = .1f;

	string text_to_type;
	Queue<string> text_queue = new Queue<string>();

	// Typing lock for joining
	public bool typing_locked = false;

	Text text;

	void Awake(){ text = GetComponent<Text>(); }

	public void set_text(string new_text, float start_delay = 0f){
		StartCoroutine(perform_set_text(new_text, start_delay));
	}

	IEnumerator perform_set_text(string new_text, float start_delay){
		while(typing_locked) yield return null;
		typing_locked = true;
		yield return new WaitForSeconds(start_delay);
		new_text = add_newlines(new_text);
		text_to_type = new_text;
		text.text = "";
		StartCoroutine(type_text());
	}

	public void add_text(string additional_text){
		additional_text = add_newlines(additional_text);
		if (text_to_type == ""){
			text_to_type = additional_text;
			StartCoroutine(type_text());
		}
		else text_queue.Enqueue(additional_text);
	}

	IEnumerator type_text(){
		for (int i = 0; i < text_to_type.Length; ++i){
			string current_text = text.text;
			current_text += text_to_type[i];
			text.text = current_text;
			yield return new WaitForSeconds(pause_between_characters);
		}
		if (text_queue.Count == 0) text_to_type = "";
		else {
			text_to_type = text_queue.Dequeue();
			StartCoroutine(type_text());
		}

		typing_locked = false;
	}

	public int chars_per_line = 52;
	string add_newlines(string str){
		string new_str = "";
		int chars_this_line = 0;
		for (int i = 0; i < str.Length; ++i){
			if (str[i] == '\n') chars_this_line = 0;
			if (chars_this_line >= chars_per_line){
				new_str += "\n>>>";
				chars_this_line = 3;
			}
			++chars_this_line;
			
			new_str += str[i];
		}
		return new_str;
	}

}
