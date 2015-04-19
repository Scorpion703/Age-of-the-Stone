using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour 
{
	private int speed = 5;
	public int life = 20;
	NavMeshAgent agent;
	public Transform target;

	public Vector3 destination;
	
	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		destination = new Vector3(transform.position.x, 0, transform.position.z);
		Debug.Log (destination);
	}
	
	// Update is called once per frame
	void Update () 
	{
		agent.SetDestination (destination);
	}
	
}
