using UnityEngine;
using System.Collections;

public class Screen6 : MonoBehaviour {
	
	public GUISkin skin;
	public string titleName;
	int selectionGridInt = -1;
	private string[] selectionStrings = {"320x240", "480x320", "640x480", "800x600"};
	bool selecting = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI()
	{
		GUI.skin = skin;
		GUI.Box(new Rect(10, 0, 460, 30), titleName, "Title");
		
		//draw Form
		GUI.BeginGroup(new Rect((Screen.width)/2-160, (Screen.height)/2-85, 320, 170));
			GUI.Label(new Rect(0, 5, 150, 40), "Brightness"); 
			GUI.Label(new Rect(0, 45, 150, 40), "Resolution");
			GUI.Label(new Rect(0, 85, 150, 40), "Volumn");
			GlobalScript.brightness = GUI.HorizontalSlider(new Rect(160, 0, 160, 30), GlobalScript.brightness, 0f, 100f);
			if(GUI.Button(new Rect(160, 40, 160, 30), GlobalScript.resolution))
			{
				if(selecting)
				selecting = false;
			else
				selecting = true;
			}
			GlobalScript.volumn = GUI.HorizontalSlider(new Rect(160, 80, 160, 30), GlobalScript.volumn, 0f, 100f);
			
		GUI.EndGroup();
		
		
			//selectionGridInt = GUI.SelectionGrid (new Rect (160, 75, 160, 30*(selectionStrings.Length)), selectionGridInt, selectionStrings,1);
		//draw Buttons
		GUI.BeginGroup(new Rect((Screen.width)/2-160, (Screen.height)/2+100, 320, 30));	
			if(GUI.Button(new Rect(0, 0, 100, 30), "Save", "ButtonGeneral"))
			{
				Application.LoadLevel ("Screen1");
			}
			if(GUI.Button(new Rect(220, 0, 100, 30), "Cancel", "ButtonGeneral"))
			{
				Application.LoadLevel ("Screen1");
			}
		GUI.EndGroup();
		
		
		
		//draw combobox
		
		if(selecting) 
		{
			
			int n = selectionStrings.Length; 
			GUI.Box(new Rect(240, 145, 160, 35*n),"", "Title");
			Rect windowRect0 = new Rect(240, 145, 160, 35*n);
			GUIStyle windowsStyle = new GUIStyle(GUI.skin.window);
			windowsStyle.border = new RectOffset(8, 8, 8, 8);
			windowRect0 = GUI.Window(0, windowRect0, DoMyWindow, "", windowsStyle);
			
		}
	}
	
	 void DoMyWindow(int windowID) {
		int n = selectionStrings.Length; 
        //GUI.BeginGroup(new Rect(240, 145, 160, 35*n));
		GUI.BeginGroup(new Rect(0, 0, 160, 35*n));
			for(int i=0; i<n; i++)
			{
				if(GUI.Button(new Rect(5, i*35+5, 150, 30),selectionStrings[i]))
				{
					selectionGridInt = i;
					GlobalScript.resolution = selectionStrings[selectionGridInt];
					selecting = false;
				}
			}
			GUI.EndGroup();
        
    }
}
