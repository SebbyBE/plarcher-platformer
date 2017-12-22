using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerDoor : MonoBehaviour {

	public Vector3 localPos;

	public void Open(){
		Vector3 pos = this.transform.localPosition;
		this.localPos = this.transform.localPosition;
		pos.y += 10;
		this.transform.localPosition = pos;
		StartCoroutine (CloseDoor ());
	}

	private IEnumerator CloseDoor(){
		//ferme la porte petit a petit (+- 15 secondes)
		while (this.transform.localPosition.y > localPos.y) {
			yield return new WaitForSeconds (0.075f);
			Vector3 pos = this.transform.localPosition;
			pos.y -= 0.05f;
			this.transform.localPosition = pos;
		}
		this.transform.localPosition = localPos;
		StopAllCoroutines ();
	}
}
