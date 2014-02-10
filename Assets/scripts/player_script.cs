using UnityEngine;
using System.Collections;

public class player_script : MonoBehaviour {
	float speed = 20f;
	float jumpSpeed = 300f;
	float gravity = 20f;
	float rotateSpeed = 5;
	Vector3 moveDirection;
	int jumpTurns = 15;
	// Update is called once per frame
	void Update () {
		CharacterController ctrl = GetComponent<CharacterController>();
		
		
		if(Input.GetKey(KeyCode.W)) {
			moveDirection = transform.forward * speed * Time.deltaTime;
		}
		
		if(Input.GetKey(KeyCode.A)) {
			ctrl.transform.Rotate(0, -rotateSpeed, 0);
		}
		
		if(Input.GetKey(KeyCode.S)) {
			moveDirection = transform.forward * -speed * Time.deltaTime;
		}
		
		if(Input.GetKey(KeyCode.D)) {
			ctrl.transform.Rotate(0,rotateSpeed,0);
		}
		
		if(Input.GetKey(KeyCode.Space) && ctrl.isGrounded) {	
			jumpTurns = 15;
		}
		
		if(jumpTurns > 0) {
			moveDirection.y = jumpSpeed/(16 - jumpTurns);
			moveDirection.y *= Time.deltaTime;
			jumpTurns--;
		}
		
		moveDirection.y -= gravity * Time.deltaTime;
		ctrl.Move(moveDirection);
		moveDirection.z = 0;
		moveDirection.x = 0;
	}
}
