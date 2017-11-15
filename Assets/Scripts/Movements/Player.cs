using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public int speed = 5;
	public LayerMask groundLayer;
	public float groundDistance = 0.6f;
	public float jumpStrength = 7f;
	public bool isGrounded = false;

	public Rigidbody2D rigidBody;

	private ArrayList actionsList;

	// Use this for initialization
	void Start () {
		this.actionsList = new ArrayList ();
		this.actionsList.Add (new AddGoRight (this));
	}

	// Update is called once per frame
	void Update () {
		Debug.DrawRay (transform.position, Vector3.down * groundDistance,Color.red);

		if(Input.GetButtonDown("Fire2")){
			this.actionsList.Add (new AddGoLeft (this));
			this.actionsList.Add (new AddJump (this));
		}
		foreach(IActions a in this.actionsList){
			a.execute ();
		}
	}

	void FixedUpdate(){
		if (Physics2D.Raycast (transform.position, Vector2.down, groundDistance, groundLayer)) {
			isGrounded = true;
		} else {
			isGrounded = false;
		}
	}

	public void AddBehaviour(IActions action){
		this.actionsList.Add (action);
	}



}
