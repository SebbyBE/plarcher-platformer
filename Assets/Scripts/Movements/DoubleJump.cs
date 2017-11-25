using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour {
	bool canDoubleJump = false;
	bool keyIsPressed = false;


	void Awake(){
		transform.gameObject.GetComponent<Jump> ().enabled = false;
	}

	void Update () {
		if(Input.GetButton("Jump")){
			if (Player.INSTANCE.isGrounded || Player.INSTANCE.isClimbing) {
				Player.INSTANCE.rigidBody.velocity = new Vector2 (Player.INSTANCE.rigidBody.velocity.x, 0);
				Player.INSTANCE.rigidBody.AddForce (Vector3.up * Player.INSTANCE.jumpStrength, ForceMode2D.Impulse);
				canDoubleJump = true;
				keyIsPressed = true;
			} else {
				if (canDoubleJump && !keyIsPressed) {
					canDoubleJump = false;
					Player.INSTANCE.rigidBody.velocity = new Vector2(Player.INSTANCE.rigidBody.velocity.x,0);
					Player.INSTANCE.rigidBody.AddForce (Vector3.up * Player.INSTANCE.jumpStrength, ForceMode2D.Impulse);
				}
			}
		}
		if(Input.GetButtonUp("Jump")){
			keyIsPressed = false;
		}
	}
}
