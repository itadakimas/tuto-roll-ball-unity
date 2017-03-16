using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryBoxController : MonoBehaviour
{
	private Component[] renderers;

	private void rotate()
	{
		float angle = 35 * Time.deltaTime;

		transform.Rotate (new Vector3(0, angle, 0));
	}

	void setAlpha(float alpha)
	{
		foreach (Renderer renderer in renderers)
		{
			foreach (Material material in renderer.materials)
			{
				Color origColor = material.color;

				material.color = new Color(origColor.r, origColor.g, origColor.b, alpha);
			}
		}
	}

	void Start()
	{
		renderers = GetComponentsInChildren<Renderer> ();

		setAlpha (0.5f);
	}

	void Update ()
	{
		rotate ();
	}
}
