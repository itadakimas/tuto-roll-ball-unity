using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryBoxController : MonoBehaviour {


	void Update () {

		float angle = 35 * Time.deltaTime;

		transform.Rotate (new Vector3(0, angle, 0));
	}
}
