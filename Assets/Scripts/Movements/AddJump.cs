using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddJump : IActions {

	public override bool Jump (){
		if (Input.GetButtonDown ("Jump")) {
			return true;
		}
		return false;
	}
}
