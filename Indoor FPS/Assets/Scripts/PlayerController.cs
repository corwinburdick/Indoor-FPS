using UnityEngine;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour {

	public bool yAxisInverted;

	public float movementSpeed;
	public float mouseSensitivityHorizontal;
	public float mouseSensitivityVertical;

	public Camera camera;

	private int yAxisInvert;

	//private Rigidbody rb;
	private CharacterController cc;

	void Start() {
		//rb = GetComponent<Rigidbody>();
		cc = GetComponent<CharacterController>();
		if(yAxisInverted) {
			yAxisInvert = -1;
		} else {
			yAxisInvert = 1;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		bool diagonal = (moveHorizontal != 0 && moveVertical != 0);

		int horizontalDir = Math.Sign(moveHorizontal);
		int verticalDir = Math.Sign(moveVertical);

		Vector3 movement = horizontalDir * transform.right + verticalDir * transform.forward;

		if(!diagonal) {
			movement = movement * (float)(Math.Sqrt(2));
		}

		//transform.Translate(movement * Time.deltaTime * movementSpeed);
		//rb.AddRelativeForce(movement * Time.deltaTime * movementSpeed);
		cc.SimpleMove(movement * movementSpeed);
		//player has moved
	}

	void LateUpdate() {

		float lookHorizontal = Input.GetAxis("Mouse X");
		float lookVertical = Input.GetAxis("Mouse Y");

		transform.Rotate(0,lookHorizontal*mouseSensitivityHorizontal,0);

		camera.transform.Rotate(lookVertical*mouseSensitivityVertical*yAxisInvert, 0, 0);
	}
}
