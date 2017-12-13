using System.Collections;
using UnityEngine;

public class HeroAttack : MonoBehaviour {

	private bool attacking = false;

	private float attackTimer = 0;
	private float attackCd = 0.3f;

	public Collider2D AttackTrigger;

	private Animator anim;

	void Awake()
	{
		anim = gameObject.GetComponent<Animator>();
		AttackTrigger.enabled = false;

	}

	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Space) && !attacking) {

			attacking = true;
			attackTimer = attackCd;

			AttackTrigger.enabled = true;

		}

		if (attacking) {
			if (attackTimer > 0) {
				attackTimer -= Time.deltaTime;
			} else {
				attacking = false;
				AttackTrigger.enabled = false;

			}
		}
		anim.SetBool ("Attacking", attacking);
	}
}
