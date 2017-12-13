using System.Collections;
using UnityEngine;

public class DestroyWithDelay : MonoBehaviour 
{
	public float delay;

	// Use this for initialization
	void Start () 
	{
		Destroy (gameObject, delay);
	}

}
