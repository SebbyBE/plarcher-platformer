using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGoLeft : IActions {

	public AddGoLeft (IActions a) : base(a){}

	public override float GoLeft(){
		float hDirection = Input.GetAxisRaw ("Horizontal");
		if (hDirection < 0)
			return hDirection;
		return 0f;
	}
}
