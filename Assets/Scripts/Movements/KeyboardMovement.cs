using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMovement : MonoBehaviour {

	[SerializeField]
	int speed = 1;

	void Awake() {
		
	}

	// Use this for initialization
	void Start () {

	}


	// Update is called once per frame
	void Update () {
		KinematicMovement ();
	}



	void KinematicMovement() {
		Vector3 velocity = GetAxisVector ();
		velocity *= speed * Time.deltaTime;
		transform.position += velocity;
	}

	Vector3 GetAxisVector() {
		float hDirection = Input.GetAxisRaw ("Horizontal");
		float vDirection = Input.GetAxisRaw ("Vertical");
		return new Vector3 (hDirection, vDirection, 0);
	}

}
