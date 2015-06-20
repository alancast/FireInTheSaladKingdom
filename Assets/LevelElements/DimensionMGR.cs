using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/* 				DimensionMGR
 * -----------------------------------------
 * 
 * The dimension manager is a Singleton class that manages
 * the switching of dimensions.
 * 
 * The dimension manager maintains knowledge of the
 * current 'global' dimension, and can supply it via a public function
 * 
 * When the globabl dimension switch is triggered, 
 * the dimensionMGR delegates the switching to all
 * objects that have registered (via call to "register" function)
 * by calling their swap_dimension functions
 * 
 * If an object is destroyed, it must call the "unregister"
 * function to prevent errors.
 * 
 * ------------------------------------------*/

public class DimensionMGR : MonoBehaviour {

	/*		Members
	 * ---------------------------------------*/
	public int num_dimensions;
	int current_dimension;


	/* This is a singleton class */
	public static DimensionMGR instance;
	
	/* Dimension_controlled_objects register themselves with this manager */
	public List<DimensionControlled> dimension_controlled_objects = new List<DimensionControlled>();

	/* 		Unity Functions
	 * ----------------------------------------*/

	public void Awake(){ 
		instance = this; 
		current_dimension = 0;
	}

	/*			Public Methods
	 *--------------------------------------------*/ 

	public void register(DimensionControlled obj) {
		dimension_controlled_objects.Add(obj);	
	}

	public void unregister(DimensionControlled obj){
		dimension_controlled_objects.Remove(obj);
	}

	public void swap_dimension(){
		if (++current_dimension >= num_dimensions) current_dimension = 0;
		foreach(DimensionControlled obj in dimension_controlled_objects){
			obj.swap_dimension(current_dimension);
		}
	}

	public int get_global_dimension(){
		return current_dimension;
	}

}
