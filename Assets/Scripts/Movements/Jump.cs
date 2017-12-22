using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump: MonoBehaviour {

	private GameObject Boost;
	private bool canJump = true;

	void Start(){
		Player.INSTANCE.Talk ("I should press\nthe space bar to jump !");
	}
	void Update(){
		if(Input.GetButtonDown("Jump") && (Player.INSTANCE.isGrounded || Player.INSTANCE.isClimbing) && canJump){
			Player.INSTANCE.rigidBody.AddForce (Vector3.up * Player.INSTANCE.jumpStrength, ForceMode2D.Impulse);
			Boost = Instantiate(Resources.Load("Prefabs/Cloud"), transform.position, transform.rotation) as GameObject;
			canJump = false;
		}
		if (Input.GetButtonUp ("Jump")) {
			canJump = true;
		}
	}
}
