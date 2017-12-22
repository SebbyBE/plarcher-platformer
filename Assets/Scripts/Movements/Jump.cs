using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump: MonoBehaviour {

	private bool canJump = true;

	void Start(){
		Player.INSTANCE.Talk ("I should press\nthe space bar to jump !");
	}
	void Update(){
		print (canJump);
		if(Input.GetButtonDown("Jump") && (Player.INSTANCE.isGrounded || Player.INSTANCE.isClimbing) && canJump){
			Player.INSTANCE.rigidBody.AddForce (Vector3.up * Player.INSTANCE.jumpStrength, ForceMode2D.Impulse);
			canJump = false;
		}
		if (Input.GetButtonUp ("Jump")) {
			canJump = true;
		}
	}
}
