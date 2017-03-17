using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	private GameManagerController gameManagerController;
	private Rigidbody rb;

	public GameObject gameManager;

	private void Start() {

		rb = GetComponent<Rigidbody> ();
		gameManagerController = gameManager.GetComponent<GameManagerController> ();
	}

	private void FixedUpdate () {

		float speedFactor = 300f;
		float horizontalAxis = Input.GetAxis ("Horizontal");
		float verticalAxis = Input.GetAxis ("Vertical");
		Vector3 forceVector = new Vector3 (horizontalAxis * speedFactor, 0, verticalAxis * speedFactor);

		rb.AddForce (forceVector, ForceMode.Force);

		if (Input.GetButtonDown ("Fire1") && rb.position.y == 0.5)
		{
			rb.AddForce (new Vector3 (0, 100f, 0), ForceMode.Impulse);
		}
	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("MysteryBox"))
		{
			MysteryBoxController boxController = other.gameObject.GetComponent<MysteryBoxController> ();

			if (boxController.isActive ())
			{
				MysteryBoxesManagerController boxesController = gameManagerController.GetMysteryBoxesManagerController ();

				boxesController.DeactivateOne (other.gameObject);
				boxesController.ChangeActiveMysteryBoxRandom ();	
			}
		}
	}
}
