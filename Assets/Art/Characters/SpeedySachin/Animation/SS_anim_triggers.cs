using UnityEngine;
using System.Collections;

public class SS_anim_triggers : MonoBehaviour {
	
	Animator anim;
	Rigidbody rigid;
	
	public float sneeze_speed = .2f;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		rigid = GetComponentInParent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (rigid.velocity.magnitude > sneeze_speed) anim.SetBool("Moving", true);
		else anim.SetBool("Moving", false);
	}
}
