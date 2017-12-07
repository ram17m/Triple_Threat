using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovement : MonoBehaviour {
	public float upLimit = 2.5f;
	public float downLimit = -1.5f;
	public float speed = 2.0f;
	private int direction = 1;


	void Update () {
		if (transform.position.y > upLimit) {
			direction = -1;
		}
		else if (transform.position.y < downLimit) {
			direction = 1;
		}
		transform.Translate(Vector2.up * direction * speed * Time.deltaTime); 
		//transform.Translate(movement); 
	}
}