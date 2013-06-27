using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PetData : object 
{
	public int petID;
	public string petName;
	public int petType;
	public int levelPet;
	public List<Medal> medals;
	public int mana;
	public int maxMana;
	public int food;
	public int maxFood;
	public int rate;
	public int xp;
	public List<Skill> lSkill;
	
	public PetData()
	{
		lSkill = new List<Skill>();
		medals = new List<Medal>();
	}
	
	public void SetData(string str)
	{
		string[] strs = str.Split('_');
		petID = int.Parse(strs[0]);
		petName = strs[1];
		petType = int.Parse(strs[2]);
		levelPet = int.Parse(strs[3]);
		GetMedal(strs[4]);
		mana = int.Parse(strs[5]);
		maxMana = int.Parse(strs[6]);
		food = int.Parse(strs[7]);
		maxFood = int.Parse(strs[8]);
		rate = int.Parse(strs[9]);
		xp = int.Parse(strs[10]);
		//getskill
		SetSkill();
	}
	
	public void SetSkillFromString(string fstr)
	{
		lSkill.Clear();
		string[] strs = fstr.Split('=');
		for(int i = 0; i < strs.Length; ++i)
		{
			Skill tSkill = new Skill();
			tSkill.SetData(strs[i]);
			
			lSkill.Add(tSkill);
		}
	}
	
	public void SetSkill()
	{
		Service1 ser = new Service1();
		int[] moves = ser.GetListMovement(petID);
		
		foreach(int move in moves)
		{
			string str = "";

			str = ser.GetMovement(move);			
			Skill tSkill = new Skill();
			tSkill.SetData(str);
			
			lSkill.Add(tSkill);			
		}
		
	}
	
	public void GetMedal(string fStr)
	{
		medals = new List<Medal>();
		string[] lMedal = fStr.Split('|');
		Service1 ser = new Service1();
		foreach(string str in lMedal)
		{
			string rs = ser.GetMedal(int.Parse(str));
			Medal tMedal = new Medal();
			tMedal.SetData(rs);
			
			medals.Add(tMedal);
		}
	}
}
