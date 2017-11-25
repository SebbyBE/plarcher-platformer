using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCoin : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Coin") {
			Player.INSTANCE.AddCoin ();
			Destroy (col.transform.parent.gameObject);
		}
	}
}
