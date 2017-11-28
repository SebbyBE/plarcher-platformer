﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftComponent: MonoBehaviour {
	void Update(){
		float hDirection = Input.GetAxisRaw ("Horizontal");
		if (hDirection < 0) {
			Vector3 velocity = new Vector3 (hDirection, 0, 0);
			velocity *=  Player.INSTANCE.speed* Time.deltaTime;
			Player.INSTANCE.transform.position += velocity;
			if (Player.INSTANCE.lookRight) {
				Player.INSTANCE.transform.Rotate (Vector3.up * -180,Space.World);
				Player.INSTANCE.lookRight = false;
			}
		}
	}
}