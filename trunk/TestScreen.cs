using UnityEngine;
using System.Collections;

public class TestScreen : MonoBehaviour {
	public GUISkin skin;
	private Rect windowRect = new Rect(20, 20, 120, 50);
    private Rect windowRect2 = new Rect(80, 20, 120, 50);
    void OnGUI() {
		GUI.skin = skin;
        windowRect = GUI.Window(0, windowRect, DoMyFirstWindow, "First");
        windowRect2 = GUI.Window(1, windowRect2, DoMySecondWindow, "Second");
		if(GUI.Button(new Rect(20, 35, 179, 40), "Options", "ButtonGeneral"))
		{
			Application.LoadLevel("Screen6");
		}
		
    }
    void DoMyFirstWindow(int windowID) {
        if (GUI.Button(new Rect(10, 20, 100, 20), "Bring to front"))
            GUI.BringWindowToFront(1);
        
        GUI.DragWindow(new Rect(0, 0, 10000, 20));
    }
    void DoMySecondWindow(int windowID) {
        if (GUI.Button(new Rect(10, 20, 100, 20), "Bring to front"))
            GUI.BringWindowToFront(0);
        
        GUI.DragWindow(new Rect(0, 0, 10000, 20));
    }
}
