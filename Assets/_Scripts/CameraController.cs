using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject ball;

	private Vector3 transformOffset;

	void Start () {

		transformOffset = transform.position - ball.transform.position;
	}
	void LateUpdate () {

		transform.position = ball.transform.position + transformOffset;
	}
}
