using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	private AudioSource music;

	void Start()
	{
		music = GetComponent<AudioSource> ();
		music.Play ();
	}

	public void OnStartPress()
	{
		SceneManager.LoadScene ("Level2");
	}
}
