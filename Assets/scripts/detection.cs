using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detection : MonoBehaviour {

	public void OnCollisionEnter2D(Collision2D col){
		print ("I hit to " + col.gameObject.name);
	}
}
