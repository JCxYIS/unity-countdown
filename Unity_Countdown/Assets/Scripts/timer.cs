using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour {
	[Tooltip("TRUE: show currTime")]
	public bool isUsedAsClock;
	public DateTime myDestTime;
	public string myname;
	public Text Name;
	public Color mycolor;
	public JumpingNumberTextComponent day;
	public JumpingNumberTextComponent hr;
	public JumpingNumberTextComponent min;
	public JumpingNumberTextComponent sec;
	public JumpingNumberTextComponent secff;
	public Text timeformator;
	public Transform mainDisplays;
	bool firstFrame = true;

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		Name.text = myname;
		Name.color = Color.white;
		timeformator.color = Color.white;
		for(int i = 0; i < mainDisplays.childCount; i++)
			mainDisplays.GetChild(i).GetComponent<Text>().color = mycolor;
		
	}
	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		if(!isUsedAsClock)
		{
			TimeSpan mySpan = myDestTime.Subtract(DateTime.Now);
			day.ChangeTo(mySpan.Days, firstFrame);
			hr.ChangeTo(mySpan.Hours, firstFrame);
			min.ChangeTo(mySpan.Minutes, firstFrame);
			sec.ChangeTo(mySpan.Seconds, firstFrame);
			secff.ChangeTo(mySpan.Milliseconds / 10, firstFrame);
			//Debug.Log(mytime.Milliseconds);
		}
		else
		{
			day.ChangeTo(DateTime.Now.Month*100+DateTime.Now.Day, firstFrame);
			hr.ChangeTo(DateTime.Now.Hour, firstFrame);
			min.ChangeTo(DateTime.Now.Minute, firstFrame);
			sec.ChangeTo(DateTime.Now.Second, firstFrame);
		}
		firstFrame = false;
	}
}
