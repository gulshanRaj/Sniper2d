using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirEnemy : MonoBehaviour {

	private Rigidbody2D rb2d;
	private bool isDead = false;
	private bool isShooting = false;
	private bool reachedGround = false;
	private float depth;
	private Animator anim;
	private bool hitObstacle = false;
	public float min_y, max_y,min_x,max_x;


	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator>();
		rb2d.velocity = new Vector2 (0.0f, -10.0f);
		depth = Random.Range (min_y, max_y);
	}
	
	// Update is called once per frame
	void Update () {
		if (reachedGround == false) {
			if (rb2d.transform.position.y <= depth) {
				reachedGround = true;
				rb2d.velocity = new Vector2(0.0f, 0.0f);
				anim.SetTrigger ("ReachGround");
				isShooting=true;
				GameControllerSurvival.enemyShooter++;
			}
		} else {
			if (isDead == true && isShooting == true) {
				isShooting = false;
				GameControllerSurvival.enemyShooter--;
			}
			if (isDead == false)
			{	

				if(Input.GetMouseButtonUp(0) && (Time.time - GameControllerSurvival.mouseDownTime <= 0.1f))
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
								// if (hit.collider.gameObject == this.transform.Find ("enemy_range").gameObject) {
								// 	if (hit.collider.GetType () == typeof(CircleCollider2D)) {
								// 		anim.SetTrigger ("Shoot");
								// 		rb2d.velocity = Vector2.zero;
								// 		if (isShooting == false) {
								// 			isShooting = true;
								// 			GameControllerSurvival.enemyShooter++;
								// 		}

								// 	}
								// }
								if (hit.collider.gameObject == this.gameObject) {
									if (hit.collider.GetType () == typeof(PolygonCollider2D)) {
										Debug.Log ("Enemy Hit");
										anim.SetTrigger ("Die");
										GameControllerSurvival.instance.ScoreUpdate ();
										rb2d.velocity = Vector2.zero;
										isDead = true;
										Debug.Log (isShooting);
										if (isShooting == true) {
											isShooting = false;
											GameControllerSurvival.enemyShooter--;
										}
										Debug.Log (isShooting);
									}
								}
							}
						}
					}
				}
			}
		}
	}
}
