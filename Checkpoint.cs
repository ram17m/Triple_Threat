using System.Collections;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

	public Sprite Sign1;
	public Sprite Sign2;
	private SpriteRenderer checkpointSpriteRenderer;
	public bool checkpointReached;


	void Start () {
		checkpointSpriteRenderer = GetComponent<SpriteRenderer> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			checkpointSpriteRenderer.sprite = Sign2;
	checkpointReached = true;
}
	}
}
