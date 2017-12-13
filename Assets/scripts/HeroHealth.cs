using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HeroHealth : MonoBehaviour 
{
	
	public Slider healthBar;

	public float maxHealth = 100;
	public float curHealth;

	Animator anim;

	void Start ()
	{
		anim = GetComponent<Animator>();

		healthBar.value = maxHealth;
		curHealth = healthBar.value;
	}
	void OnTriggerStay2D(Collider2D col)
	{
		if (col.gameObject.tag == "enemy") {
			healthBar.value -= 15f;
			curHealth = healthBar.value;
		}
	}
		void Update()
		{
			//play dead animation
			if(curHealth <= 0)

			anim.SetBool("isDead", true);
			//stop all player movement
		GetComponent<HeroController>().enabled = true;
		
	}
}

	