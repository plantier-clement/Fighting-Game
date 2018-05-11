using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {


	public float Horizontal;
	public bool Jump;
	public bool Crouch;
	public bool LightAttack;

	public bool Pause;

	
	// Update is called once per frame
	void Update () {

		Horizontal = Input.GetAxis ("Horizontal");
		Jump = Input.GetButtonDown ("Jump");
		Crouch = Input.GetButtonDown ("Crouch");

		LightAttack = Input.GetButtonDown ("LightAttack");
		Pause = Input.GetButtonDown ("Pause");
	}
}
