using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerController : MonoBehaviour
{
	public GameObject mysteryBoxesManager;

	private bool isStarted = false;
	private MysteryBoxesManagerController mysteryBoxesManagerController;

	private void Start()
	{
		mysteryBoxesManagerController = mysteryBoxesManager.GetComponent<MysteryBoxesManagerController> ();
	}

	private void Update()
	{
		if (!isStarted)
		{
			mysteryBoxesManagerController.ChangeActiveMysteryBoxRandom ();
			isStarted = true;
		}
	}

	public MysteryBoxesManagerController GetMysteryBoxesManagerController()
	{
		return mysteryBoxesManagerController;
	}
}
