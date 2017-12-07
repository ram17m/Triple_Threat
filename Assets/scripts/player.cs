using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    public float moveSpeed;
    private Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();    
    	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxisRaw("Horizontal") > 0.1f || Input.GetAxisRaw("Horizontal") < -0.1f)//checks if the left/right arrow key is pressed 
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
            //commands to move on horizontal axis 
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));//links animation to the object
      	}
}
