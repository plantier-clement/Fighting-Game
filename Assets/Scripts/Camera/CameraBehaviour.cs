using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

    public Transform playerOne;
	public Transform playerTwo;

	public float cameraDepth = -20f; 
	public float cameraHeight = 3f; 

	void Awake () {


	}
	
	void LateUpdate () {
		
		this.transform.position = ((playerOne.position + playerTwo.position) * .5f) + Vector3.forward * (cameraDepth) + Vector3.up * (cameraHeight);

    }
}
