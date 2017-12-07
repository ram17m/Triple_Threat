using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {
	public float speed=2f;
	public float leftLimit = 2f;
	public float rightLimit = 2f;
	private int direction= 1;

		
		void Update () {
		if (transform.position.y> rightLimit) {
				direction = -1;
			}
		else if (transform.position.y< leftLimit) {
				direction = 1;
			}
			
	
		transform.Rotate (Vector3.back); // rotate aniclockwise
		transform.Translate(Vector2.right * direction * speed * Time.deltaTime); 
}
}
