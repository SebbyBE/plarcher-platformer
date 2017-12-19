using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftComponent: MonoBehaviour {


	void Start(){
		Player.INSTANCE.Talk ("I think I can go right\nby pressing the left arrow.\nLet's try !");
	}
	void Update(){
		float hDirection = Input.GetAxisRaw ("Horizontal");
		if (hDirection < 0) {
			Vector3 velocity = new Vector3 (hDirection, 0, 0);
			velocity *=  Player.INSTANCE.speed* Time.deltaTime;
			Player.INSTANCE.transform.position += velocity;
			if (Player.INSTANCE.lookRight) {
				Player.INSTANCE.Flip ();
			}
		}
	}
}
