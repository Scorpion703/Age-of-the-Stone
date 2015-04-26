using UnityEngine;
using System.Collections;

public class Unit : Selectable 
{
	public int food = 0;
	public int wood = 0;
	public int stone = 0;

	//private int speed = 5;
	public int life = 20;
	NavMeshAgent agent;

	public Vector3 destination;
	
	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		destination = new Vector3(transform.position.x + Random.Range(-5, 5), 0, transform.position.z - 2);
		agent.SetDestination(destination);
	}
	
	// Update is called once per frame
	void Update() 
	{
		agent.SetDestination(destination);
	}

	public override void  move(Vector3 dest)
	{
		this.destination = dest;
	}
	
}
