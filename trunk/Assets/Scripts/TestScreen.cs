using UnityEngine;
using System.Collections;

public class TestScreen : MonoBehaviour {
    public static int guiDepth = 0;
    
	void OnGUI() {
        GUI.Box(new Rect(100, 100, 100, 50), "txt = ["+ split("0123?456789")+"]");
    }


	string split(string main)
	{
		return main.Substring(0, main.IndexOf("?"));
	}
}

