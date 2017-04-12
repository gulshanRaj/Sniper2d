using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	private Rigidbody2D rb2d;
	private bool isDead = false;
	private bool isShooting = false;
	private Animator anim;
	private bool hitObstacle = false;
	public float min_y, max_y,min_x,max_x;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator>();
		rb2d.velocity = new Vector2 (0.0f, -0.3f);
	}

	// Update is called once per frame
	void Update () {
		if (isDead == true && isShooting == true) {
			isShooting = false;
			GameController.enemyShooter--;
		}
		if (isDead == false)
		{	

			if((GameController.isPlayerDucking == false) &&  Input.GetMouseButtonUp(0) && (Time.time - GameController.mouseDownTime <= 0.1f))
			{	
				hitObstacle = false;
				Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				RaycastHit2D[] hits = Physics2D.RaycastAll(worldPoint, Vector3.forward);
				foreach (RaycastHit2D hit in hits) {
					if (hit.collider != null) {	
						if (hit.collider.GetType () == typeof(BoxCollider2D)) {
							Debug.Log ("Obstacle hit");
							hitObstacle = true;
						}
					}
				}

				if (hitObstacle == false) {
					foreach (RaycastHit2D hit in hits) {
						if (hit.collider != null) {
							if (hit.collider.gameObject == this.transform.Find ("enemy_range").gameObject) {
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
									Debug.Log ("Enemy Hit");
									anim.SetTrigger ("Die");
									GameController.instance.ScoreUpdate ();
									rb2d.velocity = Vector2.zero;
									isDead = true;
									Debug.Log (isShooting);
									if (isShooting == true) {
										isShooting = false;
										GameController.enemyShooter--;
									}
									Debug.Log (isShooting);
								}
							}
						}
					}
				}

			}

			transform.position = new Vector3 (
				transform.position.x,
				Mathf.Clamp (transform.position.y, min_y, max_y),
				transform.position.z
			);
		}
	}
}