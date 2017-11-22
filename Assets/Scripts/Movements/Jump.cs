using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump: MonoBehaviour {
	void Update(){
		if(Input.GetButtonDown("Jump") && (Player.INSTANCE.isGrounded || Player.INSTANCE.isClimbing)){
			Player.INSTANCE.rigidBody.AddForce (Vector3.up * Player.INSTANCE.jumpStrength, ForceMode2D.Impulse);
		}
	}
}
