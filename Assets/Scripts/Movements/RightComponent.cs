using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightComponent : MonoBehaviour {
	void Update(){
		float hDirection = Input.GetAxisRaw ("Horizontal");
		Player.INSTANCE.anim.SetFloat ("Speed", Mathf.Abs (hDirection));
		if (!Player.INSTANCE.isInvincible && hDirection > 0) {
			Vector3 velocity = new Vector3 (hDirection, 0, 0);
			velocity *=  Player.INSTANCE.speed * Time.deltaTime;
			transform.position += velocity;
			if (!Player.INSTANCE.lookRight) {
				Player.INSTANCE.Flip ();
			}
		}
	}
}
