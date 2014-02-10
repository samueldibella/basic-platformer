using UnityEngine;
using System.Collections;



//script governing player movement
public class player_script : MonoBehaviour {
	//initialized vars
	float speed = 10.0f;
	float jumpSpeed = 100f;
	float rotationSpeed = 100.0f;
	float gravity = 7.5f;
	Vector3 moveDirection;
	int jumpTurns;
	int airTime;

	// Update is called once per frame
	void Update () {
	
		playerMove ();

		//if block creates jump behavior when space bar is pressed. upward force 
		//is applied, and decreases, over several moments. stores y-axis movement in
		//a Vector3
		if (GetComponent<CharacterController>().isGrounded && Input.GetKeyDown (KeyCode.Space)) {
			jumpTurns = 15;
		} else if (jumpTurns > 0) {
			moveDirection.y = (jumpSpeed/(16 - jumpTurns));
			jumpTurns--;
		}

		if (!GetComponent<CharacterController> ().isGrounded && airTime < 100) {
						airTime++;
		} else if (airTime == 30) {
			GetComponent<CharacterController> ().center = new Vector3(830.9f,56.03f,505.6494f);
		} else {
			airTime = 0;		
		}
		//applies gravity to above ^ Vector3
		moveDirection.y = moveDirection.y - gravity;
		moveDirection.y *= Time.deltaTime;
		GetComponent<CharacterController>().Move(moveDirection);
	}	
		
	//moves player from wasd input. 
	//based on code from Unity GetAxis documentation
	void playerMove() {
		// Get the horizontal and vertical axis.
		// By default they are mapped to the arrow keys.
		// The value is in the range -1 to 1
		float translation = Input.GetAxis ("Vertical") * speed;
		float rotation = Input.GetAxis ("Horizontal") * rotationSpeed;
		
		// Make it move 10 meters per second instead of 10 meters per frame...
		translation *= Time.deltaTime;
		rotation *= Time.deltaTime;
		
		// Move translation along the object's z-axis
		transform.Translate (0, 0, translation);
		// Rotate around our y-axis
		transform.Rotate (0, rotation, 0);

	}
}