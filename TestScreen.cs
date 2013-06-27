using UnityEngine;
using System.Collections;

public class TestScreen : MonoBehaviour
{
	public GUISkin skin;
	string text = "";
	public GameObject audioInputObject;
	public float threshold = 10.0f;
	MicrophoneInput micIn;
	bool speak = false;
	float volumn = 0.0f;
	int timeStart = 0;
	int timer = 0;
	
	float tempthreshold = 10.0f;

	void Start ()
	{
		foreach (string device in Microphone.devices) {
			Debug.Log ("Name: " + device);
			text += device + "\n==";
		}
		if (audioInputObject == null)
			audioInputObject = GameObject.Find ("MicMonitor");
		micIn = (MicrophoneInput)audioInputObject.GetComponent ("MicrophoneInput");
	}

	void Update ()
	{
		if(micIn.isRecording)
		{
			volumn = micIn.loudness;
			tempthreshold +=volumn;
			if (volumn > threshold) {
				speak = true;
			} else {
				speak = false;
			}
		}
		
		
	}
	
	void OnGUI ()
	{
		GUI.skin = skin;

		GUI.Label (new Rect (20, 20, 300, 30), text, "LabelNormal");
		
		GUI.Label (new Rect (290, 190, 100, 20), "Threshold = " + threshold.ToString () + "; l = " + volumn.ToString (), "LabelNormal");
		
		GUI.Label (new Rect (100, 200-(int)volumn, 10, (int)volumn), "", "WindowCover");
		
		
		if(micIn.isRecording)
		{
			timer = (int)Time.time - timeStart;
			GUI.Label (new Rect (380, 250, 70, 50), "Timer = " + timer, "LabelNormal");
		}
		
		GUI.Button (new Rect (100, 50, 20, 20), "", "ButtonGeneral");
		if (speak == true) {
			GUI.Button (new Rect (200, 50, 100, 100), "", "ButtonGeneral");
		}
		
		if (GUI.Button (new Rect (0, 0, 50, 50), "Quit")) {
			Application.Quit ();
		}
		
		if (GUI.Button (new Rect (200, 250, 70, 50), "Play", "ButtonGeneral")) {
			audio.PlayOneShot(micIn.clip);
		}
		
		if (GUI.Button (new Rect (100, 250, 70, 50), "Record", "ButtonGeneral")) {
			micIn.record();
			timeStart = (int)Time.time;
		}
		
		//tim nguong
	}

}
