using UnityEngine;
using System.Collections;

public class Screen5 : MonoBehaviour {
	
	public AudioClip clip;
	bool isRecording = false;
	bool isPlaying = false;
	bool isCounting = false;
	bool allowCounting = false;
	float[] data = new float[44100*3];
	float threshold1 = 0f;
	float threshold2 = 0f;
	float threshold3 = 0.00034234f;
	int dataLength = 0;
	string devices;
	float dataTime = 0f;
	int iii =0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!Microphone.IsRecording(null))
		{
			isRecording = false;
//			if(allowCounting && !isCounting)
//			{
//				isCounting = true;
//				countThreshold();
//			}
		}
		if(!audio.isPlaying)
		{
			isPlaying = false;
		}
		
	}
	
	void startMicrophone()
	{
		audio.clip = Microphone.Start(null, false, 3, 44100);
		if(allowCounting && !isCounting)
		{
			isCounting = true;
			countThreshold();
		}
		//yield return new WaitForSeconds (3.0f);
		//isRecording = false;
	}
	void playClip()
	{
		//audio.clip = clip;
		audio.Play();
//		yield return new WaitForSeconds (clip.length);
//		isPlaying = false;
			
	}
	
	void countThreshold()
	{
		//Counting
		//audio.clip = clip;
		//data = new float[44100*3];
		audio.GetOutputData(data, 0);
		dataLength = data.Length;
		
		foreach(float s in data)
    	{
			iii++;
			dataTime = s;
			threshold1 += Mathf.Abs(s);
//			if((i%2) == 0)
//			{
//				threshold2+=Mathf.Abs(data[i]);
//			}
		}
//		threshold1 = threshold1/dataLength;
//		threshold2 = threshold2/(dataLength/2);
		//finishing counting only one time until press record button next time
		isCounting = false;
		allowCounting = false;
	}
	
	public void OnGUI()
	{
		
		GUI.skin.label.normal.textColor = Color.black;
		if(GUI.Button(new Rect(0, 0, 50, 50), "quit"))
		{
			Application.Quit();
		}
		GUI.Label(new Rect(100, 30, 350, 50), "iii = "+ iii + "dataTime = " + dataTime.ToString());
		for(int i = 0; i<Microphone.devices.Length; i++)
		{
			devices =Microphone.devices[i].ToString()+"; ";
		}
		GUI.Label(new Rect(100, 100, 350, 50), "Device: "+ devices);
		GUI.Label(new Rect(100, 150, 350, 50), "isRecording= "+ isRecording.ToString()+ "; isPlaying = "+isPlaying.ToString());
		
		//print out audio clip
		if((audio.clip)!=null)
		{
			GUI.Label(new Rect(100, 200, 350, 50), "audio.clip.length = "+audio.clip.length);
		}
		else{
			GUI.Label(new Rect(100, 200, 350, 40), "audio.clip.length = 0");
		}
		
		//print out threshold
		GUI.Label(new Rect(30, 240, 350, 40), "threshold1 = "+ threshold1.ToString() +"; threshold2 = "+ threshold2.ToString() +"; threshold3 = "+ threshold3.ToString()+ "; datalength = "+ dataLength.ToString());
		
		//button record
		if(isRecording==false)
		{
			if(GUI.Button(new Rect(50, 280, 100, 30), "record"))
			{
				isRecording = true;
				allowCounting = true;
				startMicrophone();
			}
		}	
		if(isRecording)
		{
			GUI.Label(new Rect(50, 280, 100, 30), "recoding");
		}
		
		//button play
		if(isPlaying==false)
		{
			if(GUI.Button(new Rect(300, 280, 100, 30), "play"))
			{
				if(!isRecording)
				{
					isPlaying = true;
					playClip();
				}
			}
		}
		if(isPlaying)
		{
			GUI.Label(new Rect(300, 280, 100, 30), "playing");
		}
		
		
	}
}
