using UnityEngine;
using System.Collections;

public class GetIP : MonoBehaviour 
{
	
	public GUISkin skin;
	public string myExtIP = "-1";
	
	public void Start () 
	{
		StartCoroutine(getIP());
	}
	
	void Update () 
	{	
	}
	
	IEnumerator getIP()
	{
		WWW myExtIPWWW = new WWW("http://checkip.dyndns.org");
		if (myExtIPWWW != null)
		{
			yield return myExtIPWWW;
			myExtIP = myExtIPWWW.text;
			myExtIP = myExtIP.Substring (myExtIP.IndexOf (":") + 2);
			myExtIP = myExtIP.Substring (0, myExtIP.IndexOf ("<"));
		}
		else
		{
			myExtIP = "error1";
		}
	}
	
	void OnGUI()
	{
		GUI.skin = skin;
		
		GUI.Label(new Rect(100, 50, 250, 50), "IP is:", "LabelNormal");
		GUI.Label(new Rect(100, 100, 250, 50), myExtIP, "LabelNormal");
	}
}
