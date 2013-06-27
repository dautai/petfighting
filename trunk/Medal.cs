using UnityEngine;
using System.Collections;

public class Medal : object 
{
	public string name;
	public string imageFile;
	
	
	public void SetData(string fStr)
	{
		string[] strs = fStr.Split('|');
		
		name = strs[0];
		imageFile = strs[1];
	}
}
