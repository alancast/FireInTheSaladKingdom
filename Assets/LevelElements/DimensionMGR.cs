using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DimensionMGR : MonoBehaviour {

	/* This is a singleton class */
	public static DimensionMGR instance;
	public void Awake(){ instance = this; }

	/* Dimension_controlled_objects register themselves with this manager */
	public List<DimensionControlled> dimension_controlled_objects = new List<DimensionControlled>();
	public void register(DimensionControlled obj) {
		dimension_controlled_objects.Add(obj);	}

	public void swap_dimension(){
		foreach(DimensionControlled obj in dimension_controlled_objects){
			obj.swap_dimension();
		}
	}

}
