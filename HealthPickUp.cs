using UnityEngine;

public class HealthPickUp : MonoBehaviour 
{
	HeroHealth herohealth;

	public float healthBonus = 15f;

	void Awake()
	{
		herohealth = FindObjectOfType<HeroHealth>();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (herohealth.curHealth < herohealth.maxHealth) 
		{
			Destroy (gameObject);
			herohealth.healthBar.value = herohealth.healthBar.value + healthBonus;
		}
	}
}
