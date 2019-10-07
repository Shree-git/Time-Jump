using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour {

	void OnTriggerEnter2D()
	{
		GameManager.Instance.startingTime += GameManager.Instance.addingTime;
		this.gameObject.SetActive (false);
	}
}
