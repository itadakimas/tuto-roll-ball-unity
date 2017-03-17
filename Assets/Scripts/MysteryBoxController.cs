using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryBoxController : MonoBehaviour
{
	private bool active = true;
	private Component[] renderers;

	void Start()
	{
		renderers = GetComponentsInChildren<Renderer> ();
		gameObject.tag = "MysteryBox";
		Deactivate();
	}

	void Update ()
	{
		rotate ();
	}

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

	public void Activate()
	{
		setAlpha (1f);
		active = true;
	}

	public void Deactivate()
	{
		setAlpha (0.5f);
		active = false;
	}

	public bool isActive()
	{
		return active;
	}
}
