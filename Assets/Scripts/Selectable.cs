using UnityEngine;
using System.Collections;

public class Selectable : MonoBehaviour 
{
	protected bool selected;
	public GameObject buildingMain;

	public virtual void select(float x, float y)
	{
		selected = true;
	}

	public virtual void move(Vector3 dest)
	{

	}

	public virtual void deselect()
	{
		selected = false;
	}
}
