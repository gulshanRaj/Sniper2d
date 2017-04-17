using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	public GameObject gameOverText;
	public GameObject restartText;
	public GameObject levelText;
	public GameObject crossHair;
	public GameObject stone_wall;
	public Text scoreText;
	public Text healthText;
	public static int score;
	public static float healthBar;
	public static int enemyShooter;
	public bool gameOver = false;
	public static bool isPlayerDucking = false;
	public AudioClip shootSound;
	private AudioSource source;
	private float volLowRange=.5f;
	private float volHighRange=1.0f;
	public static GameController instance;
	public static float mouseDownTime = 0.0f, gotUpTime = 0.0f;
	private float wallDownTime = 0.0f;




	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this; 
		} else if (instance != this) {
			Destroy (gameObject);
		}
<<<<<<< HEAD
		healthBar = 10000.0f;
=======
		healthBar = 10.0f;
>>>>>>> Kedit
		score = 0;
		enemyShooter = 0;
		gotUpTime = Time.time;
		source = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		HealthUpdate ();
		if ((gameOver == true || score==17) && Input.GetMouseButtonDown (0)) {
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
		}
		if (Time.time - wallDownTime > 1.0f && Input.touchCount > 1) { 
			Debug.Log (Input.touchCount);
				if (isPlayerDucking == false) {
					isPlayerDucking = true;
					stone_wall.SetActive (true);
					crossHair.SetActive (false);
				} else {
					isPlayerDucking = false;
					stone_wall.SetActive (false);
				crossHair.SetActive (true); gotUpTime = Time.time;
				}
			wallDownTime = Time.time;
		} 

		if (Input.GetMouseButtonDown (0)) { 
			mouseDownTime = Time.time;
		}

		if(isPlayerDucking == false && Input.GetMouseButtonUp(0)) {
			if(Time.time - mouseDownTime <= 0.1f)
			{
				float vol = Random.Range (volLowRange, volHighRange);
				source.PlayOneShot (shootSound, vol); Debug.Log ("Bullet Sound");
			}
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			SceneManager.LoadScene (0);
		}
	}

	public void EnemyDied() {
		gameOverText.SetActive (true);
		restartText.SetActive (true);
		gameOver = true;
		crossHair.SetActive (false);
	}

	public void HealthUpdate(){
		if (gameOver) {
			return;
		}
		if (isPlayerDucking == false) {
			healthBar = healthBar - SceneManager.GetActiveScene ().buildIndex * enemyShooter * Time.deltaTime;
			int tempHealthBar = (int)(healthBar);
			healthText.text = "Health: " + tempHealthBar.ToString ();
			if (healthBar <= 0) {
				healthText.text = "Health: 0";
				EnemyDied ();
			}
		}
	}

	public void ScoreUpdate(){
		if (gameOver) {
			return;
		}
		score++;
		if (score == 17) {
			levelText.SetActive (true);
			restartText.SetActive (true);
		}
		scoreText.text = "Score: " + score.ToString();
	}


}