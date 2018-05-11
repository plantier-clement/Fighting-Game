using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour {

	InputController playerInput;
	Animator playerAnimator;

	public bool IsPlayerOne;

	public float Health = 10.0f;
	public float MoveSpeed = 10.0f;
	public float JumpHeight = 7.0f;


	[Header("Debug")]
	public bool CheckFloor;
	public bool IsOnFloor;
	public bool ControlledByPlayer;


	private CharacterController m_CharacterController;
	public CharacterController CharacterController {
		get { 
			if (m_CharacterController == null)
				m_CharacterController = GetComponent <CharacterController> ();
			return m_CharacterController;
		}
	}



	IEnumerator WaitAndEnableCheckFloor(float delay)
	{
		yield return new WaitForSeconds(delay);
		CheckFloor = true;
	}

	void Awake ()
	{
		CheckFloor = true;
		IsOnFloor = true;
		playerAnimator = GetComponent <Animator> ();
		playerInput = GameManager.Instance.InputController;
	}




	void Update() {
		
		if (ControlledByPlayer) {



		}	
	}

	/*
	public void Jump()
	{
		Vector3 velocityWithoutY = new Vector3(characterRigidbody.velocity.x, 0, characterRigidbody.velocity.z);
		characterRigidbody.velocity = velocityWithoutY + Vector3.up * JumpHeight;
	}


	if (playerInput.Jump && IsOnFloor) {
				// jump
				playerAnimator.SetTrigger("Jump");
				CheckFloor = false;
				IsOnFloor = false;
				playerAnimator.SetBool("IsOnGround", IsOnFloor);
				StartCoroutine(WaitAndEnableCheckFloor(0.4f));
			}
			if (playerInput.LightAttack) {
				// attack
				playerAnimator.SetTrigger("RightPunch");
			}
	
		}

		if (CheckFloor)	{
			Ray groundRay = new Ray(transform.position, -Vector3.up);
			RaycastHit hit;
			if (Physics.Raycast(groundRay, out hit, 1.2f) && (hit.collider.tag.Equals("Ground") || hit.collider.tag.Equals("Player")))
			{
				IsOnFloor = true;
			}
			else
			{
				IsOnFloor = false;
			}
			playerAnimator.SetBool("IsOnGround", IsOnFloor);
		}

*/
	// pos += velo * delta time
	// vel += acc * delta time


	// pos += vel * delta + .5 acc * delta * delta
	// vel += acc * delta time




}
