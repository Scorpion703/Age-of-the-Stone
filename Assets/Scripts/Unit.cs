using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour 
{
	private int speed = 5;
	public int life = 20;

	public Vector3 destination;
	
	void Start()
	{
		destination = new Vector3(transform.position.x, 0, transform.position.z);
		Debug.Log (destination);
	}
	
	// Update is called once per frame
	void Update () 
	{
		float diffX = destination.x - transform.position.x;
		float diffZ = destination.z - transform.position.z;
		float diffTotal = Mathf.Sqrt(diffX * diffX + diffZ * diffZ);
		
		if(diffTotal > 1)
		{
			// Bewege dich zum Ziel
			
			Vector3 temp = new Vector3(diffX/diffTotal, 0, diffZ/diffTotal);
			temp.Normalize();
			temp = temp * Time.deltaTime * speed;
			
			transform.Translate(temp, Space.World);
		}
	}
}
