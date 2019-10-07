using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;

	public GameObject timePowerupParent;

	public GameObject deathPanel;
	public GameObject checkPtPanel;

	public Transform spawnPosition;
	public GameObject player;
	//public GameObject playerPrefab;

	public float startingTime;

	public float addingTime;

	public Text timeText;

	public AudioSource mainMusic;
	public AudioSource clockTick;
	public AudioClip clockt;
	public float clockVol;

	//public AudioSource bounceMusic;


	void Start()
	{
		
		Instance = this;

		//player = playerPrefab;
		player.GetComponent<PlayableDirector>().Play();

		mainMusic.Play ();

		player.transform.position = spawnPosition.position;

		//clockTick.Play (44100 / 2);
		clockVol = 0;
		clockTick.volume = clockVol;

		StartCoroutine (PlaySoundEverySecond ());
		//clockTick.Play();
	}

	IEnumerator PlaySoundEverySecond()
	{
		int i = 1;

		while (i > 0) {
			clockTick.Play ();
			yield return new WaitForSeconds (1);
		}
	}
		




	void Update()
	{
		

		if (startingTime <= 0) {
			
			Death ();
			RespawnTimePowerUp ();
		}

		clockTick.volume = clockVol;

		if (startingTime >= 0 && player.GetComponent<PlayableDirector>().state == PlayState.Paused) {

			mainMusic.Stop ();

			startingTime -= Time.deltaTime;

			clockVol = 1;

		

		}
	}

	void FixedUpdate()
	{
		

		int minutes = (int)startingTime / 60;
		int seconds = (int)startingTime % 60;

		timeText.text = minutes + ":" + seconds;





	


	}


	public void Death()
	{
		clockVol = 0;
		player.SetActive(false);

		deathPanel.SetActive (true);

		StartCoroutine (SpawnAfterDestroy ());
		//Invoke("SpawnAfterDestroy", 2);

	}

	IEnumerator SpawnAfterDestroy()
	{
		yield return new WaitForSeconds (2);

		//player = playerPrefab;
	
		player.transform.position = spawnPosition.position;
		player.SetActive (true);
		player.GetComponent<Rigidbody2D> ().gravityScale = player.GetComponent<PlayerController>().gravityScale;

		startingTime = 15f;
		deathPanel.SetActive (false);
	}

	public void RespawnTimePowerUp()
	{
		for (int i = 0; i < timePowerupParent.transform.childCount; i++) {
			timePowerupParent.transform.GetChild (i).gameObject.SetActive (true);
		}
		
	}


	public void OnMenuClick()
	{
		SceneManager.LoadScene ("Main Menu");
	}
}
