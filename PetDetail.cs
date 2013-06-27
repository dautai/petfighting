using UnityEngine;
using System.Collections;

public class PetDetail : object 
{
	public int id;
	public string atomType;
	public string typeName;
	public string avatar;
	public string detail;
	
	public void SetData(string fStr)
	{
		string[] strs = fStr.Split('_');
		id = int.Parse(strs[0]);
		atomType = strs[1];
		typeName = strs[2];
		avatar = strs[3];
		detail = strs[4];		
	}

}
