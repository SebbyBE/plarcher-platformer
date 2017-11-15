using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGoRight : IActions {

	public AddGoRight(IActions a) : base(a){}

	public override float GoRight(){
		float hDirection = Input.GetAxisRaw ("Horizontal");
		if (hDirection > 0)
			return hDirection;
		return 0f;
	}
}
