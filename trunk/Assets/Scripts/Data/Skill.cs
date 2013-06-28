using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Skill : object 
{
	public int id;
	public string name;
	public int pet;
	public string isloop;
	public string symbol;
	
	List<Movement> lMove;
	
	public Skill()
	{
		lMove = new List<Movement>();
	}
	
	public void SetData(string fstr)
	{
		lMove.Clear();
		string[] strs = fstr.Split('_');
		id = int.Parse(strs[0]);
		name = strs[1];
		pet = int.Parse(strs[2]);
		isloop = strs[3];
		symbol = strs[4];
		
		Service1 ser = new Service1();
		int[] idMoves = ser.GetListMovement(id);
		
		for(int i = 0; i < idMoves.Length; ++i)
		{
			Movement tMove = new Movement();
			tMove.SetData(ser.GetMovement(idMoves[i]));
			
			lMove.Add(tMove);
		}
	}
}
