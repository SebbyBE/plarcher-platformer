using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCoin : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Coin") {
			Destroy (col.transform.parent.gameObject);
			Player.INSTANCE.AddCoin ();
		}
	}
}
