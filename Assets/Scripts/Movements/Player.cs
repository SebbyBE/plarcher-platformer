using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField]
	int speed = 1;

	public Rigidbody2D rigidBody;

	private IActions actions;
	private float rightDirection;
	private float leftDirection;
	private bool isJumping;

	void Awake() {

	}

	// Use this for initialization
	void Start () {
		this.actions = (IActions)new AddGoRight (new Actions());
	}


	// Update is called once per frame
	void Update () {
		CheckMovementAndMove ();
	}



	void CheckMovementAndMove() {
		/*
		Vector3 velocity = GetAxisVector ();
		velocity *= speed * Time.deltaTime;
		transform.position += velocity;


		Vector3 GetAxisVector() {
		float hDirection = Input.GetAxisRaw ("Horizontal");
		float vDirection = Input.GetAxisRaw ("Vertical");
		return new Vector3 (hDirection, vDirection, 0);
		}
		*/

		if(Input.GetButtonDown("Fire2")){
			this.actions = (IActions)new AddGoLeft(this.actions);
		}


		rightDirection = actions.GoRight ();
		leftDirection = actions.GoLeft ();

		if (actions.Jump ()) {
			
		}

			
		float hDirection = rightDirection + leftDirection;
		float vDirection = 0;
		Vector3 velocity = new Vector3 (hDirection, vDirection, 0);
		velocity *= speed * Time.deltaTime;
		transform.position += velocity;
	}



}
