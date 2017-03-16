using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	private Rigidbody rb;

	void Start() {

		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {

		float horizontalAxis = Input.GetAxis ("Horizontal");
		float verticalAxis = Input.GetAxis ("Vertical");
		Vector3 forceVector = new Vector3 (horizontalAxis, 0, verticalAxis);

		rb.AddForce (forceVector, ForceMode.Force);
	}
}
