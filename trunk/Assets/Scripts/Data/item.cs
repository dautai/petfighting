	using UnityEngine;
using System.Collections;

public class item: object
{
	public string name;
	public int priceSell;
	public int priceBuy;
	public int valueMana;
	public int valueBlood;
	public float percentAttack;
	public float percentDefence;
	public string avatar;
	public int id;
		
	public item (int id1,string name1, int priceSell1, int priceBuy1, int valueMana1, int valueBlood1, float percentAttack1, float percentDefence1, string avatar1)
	{
		id=id1;
		name = name1;
		priceSell = priceSell1;
		priceBuy = priceBuy1;
		valueMana = valueMana1;
		valueBlood = valueBlood1;
		percentAttack = percentAttack1;
		percentDefence = percentDefence1;
		avatar = avatar1;
	}
}
