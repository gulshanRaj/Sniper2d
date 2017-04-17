﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	private Rigidbody2D rb2d;
	private bool isDead = false;
	private bool isShooting = false;
	private bool hasSeen = false;
	private Animator anim;
	private bool hitObstacle = false;
<<<<<<< HEAD
	public AudioClip bodyHitSound;
	public AudioClip obstacleHitSound;
	public AudioClip machinegun;
	private AudioSource source;
	private float reactionTime = 1.0f, restingTime = 3.0f;
	private float shootingTime = 0.0f, enduranceTime = 3.0f;
	private Vector2 initialVel;
=======
<<<<<<< HEAD
	public AudioClip bodyHitSound;
	public AudioClip obstacleHitSound;
	private AudioSource source;
	private float reactionTime = 1.0f, restingTime = 5.0f;
	private float shootingTime = 0.0f, enduranceTime = 4.0f;
	private Vector2 initialVel;
=======
>>>>>>> master
	public float min_y, max_y,min_x,max_x;
>>>>>>> Kedit

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator>();
<<<<<<< HEAD
		rb2d.velocity = new Vector2 (0.0f, -0.2f);
		initialVel = rb2d.velocity;
		source = GetComponent<AudioSource> ();
=======
<<<<<<< HEAD
		rb2d.velocity = new Vector2 (0.0f, -0.1f);
		initialVel = rb2d.velocity;
		source = GetComponent<AudioSource> ();
		}
=======
		rb2d.velocity = new Vector2 (0.0f, -0.3f);
>>>>>>> master
	}
>>>>>>> Kedit

	// Update is called once per frame
	void Update () {
		if (isDead == true && isShooting == true) {
			isShooting = false;source.Stop ();
			GameController.enemyShooter--;
		}
<<<<<<< HEAD

=======
>>>>>>> Kedit
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
<<<<<<< HEAD
							hitObstacle = true; source.PlayOneShot (obstacleHitSound, 0.5f);
=======
<<<<<<< HEAD
							hitObstacle = true; source.PlayOneShot (obstacleHitSound, 0.5f);
=======
							Debug.Log ("Obstacle hit");
							hitObstacle = true;
>>>>>>> Kedit
>>>>>>> master
						}
					}
				}

				if (hitObstacle == false) {
					foreach (RaycastHit2D hit in hits) {
						if (hit.collider != null) {
							if (hit.collider.gameObject == this.transform.Find ("enemy_range").gameObject) {
								if (hit.collider.GetType () == typeof(CircleCollider2D)) {
<<<<<<< HEAD
									anim.ResetTrigger ("Tired");  anim.SetTrigger ("Shoot");
									rb2d.velocity = Vector2.zero;
									if (isShooting == false && hasSeen==false) {
										isShooting = true; hasSeen = true; source.PlayOneShot (machinegun, 0.3f);
										shootingTime = Time.time;  restingTime = Time.time; 
=======
<<<<<<< HEAD
									anim.SetTrigger ("Shoot"); 
									rb2d.velocity = Vector2.zero;
									if (isShooting == false && hasSeen == false) {
										isShooting = true; hasSeen = true; 
										shootingTime = Time.time;  restingTime = Time.time; 
=======
									anim.SetTrigger ("Shoot");
									rb2d.velocity = Vector2.zero;
									if (isShooting == false) {
										isShooting = true;
>>>>>>> Kedit
>>>>>>> master
										GameController.enemyShooter++;
									}

								}
							}
							if (hit.collider.gameObject == this.gameObject) {
								if (hit.collider.GetType () == typeof(PolygonCollider2D)) {
<<<<<<< HEAD
=======
<<<<<<< HEAD
									anim.SetTrigger ("Die"); source.PlayOneShot (bodyHitSound, 0.5f);
									GameController.instance.ScoreUpdate ();
									rb2d.velocity = Vector2.zero;
									isDead = true;
									if (isShooting == true) {
										isShooting = false; hasSeen = false;
										GameController.enemyShooter--;
									}
=======
									Debug.Log ("Enemy Hit");
>>>>>>> master
									anim.SetTrigger ("Die");
									GameController.instance.ScoreUpdate ();
									rb2d.velocity = Vector2.zero;
									isDead = true;source.Stop ();
									if (isShooting == true) {
										isShooting = false; hasSeen = false;
										GameController.enemyShooter--;
									}
<<<<<<< HEAD
=======
									Debug.Log (isShooting);
>>>>>>> Kedit
>>>>>>> master
								}
							}
						}
					}
				}

			}

<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> master
			if (hasSeen) {

				if (isShooting && Time.time - shootingTime > enduranceTime) {
					anim.ResetTrigger ("Shoot");
					anim.SetTrigger ("Tired");// anim.ResetTrigger ("Tired");
					GameController.enemyShooter--;
					rb2d.velocity = initialVel; isShooting = false;
<<<<<<< HEAD
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

=======
					restingTime = Time.time; 
				}

				//if (GameController.isPlayerDucking == false && isShooting == false && Time.time - GameController.gotUpTime > reactionTime) {
					if (isShooting == false && Time.time - restingTime > enduranceTime) { 
					anim.ResetTrigger ("Tired"); anim.SetTrigger ("Shoot"); 
						rb2d.velocity = Vector2.zero;
						isShooting = true; shootingTime = Time.time;
						GameController.enemyShooter++;
					}
				//}



			}

=======
>>>>>>> master
			transform.position = new Vector3 (
				transform.position.x,
				Mathf.Clamp (transform.position.y, min_y, max_y),
				transform.position.z
			);
>>>>>>> Kedit
		}
	}
}