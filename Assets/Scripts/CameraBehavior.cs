using UnityEngine;
using System.Collections;

public class CameraBehavior : MonoBehaviour 
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

		if(Input.mousePosition.x > Screen.width - 100)
		{
			float speed = (Input.mousePosition.x - (Screen.width - 100)) / 10;
			transform.Translate(new Vector3(Time.deltaTime * speed, 0, 0), Space.World);
		}

		if(Input.mousePosition.x < 100)
		{
			float speed = (100 - Input.mousePosition.x) / 10;
			transform.Translate(new Vector3(-Time.deltaTime * speed, 0, 0), Space.World);
		}

		if(Input.mousePosition.y > Screen.height - 100)
		{
			float speed = (Input.mousePosition.y - (Screen.height - 100)) / 10;
			transform.Translate(new Vector3(0, 0, Time.deltaTime * speed), Space.World);
		}

		if(Input.mousePosition.y < 100)
		{
			float speed = (100 - Input.mousePosition.y) / 10;
			transform.Translate(new Vector3(0, 0, -Time.deltaTime * speed), Space.World);
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

		if(selectedUnit != null)
		{
	
		}
		else
		{
			selectedUnit = null;
		}


		if(Physics.Raycast(ray, out hit))
		{
			GameObject obj = hit.collider.gameObject;
			
			if(obj != null && obj != selectedUnit)
			{	
				if(obj.tag == "Unit")
				{
					if(selectedUnit.GetComponent<Building>() != null)
					{
						selectedUnit.GetComponent<Building>().deselect();
					}

					selectedUnit = obj;
				}

				if(obj.tag == "Building")
				{
					obj.GetComponent<Building>().select(Input.mousePosition.x, Input.mousePosition.y);
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
