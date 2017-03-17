using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	private GameManagerController gameManagerController;
	private Rigidbody rb;

	public GameObject gameManager;

	private void Start()
	{
		rb = GetComponent<Rigidbody> ();
		gameManagerController = gameManager.GetComponent<GameManagerController> ();
	}

	private void FixedUpdate ()
	{
		float speedFactor;
		float horizontalAxis;
		float verticalAxis;
		Vector3 forceVector;

		if (SystemInfo.supportsGyroscope)
		{
			speedFactor = 600f;
			horizontalAxis = Input.gyro.rotationRate.y;
			verticalAxis = -Input.gyro.rotationRate.x;
			rb.drag = 0f;
		}
		else
		{
			speedFactor = 300f;
			horizontalAxis = Input.GetAxis ("Horizontal");
			verticalAxis = Input.GetAxis ("Vertical");
		}
		forceVector = new Vector3 (horizontalAxis * speedFactor, 0, verticalAxis * speedFactor);
		rb.AddForce (forceVector, ForceMode.Force);
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
