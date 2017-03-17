using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryBoxesManagerController : MonoBehaviour {

	private GameObject[] boxes;

	private GameObject[] GetMysteryBoxes()
	{
		ArrayList boxes = new ArrayList ();

		foreach (Transform child in gameObject.transform)
		{
			boxes.Add (child.gameObject);
		}
		return (GameObject[]) boxes.ToArray (typeof(GameObject));
	}

	private void Start ()
	{
		boxes = GetMysteryBoxes ();
	}

	public void ChangeActiveMysteryBoxRandom()
	{
		MysteryBoxController boxController;
		int index;

		foreach (GameObject box in boxes)
		{
			boxController = box.GetComponent<MysteryBoxController> ();

			if (boxController.isActive())
			{
				boxController.Deactivate ();
				break;
			}
		}
		index = (int) Random.Range (0, boxes.Length - 1);
		boxController = boxes [index].GetComponent<MysteryBoxController>();
		boxController.Activate ();
	}

	public void DeactivateOne(GameObject box)
	{
		MysteryBoxController controller;

		if (!box.CompareTag ("MysteryBox"))
		{
			throw new UnityException ("Invalid GameObject instance. Expected MysteryBox");
		}
		controller = box.GetComponent<MysteryBoxController> ();
		controller.Deactivate ();
	}
}
