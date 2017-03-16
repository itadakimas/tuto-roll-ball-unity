using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	private Rigidbody rb;

	void Start() {

		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {

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

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("MysteryBox"))
		{
			other.gameObject.SendMessage ("setAlpha", 0.5f);
		}
	}
}
