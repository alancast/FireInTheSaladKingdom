using UnityEngine;
using System.Collections;


/* 				DimensionControlled
 * ------------------------------------------
 * 
 * DimensionControlled is a script to add on to 
 * a parent object which has both an object for 
 * two different dimensions
 * 
 * The public member function swap_dimension() 
 * deactivates the currently active dimensional objects
 * and activate the currently unactive dimensional objects
 * 
 * -------------------------------------------*/


public class DimensionControlled : MonoBehaviour {

	public GameObject[] dimensions;
	
	int current_dimension;


	/* 				Unity Functions  
	 * -----------------------------------------------*/

	void Start(){
		DimensionMGR.instance.register(this);
		current_dimension = DimensionMGR.instance.get_global_dimension();
		toggle_dimension();
	}

	void OnDestroy(){
		DimensionMGR.instance.unregister(this);
	}


	/* 			Public Methods
	 * -----------------------------------------------------*/

	public void swap_dimension(int dimension_number){
		dimensions[current_dimension].SetActive(false);
		current_dimension = dimension_number;
		dimensions[current_dimension].SetActive(true);
	}

	/*			Helper

	/* Turn off objects not from the current dimension */
	void toggle_dimension(){
		for (int i = 0; i < dimensions.Length; ++i){
			dimensions[i].SetActive(false);
		}
		dimensions[current_dimension].SetActive(true);
	}

}
