using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour 
{
	private GameObject selectedUnit = null;

	// Use this for initialization
	void Start()
	{
		
	}
	
	// Update is called once per frame
	void Update() 
	{
		if(Input.GetMouseButtonDown (0)) 
		{
			select();
		}

		if(Input.GetMouseButtonDown (1)) 
		{
			move();
		}
	}

	private void select()
	{
		Ray ray = GetComponent<UnityEngine.Camera>().ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		selectedUnit = null;

		if(Physics.Raycast(ray, out hit))
		{
			GameObject obj = hit.collider.gameObject;
			
			if(obj != null)
			{	
				if(obj.tag == "Unit")
				{
					selectedUnit = obj;
				}

				if(obj.tag == "Building")
				{
					obj.GetComponent<Building>().select();
					selectedUnit = obj;
				}
			}
		}
	}

	private void move()
	{
		Ray ray = GetComponent<UnityEngine.Camera>().ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if(Physics.Raycast (ray, out hit))
		{
			if(selectedUnit != null)
			{
				selectedUnit.GetComponent<Unit>().destination = hit.point;
			}
		}
	}
}
