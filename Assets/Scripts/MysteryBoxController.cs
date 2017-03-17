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

	private void setAlpha(float alpha)
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

	void Activate()
	{
		setAlpha (1f);
	}

	void Deactivate()
	{
		setAlpha (0.5f);
	}

	void Start()
	{
		renderers = GetComponentsInChildren<Renderer> ();
		Deactivate();
	}

	void Update ()
	{
		rotate ();
	}
}
