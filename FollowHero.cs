using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHero : MonoBehaviour 
{
	//what are we following
	public Transform hero;

	Vector3 velocity = Vector3.zero;

	//time to follow hero
	public float smoothTime = .15f;

	//enable and set the mavimum y value
	public bool YMaxEnabled = false;
	public float YMaxValue = 0;

	//enable and set the minimum y value
	public bool YMinEnabled = false;
	public float YMinValue = 0;

	//enable and set the mavimum x value
	public bool XMaxEnabled = false;
	public float XMaxValue = 0;

	//enable and set the minimum x value
	public bool XMinEnabled = false;
	public float XMinValue = 0; 

	void FixedUpdate()
	{
		//hero position
		Vector3 heroPos = hero.position;

		//vertical
		if (YMinEnabled && YMaxEnabled)
			heroPos.y = Mathf.Clamp (hero.position.y, YMinValue, YMaxValue);
		else if (YMinEnabled)
			heroPos.y = Mathf.Clamp (hero.position.y, YMinValue, hero.position.y);
		else if (YMaxEnabled)
			heroPos.y = Mathf.Clamp (hero.position.y, hero.position.y, YMaxValue);

		//horizontal
		if (XMinEnabled && XMaxEnabled)
			heroPos.x = Mathf.Clamp (hero.position.x, XMinValue, XMaxValue);
		else if (XMinEnabled)
			heroPos.x = Mathf.Clamp (hero.position.x, XMinValue, hero.position.x);
		else if (XMaxEnabled)
			heroPos.x = Mathf.Clamp (hero.position.x, hero.position.x, XMaxValue);
		

		//allign the camera and the heros z position
		heroPos.z = transform.position.z;

		transform.position = Vector3.SmoothDamp (transform.position, heroPos, ref velocity, smoothTime);

	}
}
