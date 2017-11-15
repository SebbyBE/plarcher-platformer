using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddJump : IActions {

	private Player p;

	public AddJump(Player p){
		this.p = p;	
	}

	public override void execute(){
		if(Input.GetButtonDown("Jump") && this.p.isGrounded){
			this.p.rigidBody.AddForce (Vector3.up * this.p.jumpStrength, ForceMode2D.Impulse);
		}
	}
}
