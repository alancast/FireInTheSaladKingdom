using UnityEngine;
using System.Collections;

public class DimensionControlled : MonoBehaviour {

	public GameObject SS_dimension_obj;
	public GameObject BB_dimension_obj;
	
	public GameObject current;

	void Awake(){
		current = SS_dimension_obj;
		toggle_dimension();
	}

	void Start(){
		DimensionMGR.instance.register(this);
	}

	public void swap_dimension(){
		if (current == SS_dimension_obj) current = BB_dimension_obj;
		else if (current == BB_dimension_obj) current = SS_dimension_obj;
		toggle_dimension();

	}

	/* Turn off objects not from the current dimension */
	void toggle_dimension(){
		BB_dimension_obj.SetActive(false);
		SS_dimension_obj.SetActive(false);
		current.SetActive(true);
	}

}
