using UnityEngine;
using System.Collections;

public class ThankYou : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Fader.instance.fade_in();
		GetComponent<Typer>().set_text(">Thank you for playing!\n" +
		                               ">Unfortunately, the rest of the \n" +
		                               ">game lies in a dimension beyond\n" +
		                               ">your  human understanding\n" +
		                               ">The creators are still working \n" +
		                               ">though, so it may be within your\n" +
		                               ">reach quite soon!");
	}

	void Update(){
		if (Time.frameCount % 150 == 0) Fader.instance.fade_out_and_in();
	}

}
