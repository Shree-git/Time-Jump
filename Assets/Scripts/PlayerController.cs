using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D playerRigidBody;

	public float gravityScale;
	public float moveSpeed;

	public int sceneIndex;

	public GameObject youWin;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "WinTile") {
			
			if (sceneIndex == 1) {
				StartCoroutine (WinningScene ());
				SceneManager.LoadScene ("Main");
			} else if (sceneIndex == 2) {
				StartCoroutine (WinningScene ());
				SceneManager.LoadScene ("Main Menu");
			}


		}

		if (col.gameObject.tag == "Spike") {
			GameManager.Instance.startingTime = 0f;
			/*GameManager.Instance.Death ();
			GameManager.Instance.RespawnTimePowerUp ();
			GameManager.Instance.clockVol = 0;*/
		}
	}

	IEnumerator WinningScene()
	{
		youWin.SetActive (true);
		yield return new WaitForSeconds (3);
	}

	/*void OnCollisionEnter2D(Collision2D col)
	{
		
		if (col.gameObject.tag == "GameTile") {
			GameManager.Instance.bounceMusic.Play ();
		}
	}*/

	void Start()
	{
		playerRigidBody = GetComponent<Rigidbody2D> ();
		playerRigidBody.gravityScale = gravityScale;
		youWin.SetActive (false);
	}

	void FixedUpdate()
	{
		
		#if UNITY_STANDALONE
		ChangeGravity ();

		MovePlayer ();
		#endif

		#if UNITY_ANDROID || UNITY_EDITOR
		ChangeGravityOnAndroid();

		MovePlayerOnAndroid();
		#endif
			
	}

	void ChangeGravity()
	{
		if (Input.GetMouseButtonDown (0)) {
			playerRigidBody.gravityScale = gravityScale;
		} else if (Input.GetMouseButtonDown (1)) {
			playerRigidBody.gravityScale = -gravityScale;
		}
	}

	void ChangeGravityOnAndroid()
	{
		if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject() && Input.touchCount > 0) {
			//Touch myTouch = Input.GetTouch (0);

			if (playerRigidBody.gravityScale == -gravityScale) {
				playerRigidBody.gravityScale = gravityScale;
			} else if (playerRigidBody.gravityScale == gravityScale) {
				playerRigidBody.gravityScale = -gravityScale;
			}
		}
	}

	void MovePlayer()
	{
		float movementAxis = Input.GetAxis ("Horizontal");

		Vector2 movePlayer = new Vector3 (movementAxis * moveSpeed * 100f * Time.deltaTime, transform.position.y);

		playerRigidBody.AddForce (movePlayer, ForceMode2D.Force);
	}

	void MovePlayerOnAndroid()
	{
		float movementAxis = TouchControls.playerMoveAxis;

		Vector2 movePlayer = new Vector3 (movementAxis * moveSpeed * 100f * Time.deltaTime, transform.position.y);

		playerRigidBody.AddForce (movePlayer, ForceMode2D.Force);
	}
}
