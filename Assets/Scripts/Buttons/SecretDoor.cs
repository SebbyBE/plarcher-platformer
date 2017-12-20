using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretDoor : MonoBehaviour {

	public void Open(){
		Vector3 pos = this.transform.localPosition;
		pos.y += 7;
		this.transform.localPosition = pos;
	}
}
