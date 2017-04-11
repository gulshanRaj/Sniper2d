using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	private Rigidbody2D rb2d;
	private bool isDead = false;
	private bool isShooting = false;
	private Animator anim;
	private float mouseDownTime = 0.0f;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator>();
		rb2d.velocity = new Vector2 (0.0f, -0.1f);
	}

	// Update is called once per frame
	void Update () {
		if (isDead == false)
		{	if (Input.GetMouseButtonDown (0)) {
				mouseDownTime = Time.time;
			}

			if(Input.GetMouseButtonUp(0) && (Time.time - mouseDownTime <= 0.1f))
			{
				Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

				if (hit.collider != null)
				{	
					if (hit.collider.gameObject == this.transform.Find("enemy_range").gameObject) {
						if (hit.collider.GetType () == typeof(CircleCollider2D)) {
							anim.SetTrigger ("Shoot");
							rb2d.velocity = Vector2.zero;
							if (isShooting == false) {
								isShooting = true;
								GameController.enemyShooter++;
							}

						}
					}
					if (hit.collider.gameObject == this.gameObject) {
						if (hit.collider.GetType () == typeof(PolygonCollider2D)) {
							anim.SetTrigger ("Die");
							GameController.instance.ScoreUpdate ();
							rb2d.velocity = Vector2.zero;
							isDead = true;
							if (isShooting == true) {
								isShooting = false;
								GameController.enemyShooter--;
							}
						}
					}
				}

			}

		}
	}
}