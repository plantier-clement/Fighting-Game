using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{

	Rigidbody characterRigidbody;
	Animator playerAnimator;

	public bool IsPlayerOne;

    public GameObject head;
    public GameObject chest;

    public GameObject rightArm;
    public GameObject leftArm;
    public GameObject rightLeg;
    public GameObject leftLeg;

    public float Health;
    public float MoveSpeed;
    public float JumpHeight;


	[Header("Debug")]
    public bool CheckFloor;
    public bool IsOnFloor;
	public bool ControlledByPlayer;



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
		characterRigidbody = GetComponent <Rigidbody> ();
    }
		

    void Update()
    {
        if (ControlledByPlayer)
        {
            if (Input.GetButtonDown ("Jump") && IsOnFloor)
            {
                // jump
				playerAnimator.SetTrigger("Jump");
                CheckFloor = false;
                IsOnFloor = false;
				playerAnimator.SetBool("IsOnGround", IsOnFloor);
                StartCoroutine(WaitAndEnableCheckFloor(0.4f));
            }
			if (Input.GetButtonDown("LightAttack"))
            {
                // attack
				playerAnimator.SetTrigger("RightPunch");
            }

            float direction = 0;
            if (Input.GetKey(KeyCode.Q))
            {

                // left
                direction = -1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                // right
                direction = 1;
            }

		
            Vector3 velocityWithoutX = new Vector3(0, characterRigidbody.velocity.y, characterRigidbody.velocity.z);
            characterRigidbody.velocity = velocityWithoutX + MoveSpeed * Vector3.right * direction;
			playerAnimator.SetBool("Walking", (direction != 0));

			print (transform.position);
        }

        if (CheckFloor)
        {
            Ray groundRay = new Ray(rightLeg.transform.position, -Vector3.up);
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
    }

    public void Jump()
    {
        Vector3 velocityWithoutY = new Vector3(characterRigidbody.velocity.x, 0, characterRigidbody.velocity.z);
        characterRigidbody.velocity = velocityWithoutY + Vector3.up * JumpHeight;
    }

    public void RightArmStartHit()
    {
        rightArm.tag = "HitBox";
        rightArm.GetComponent<Renderer>().material.color = Color.Lerp(Color.yellow, Color.red, 0.5f);
    }
    public void RightArmStopHit()
    {
        rightArm.tag = "Player";
        rightArm.GetComponent<Renderer>().material.color = Color.white;
    }

    public void RightLegStartHit()
    {
        rightLeg.tag = "HitBox";
        rightLeg.GetComponent<Renderer>().material.color = Color.Lerp(Color.yellow, Color.red, 0.5f);
    }
    public void RightLegStopHit()
    {
        rightLeg.tag = "Player";
        rightLeg.GetComponent<Renderer>().material.color = Color.white;
    }

    public void LeftLegStartHit()
    {
        leftLeg.tag = "HitBox";
        leftLeg.GetComponent<Renderer>().material.color = Color.Lerp(Color.yellow, Color.red, 0.5f);
    }
    public void LeftLegStopHit()
    {
        leftLeg.tag = "Player";
        leftLeg.GetComponent<Renderer>().material.color = Color.white;
    }

    public void GetsHit(float damage, Vector3 otherPosition)
    {
        Health -= damage;
        characterRigidbody.AddExplosionForce(100, otherPosition, 200);
    }
}
