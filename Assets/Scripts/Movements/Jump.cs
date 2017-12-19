using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump: MonoBehaviour {


	void Start(){
		Player.INSTANCE.Talk ("I should press\nthe space bar to jump !");
	}
	void Update(){
		if(Input.GetButtonDown("Jump") && (Player.INSTANCE.isGrounded || Player.INSTANCE.isClimbing)){
			Player.INSTANCE.rigidBody.AddForce (Vector3.up * Player.INSTANCE.jumpStrength, ForceMode2D.Impulse);
		}
	}
}
