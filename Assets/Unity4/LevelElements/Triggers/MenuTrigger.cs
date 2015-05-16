using UnityEngine;
using System.Collections;

public class MenuTrigger : MonoBehaviour {

	public string level;

	void OnTriggerEnter()
	{
		Application.LoadLevel(level);
		print ("back to menu");
	}
}
