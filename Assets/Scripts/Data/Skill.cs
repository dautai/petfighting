using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Skill : object 
{
	string name;
	List<Movement> lMove;
	
	public Skill()
	{
		lMove = new List<Movement>();
	}
	
	public void SetData(string fstr)
	{
		lMove.Clear();
		string[] strs = fstr.Split('+');
		name = strs[0];
		for(int i = 1; i < strs.Length; ++i)
		{
			Movement tMove = new Movement();
			tMove.SetData(strs[i]);
			
			lMove.Add(tMove);
		}
	}
}
