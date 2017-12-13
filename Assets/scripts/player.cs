using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
	public Rigidbody bullet;
	private Animator animator;
	public Rigidbody2D Player;
	public float jumpheight;
	public float speed;
	bool grounded = true;
	bool facingRight = true;
	public GameObject leftbullet, rightbullet;
	//private Transform Shootpos;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		Player = GetComponent<Rigidbody2D> ();
		bullet = GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void Update () {

		move ();
		if (Input.GetKeyDown (KeyCode.Space)) {
			attack ();
		}
	}

	void move(){
		
		if (Input.GetAxisRaw ("Horizontal") > 0.5f  || Input.GetAxisRaw ("Horizontal") < -0.5f) {
			transform.Translate (new Vector3 (Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0f, 0f));

		} 
		animator.SetInteger ("state", 1);
		transform.Translate (new Vector3 (Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0f, 0f));
		animator.SetInteger ("state", 1);


	

		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			Player.velocity = new Vector2 (0, jumpheight);
		} else if (Input.GetKeyUp (KeyCode.UpArrow)) {
			Player.velocity = new Vector2 (0, -jumpheight);
		}
		Debug.Log ("state 2 in action");
		animator.SetInteger ("state", 2);

	}
	void FixedUpdate() {
		//Horizontal Control
		float move = Input.GetAxis ("Horizontal");
		//move left or right (using Addforce)
		if (grounded) {
			Player.AddForce(Vector2.right * move * Time.deltaTime);
		}
		if (Mathf.Abs (Player.velocity.x) > speed) {
			Player.velocity = new Vector2 (speed * move, Player.velocity.y);
		}
		if (move > 0 && !facingRight) {
			Flip ();
		} else if (move < 0 && facingRight) {
			Flip ();

		}
		Debug.Log ("state 1 in action");
		animator.SetInteger ("state", 1);


	}

	//Check to see if grounded or not
	void OnTriggerEnter2D() {
		grounded = true;
	}

	void OnTriggerExit2D ()
	{
		grounded = false;
	}
	void Flip()
	{

		facingRight = !facingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;

	}




void attack(){
		

		if (facingRight) {
			Instantiate (rightbullet, transform.position, Quaternion.identity);
		} else if (!facingRight) {
			Instantiate (leftbullet, transform.position, Quaternion.identity);
		}
		animator.SetInteger ("state", 3);
	}

	void OnCollisionEnter2d(Collision c){
		if (c.rigidbody.tag == "bullet"||c.rigidbody.tag=="enemy") {
			Destroy (Player);
		} 
		}
	}


