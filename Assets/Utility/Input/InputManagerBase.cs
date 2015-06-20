using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public abstract class InputManagerBase : MonoBehaviour {

	public abstract bool reset();
	public abstract bool action();
	public abstract bool action_down();
	public abstract bool swap_next_down();
	public abstract bool swap_prev_down();
	public abstract bool forward();
	public abstract bool backward();
}

