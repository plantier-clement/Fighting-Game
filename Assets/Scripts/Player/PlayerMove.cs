using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {


	InputController playerInput;

	private float verticalVelocity;
	private float gravity = 14.0f;
	private float jumpForce = 10.0f;


	private Player m_Player;
	public Player Player {
		get {
			if (m_Player == null)
				m_Player = GetComponent <Player> ();
			return m_Player;
		}
	}


	private CharacterController m_CharacterController;
	public CharacterController CharacterController {
		get {
			if (m_CharacterController == null)
				m_CharacterController = GetComponent <CharacterController> ();
			return m_CharacterController;
		}
	}


	void Awake () {
		playerInput = GameManager.Instance.InputController;
	}
		

	void Update () {
		// Add Player health for condition is alive
		if (GameManager.Instance.IsPaused)
			return;
		
		if (playerInput == null) {
			playerInput = GameManager.Instance.InputController;
			if (playerInput == null)
				return;
		}
		Move (playerInput.Horizontal);
	}


	public void Move (float horizontal) {
		
		float moveSpeed = Player.MoveSpeed;
		// depending on state, modify moveSpeed

		if (CharacterController.isGrounded) {

			verticalVelocity = -gravity * Time.deltaTime;
			if (playerInput.Jump) {
				verticalVelocity = jumpForce;

			} 
		}
			else 
			{
				verticalVelocity -= gravity * Time.deltaTime;

			}

		Vector3 moveVector = Vector3.zero;
		moveVector.x = horizontal * moveSpeed;
		moveVector.y = verticalVelocity;
		moveVector.z = 0;
		CharacterController.Move (moveVector * Time.deltaTime);
	}

}
