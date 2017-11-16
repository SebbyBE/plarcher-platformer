using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingLadders : MonoBehaviour {

	private bool canClimb = false;
	private float gravity = 12000f;

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Ladder") {
			canClimb = true;
			gravity = Player.INSTANCE.rigidBody.gravityScale;
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.tag == "Ladder") {
			canClimb = false;
			if (gravity != 12000f) {
				Player.INSTANCE.rigidBody.gravityScale = gravity;
				gravity = 12000f;
			}
		}
	}

	void FixedUpdate(){
		if (canClimb) {
			float vDirection = Input.GetAxisRaw ("Vertical");
			Vector3 velocity;
			if (vDirection != 0) {
				Player.INSTANCE.rigidBody.gravityScale = 0f;
				if (vDirection < 0) {
					if (!Player.INSTANCE.isGrounded) {
						velocity = new Vector3 (0, vDirection, 0);
						velocity *= Player.INSTANCE.speed * Time.deltaTime;
						Player.INSTANCE.transform.position += velocity;
					}
				} else {
					velocity = new Vector3 (0, vDirection, 0);
					velocity *= Player.INSTANCE.speed * Time.deltaTime;
					Player.INSTANCE.transform.position += velocity;
				}
			} 
		}
	}
}
