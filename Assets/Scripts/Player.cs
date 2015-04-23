using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public int food = 0;
	public int wood = 0;
	public int stone = 0;

	void OnGUI()
	{
		GUI.Box(new Rect(0, 0, 150, 100),  
			"Nahrung: " + food + "\n" +
			"Holz: " + wood + "\n" +
			"Stein: " + stone);
	}

	public bool cost(int food, int wood, int stone)
	{
		bool cond1 = this.food >= food;
		bool cond2 = this.wood >= wood;
		bool cond3 = this.stone >= stone;

		if(cond1 && cond2 && cond3)
		{
			this.food -= food;
			this.wood -= wood;
			this.stone -= stone;

			return true;
		}
		return false;
	}
}
