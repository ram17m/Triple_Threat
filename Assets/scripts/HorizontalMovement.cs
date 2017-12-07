using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour {

	public float rightLimit = 2.5f; // f is float notaion to do tranform and rotation in c#
	public float leftLimit = -1.5f;
	public float speed = 2.0f;
	private int direction = 1;


	void Update () {
		if (transform.position.x> rightLimit) {
			direction = -1;
		}
		else if (transform.position.x< leftLimit) {
			direction = 1;
		}
		transform.Translate(Vector2.right * direction * speed * Time.deltaTime); 
		//transform.Translate(movement); 
	}
}