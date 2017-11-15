using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGoLeft : IActions {

	private Player p;

	public AddGoLeft(Player p){
		this.p = p;
	}

	public override void execute(){
		float hDirection = Input.GetAxisRaw ("Horizontal");
		if (hDirection < 0) {
			Vector3 velocity = new Vector3 (hDirection, 0, 0);
			velocity *=  this.p.speed* Time.deltaTime;
			this.p.transform.position += velocity;
		}
	}
}
