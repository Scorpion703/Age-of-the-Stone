using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraBehavior : MonoBehaviour 
{
	private List<Selectable> selected = new List<Selectable>();

	// Use this for initialization
	void Start()
	{
		
	}
	
	// Update is called once per frame
	void Update() 
	{
		cameraMovement();
		if(Input.GetMouseButtonDown(0)) leftClick();
		if(Input.GetMouseButtonDown(1)) rightClick();
	}

	private void cameraMovement()
	{
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
	}

	private void leftClick()
	{
		Ray ray = GetComponent<UnityEngine.Camera>().ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if(Physics.Raycast(ray, out hit))
		{
			GameObject obj = hit.collider.gameObject;
			
			if(obj != null)
			{	
				if(obj.tag == "Selectable")
				{
					// Unschöne Lösung!
					if(obj.GetComponent<Unit>() != null)
					{
						deselectAll();
						selected.Add(obj.GetComponent<Unit>());
						selected[0].select(Input.mousePosition.x, Input.mousePosition.y);
					
					}
					if(obj.GetComponent<Building>() != null)
					{
						if(selected.Count > 0)
						{
							if(selected[0] != obj.GetComponent<Building>())
							{
								deselectAll();
							}
						}
						selected.Add(obj.GetComponent<Building>());
						selected[0].select(Input.mousePosition.x, Input.mousePosition.y);
						
					}
				}
				else
				{
					deselectAll();
					Debug.Log("Nothing selected");
				}
			}
			else
			{
				deselectAll();
			}
		}
	}

	private void deselectAll()
	{
		for(int i=0; i < selected.Count; i++)
		{
			selected[i].deselect();
		}

		selected.Clear();
	}

	private void rightClick()
	{
		Ray ray = GetComponent<UnityEngine.Camera>().ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if(Physics.Raycast (ray, out hit))
		{
			for(int i=0; i < selected.Count; i++)
			{
				selected[i].move(hit.point);
			}
		}
	}
}
