using UnityEngine;
using System.Collections;

public class Movement : object 
{
	public string name;
	public string typeMove;
	public int manaCost;
	public int energy;
	public float timeHappen;
	public string avatar;
	
	public void SetData(string fstr)
	{
		string[] strs = fstr.Split('_');
		name = strs[0];
		typeMove = strs[1];
		manaCost = int.Parse(strs[2]);
		energy = int.Parse(strs[3]);
		timeHappen = float.Parse(strs[4]);
		avatar = strs[5];		
	}

}
