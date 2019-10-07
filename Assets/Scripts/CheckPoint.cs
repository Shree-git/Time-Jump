using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {



	void OnTriggerEnter2D()
	{
		GameManager.Instance.spawnPosition.position = this.transform.position;
		GameManager.Instance.checkPtPanel.SetActive (true);

	}

	void OnTriggerExit2D()
	{
		GameManager.Instance.checkPtPanel.SetActive (false);
	}
}
