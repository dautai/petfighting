using UnityEngine;
using System.Collections;

public class Screen19 : MonoBehaviour {
	
	public GUISkin skin;
	public string titleName;
	public Texture2D iconScene;
	
	Vector2 scrollViewVector = Vector2.zero;
	string[] movement;
	int nuMovment =-1;
	// Use this for initialization
	void Start () {
		titleName = "Lika: Create Skill, Step 2"; //get name of the current pet
		iconScene = Resources.Load("image5") as Texture2D; // Load avatar of pet
		movement = new string[14];
		movement[0] = "stop";
		movement[1] = "Screen19-Top";
		movement[2] = "Screen19-Down";
		movement[3] = "Screen19-Left";
		movement[4] = "Screen19-Right";
		movement[5] = "image34";
		movement[6] = "image32";
		movement[7] = "image37";
		movement[8] = "image33";
		movement[9] = "image36";
		movement[10] = "image38";
		movement[11] = "image35";
		movement[12] = "image39";
		movement[13] = "image29";
		nuMovment = movement.Length;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI()
	{
		GUI.skin = skin;
		GUI.Box(new Rect(55, 0, 370, 30), titleName, "Title");
		GUI.Label(new Rect(430, 0, 50, 50), iconScene, "LabelNormal");
		GlobalScript.DrawAvatar();
		
		
		drawTable(((int)nuMovment/3) + 1, 3);
	}
	
	void drawTable(int row, int column)
	{
		GUI.Box(new Rect (308, 42, 172, 228), "", "BoxGroup1");
		scrollViewVector = GUI.BeginScrollView (new Rect (316, 50, 156, 210), scrollViewVector, new Rect (0, 0, 140, 45*row)); //45 is height of a movement cell	
			int n = 0;
			for(int i=0; i<row; i++)
			{
				for(int j = 0; j<column; j++)
				{
					if(n<nuMovment)
					{
						Texture2D avatar = Resources.Load(movement[i*3+j])as Texture2D;
						GUI.Box (new Rect(4+j*45, 4+i*45, 42, 42),"", "WindowCover");
						GUI.Label(new Rect(5+j*45, 5+i*45, 40, 40), avatar, "LabelNormal");
					}
					n++;
				}
			}
		GUI.EndScrollView();
	}
}
