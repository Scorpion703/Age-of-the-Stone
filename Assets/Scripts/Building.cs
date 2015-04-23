using UnityEngine;
using System.Collections;

public class Building : Selectable 
{
	public int life = 20;
	public bool isStorage = true;
	public GameObject[] creatableUnits;
	public float spawnDistance;
	public GameObject cam;

	private float selectedX = 0;
	private float selectedY = 0;

	private int createId = -1;

	float x = 0;

	void Start()
	{
		
	}
	
	void Update()
	{
		if(createId >= 0)
		{
			x += Time.deltaTime;
			if(x > 10)
			{
				GameObject target = creatableUnits[0];

				Vector3 creationPoint = transform.position;
				creationPoint.z -= spawnDistance;

				target.transform.position = creationPoint;

				Instantiate(target);
				
				x = 0;
				createId = -1;
			}
		}
	}

	void OnGUI()
	{
	 	if(selected)
	 	{
	 		if(createId >= 0)
	 		{
	 			GUI.Box(new Rect(selectedX, Screen.height - selectedY, 100, 40), "Einheit bereit \nin " + (10-x) + "s" );
	 		}
	 		else
	 		{
	 			for(int i=0; i<creatableUnits.Length; i++)
			 	{
			 		if(GUI.Button(new Rect(selectedX, Screen.height -selectedY + (i*30), 60, 20), creatableUnits[i].name)) 
				 	{
			            createId = i;
			        }
			 	}
	 		}
	 	}
	}

	public void select(float x, float y)
	{
		selectedX = x;
		selectedY = y;
		selected = true;
	}

	public void deselect()
	{
		selectedX = 0;
		selectedY = 0;
		selected = false;
	}




}
