using UnityEngine;
using System.Collections;

public class Selectable : MonoBehaviour 
{
	protected bool selected;

	public void select()
	{
		selected = true;
	}

	public void deselect()
	{
		selected = false;
	}
}
