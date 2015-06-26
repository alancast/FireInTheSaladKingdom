using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fader : MonoBehaviour {

	public static Fader instance;
	public float out_speed;
	public float in_speed;
	public float delay;

	void Awake(){
		RectTransform rect = GetComponent<RectTransform>();
		rect.anchorMin = Vector2.zero;
		rect.anchorMax = Vector2.one;
		rect.sizeDelta = Vector2.zero;
		instance = this;

	}
	
	public void fade_out_and_in(){
		Image img = GetComponent<Image>();
		img.CrossFadeAlpha(1f, out_speed, false);
		Invoke("fade_in", delay + delay);
	}

	public void fade_out_to_scene(string scene_name){
		Image img = GetComponent<Image>();
		img.CrossFadeAlpha(1f, out_speed, false);
		StartCoroutine(load_scene_after_fade(scene_name));
	}

	IEnumerator load_scene_after_fade(string scene_name){
		yield return new WaitForSeconds(out_speed);
		Application.LoadLevel(scene_name);
	}

	public void fade_in(){
		Image img = GetComponent<Image>();
		img.CrossFadeAlpha(0f, in_speed, false);
	}



}
