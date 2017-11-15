using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IActions{

	public IActions actions;

	public IActions(){
	}

	public IActions(IActions a){
		this.actions = a;
	}
		
	public virtual float GoRight () {
		return this.actions.GoRight();
	}

	public virtual float GoLeft (){
		return this.actions.GoLeft();
	}

	public virtual bool Jump (){
		return this.actions.Jump();
	}
}
