using System.Collections;
using UnityEngine;

public class HeroManager : MonoBehaviour {

	Animator anim;
	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();

	}

	// Update is called once per frame
	void Update () {

		//handling the idle -walking-idle state change
		if (Input.GetKey (KeyCode.D)) {
			anim.SetInteger ("State", 1);
		}
		if (Input.GetKey (KeyCode.D)) {
			anim.SetInteger ("State", 0);
		}
		//

		//
		if (Input.GetKey (KeyCode.W)) {
			anim.SetInteger ("State", 2);
		}
		if (Input.GetKey (KeyCode.W)) {
			anim.SetInteger ("State", 0);
		}
		//
	}
}
