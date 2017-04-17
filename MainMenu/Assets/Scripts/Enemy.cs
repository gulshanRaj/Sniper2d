using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	private Rigidbody2D rb2d;
	private bool isDead = false;
	private bool isShooting = false;
	private bool hasSeen = false;
	private Animator anim;
	private bool hitObstacle = false;
	public AudioClip bodyHitSound;
	public AudioClip obstacleHitSound;
	public AudioClip machinegun;
	private AudioSource source;
	private float reactionTime = 1.0f, restingTime = 3.0f;
	private float shootingTime = 0.0f, enduranceTime = 3.0f;
	private Vector2 initialVel;
	public float min_y, max_y,min_x,max_x;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator>();
		rb2d.velocity = new Vector2 (0.0f, -0.3f);
		initialVel = rb2d.velocity;
		source = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		if (isDead == true && isShooting == true) {
			isShooting = false;source.Stop ();
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
							hitObstacle = true; source.PlayOneShot (obstacleHitSound, 0.5f);
						}
					}
				}

				if (hitObstacle == false) {
					foreach (RaycastHit2D hit in hits) {
						if (hit.collider != null) {
							if (hit.collider.gameObject == this.transform.Find ("enemy_range").gameObject) {
								if (hit.collider.GetType () == typeof(CircleCollider2D)) {
									anim.ResetTrigger ("Tired");  anim.SetTrigger ("Shoot");
									rb2d.velocity = Vector2.zero;
									if (isShooting == false && hasSeen==false) {
										isShooting = true; hasSeen = true; source.PlayOneShot (machinegun, 0.3f);
										shootingTime = Time.time;  restingTime = Time.time; 
										GameController.enemyShooter++;
									}

								}
							}
							if (hit.collider.gameObject == this.gameObject) {
								if (hit.collider.GetType () == typeof(PolygonCollider2D)) {
									anim.SetTrigger ("Die");
									GameController.instance.ScoreUpdate ();
									rb2d.velocity = Vector2.zero;
									isDead = true;source.Stop ();
									if (isShooting == true) {
										isShooting = false; hasSeen = false;
										GameController.enemyShooter--;
									}
								}
							}
						}
					}
				}

			}

			if (hasSeen) {

				if (isShooting && Time.time - shootingTime > enduranceTime) {
					anim.ResetTrigger ("Shoot");
					anim.SetTrigger ("Tired");// anim.ResetTrigger ("Tired");
					GameController.enemyShooter--;
					rb2d.velocity = initialVel; isShooting = false;
					restingTime = Time.time; Debug.Log ("Tired");
				}

				//if (GameController.isPlayerDucking == false && isShooting == false && Time.time - GameController.gotUpTime > reactionTime) {
				if (isShooting == false && Time.time - restingTime > enduranceTime) { 
					anim.ResetTrigger ("Tired");
					anim.SetTrigger ("Shoot");
					source.PlayOneShot (machinegun, 0.3f);
					rb2d.velocity = Vector2.zero;
					isShooting = true; shootingTime = Time.time;
					GameController.enemyShooter++;
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