using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCoin : MonoBehaviour {

	public bool removeCoin(int amount){
		if ((Player.INSTANCE.coins - amount) < 0) {
			return false;
		} else {
			Player.INSTANCE.coins -= amount;
			return true;
		}
	}
}
