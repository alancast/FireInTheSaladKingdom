using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SwapCharacter : MonoBehaviour {

	public static SwapCharacter instance;

	public GameObject currentChar;
	public int currentCharIndex;
	public GameObject[] characters;
	List<GameObject> characterPool = new List<GameObject>();

	void Awake(){
		instance = this;
	}

	void Start(){
		instantiateCharacters();

		// Activate the currentcharacter
		currentCharIndex = 0;
		currentChar = characterPool[currentCharIndex];
		currentChar.SetActive(true);

		CameraMGR.instance.setNewTarget(currentChar);
		// Respawn at correct location 
		RespawnMGR.instance.respawn (currentChar);
	}

	//Instantiates every character and places them in a pool somewhere
	void instantiateCharacters(){
		for (int i = 0; i < characters.Length; ++i){
			characterPool.Add(Instantiate(characters[i]));
			characterPool[i].SetActive(false);
		}
	}

	struct phys_info {
		public MoveSideways.accel_setting accel_setting;
		public Vector3 vel;
	}

	public void swapNextChar(){
		phys_info phys = getCurrentCharPhysics();
		currentChar.SetActive(false);
		// Increment the current character index
		if (++currentCharIndex >= characters.Length) currentCharIndex = 0;
		swapChar(phys);
	}

	public void swapPrevChar(){
		phys_info phys = getCurrentCharPhysics();
		if (--currentCharIndex < 0)
			currentCharIndex = characters.Length - 1;
		swapChar(phys);
	}

	// Extract the physics information from the current character and 
	// destroy it
	phys_info getCurrentCharPhysics(){
		phys_info phys;
		phys.accel_setting = currentChar.GetComponent<MoveSideways>().get_acceleration();
		phys.vel = currentChar.GetComponent<Rigidbody>().velocity;
		return phys;
	}

	void swapChar(phys_info phys){
		// Set the next character's position and rotation
		characterPool[currentCharIndex].transform.position = currentChar.transform.position;
		characterPool[currentCharIndex].transform.rotation = currentChar.transform.rotation;
		currentChar = characterPool[currentCharIndex];
		currentChar.SetActive(true);

		// Assign accel and vel to new character 
		currentChar.GetComponent<Rigidbody>().velocity = phys.vel;
		MoveSideways new_ms = currentChar.GetComponent<MoveSideways>();
		new_ms.set_acceleration(phys.accel_setting);
		CameraMGR.instance.setNewTarget(currentChar);
	}


}
