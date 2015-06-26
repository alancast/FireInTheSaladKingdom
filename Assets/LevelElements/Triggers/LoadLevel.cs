using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour {

	public string scene_name;

	void OnTriggerEnter(){
		Fader.instance.fade_out_to_scene(scene_name);
	}
}
