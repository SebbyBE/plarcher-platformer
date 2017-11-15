using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public static Player INSTANCE;

	public int speed = 5;
	public LayerMask groundLayer;
	public float groundDistance = 0.6f;
	public float jumpStrength = 7f;
	public bool isGrounded = false;

	public int coins = 0;

	public Rigidbody2D rigidBody;

	private ArrayList actionsList;

	// Use this for initialization
	void Start () {
		INSTANCE = this;
		this.gameObject.AddComponent<AddGoRight> ();
		this.gameObject.AddComponent<GetCoin> ();
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire2")){
			this.gameObject.AddComponent<AddGoLeft> ();
			this.gameObject.AddComponent<AddJump> ();
		}
	}

	void FixedUpdate(){
		if (Physics2D.Raycast (transform.position, Vector2.down, groundDistance, groundLayer)) {
			isGrounded = true;
		} else {
			isGrounded = false;
		}
	}
}
