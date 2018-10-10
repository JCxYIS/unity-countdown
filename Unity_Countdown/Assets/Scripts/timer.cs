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
			day.ChangeTo(mySpan.Days);
			hr.ChangeTo(mySpan.Hours);
			min.ChangeTo(mySpan.Minutes);
			sec.ChangeTo(mySpan.Seconds);
			secff.ChangeTo(mySpan.Milliseconds / 10);
			//Debug.Log(mytime.Milliseconds);
		}
		else
		{
			day.ChangeTo(DateTime.Now.Month*100+DateTime.Now.Day);
			hr.ChangeTo(DateTime.Now.Hour);
			min.ChangeTo(DateTime.Now.Minute);
			sec.ChangeTo(DateTime.Now.Second);
		}
	}
}
