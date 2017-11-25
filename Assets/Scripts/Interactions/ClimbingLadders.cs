using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingLadders : MonoBehaviour {

	public bool canClimb = false;
	private float gravity = 1f;

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Ladder") {
			canClimb = true;
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.tag == "Ladder") {
			canClimb = false;
			gameObject.GetComponent<Rigidbody2D>().gravityScale = gravity;

			Player.INSTANCE.isClimbing = false;
		}
	}

	void FixedUpdate(){
		if (canClimb) {
			float vDirection = Input.GetAxisRaw ("Vertical");
			Vector3 velocity;
			if (vDirection != 0) {
				Player.INSTANCE.rigidBody.gravityScale = 0f;
				Player.INSTANCE.isClimbing = true;
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
		} else {
			Player.INSTANCE.rigidBody.gravityScale = gravity;
			Player.INSTANCE.isClimbing = false;
		}
	}
}
