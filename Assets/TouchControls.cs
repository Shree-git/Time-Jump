using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour {

	public static int playerMoveAxis;

	void Start()
	{
		playerMoveAxis = 0;
	}

	public void OnLeftPointerDown()
	{
		playerMoveAxis = -1;
	}

	public void OnLeftPointerUp()
	{
		playerMoveAxis = 0;
	}

	public void OnRightPointerDown()
	{
		playerMoveAxis = 1;
	}

	public void OnRightPointerUp()
	{
		playerMoveAxis = 0;
	}
}
