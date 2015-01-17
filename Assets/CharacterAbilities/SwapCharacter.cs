using UnityEngine;
using System.Collections;

public class SwapCharacter : MonoBehaviour {

	public GameObject currentChar;
	public int currentCharIndex;
	public GameObject[] characters;

	void Start(){
		currentCharIndex = -1;
	}
	
	// Update is called once per frame
	void Update () {
		if (InputManager.get.swap_next_down()) {
			swapNextChar();
		}
		if (InputManager.get.swap_prev_down()){
			swapPrevChar();
		}
	}

	struct phys_info {
		public float accel;
		public Vector3 vel;
	}

	void swapNextChar(){
		phys_info phys = getCurrentCharPhysics();
		if (++currentCharIndex >= characters.Length)
			currentCharIndex = 0;
		swapChar(phys);
	}

	void swapPrevChar(){
		phys_info phys = getCurrentCharPhysics();
		if (--currentCharIndex < 0)
			currentCharIndex = characters.Length - 1;
		swapChar(phys);
	}

	// Extract the physics information from the current character and 
	// destroy it
	phys_info getCurrentCharPhysics(){
		phys_info phys;
		phys.accel = currentChar.GetComponent<MoveSideways>().acceleration;
		phys.vel = currentChar.rigidbody.velocity;
		Destroy(currentChar);
		return phys;
	}

	void swapChar(phys_info phys){
		// Destroy old character, create new one
		currentChar = Instantiate(characters[currentCharIndex], 
		                          currentChar.transform.position, currentChar.transform.rotation) as GameObject;
		// Assign accel and vel to new character 
		currentChar.rigidbody.velocity = phys.vel;
		MoveSideways new_ms = currentChar.GetComponent<MoveSideways>();
		new_ms.acceleration = phys.accel;
		CameraMGR.instance.setNewTarget(currentChar);
	}


}
