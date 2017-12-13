using System.Collections;
using UnityEngine;

public class HeroController : MonoBehaviour {

	//Movement variables
	public float speed;
	public float jump;
	//public float moveVelocity;
	public float maxSpeed;
	bool grounded = true;
	bool facingRight = true;
	Animator anim = new Animator();
	Rigidbody2D rb;

	void Start ()
	{
		anim = GetComponent<Animator> ();
		//sanity check
		anim.SetBool ("isDead", true);
		rb = GetComponent<Rigidbody2D> ();

}
	void Update () {

		//Jump
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			if (grounded) {
				anim.SetInteger ("state", 3);
				rb.velocity = new Vector2 (
					rb.velocity.x, jump);

			}
		}
	}

		void FixedUpdate() {
			//Horizontal Control
			float move = Input.GetAxis ("Horizontal");
			//move left or right (using Addforce)
			if (grounded) {
			rb.AddForce(Vector2.right * move * Time.deltaTime);
	}
		if (Mathf.Abs (rb.velocity.x) > maxSpeed) {
			rb.velocity = new Vector2 (speed * move, rb.velocity.y);
		}
		if (move > 0 && !facingRight) {
			Flip ();
		} else if (move < 0 && facingRight) {
			Flip ();

			anim.SetInteger ("state", 1);
		}
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
		
}