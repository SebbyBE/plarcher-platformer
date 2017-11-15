using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : IActions {

	public Actions(){
		
	}

	public override float GoRight () {
		return 0f;
	}

	public override float GoLeft (){
		return 0f;
	}

	public override bool Jump (){
		return false;
	}
}
