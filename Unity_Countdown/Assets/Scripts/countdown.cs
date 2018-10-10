using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countdown: MonoBehaviour {
	static public countdown instance;
	public Transform stage;
	//public Text countdownText;

	List<DateTime> setTimer_destTime = new List<DateTime>
	{
		new DateTime(2018,12,18,09,15,00),
		new DateTime(2019,01,25,09,15,00),
		new DateTime(2019,07,01,00,00,00)
	};
	public List<Timer> setTimers;

	[Header("RUNTIME")]
	public List<timer> runTimers;

	//-----------------------------------------------
	
	[Serializable]
	public class Timer
	{
		public DateTime destTime;
		public string name;
		public Color color;
	}

	void Start() 
	{
		//Screen.fullScreen = true;
		instance = this;
		GameObject clock = Instantiate(Resources.Load<GameObject>("Prefabs/clock"), stage);
		for(int i = 0; i < setTimers.Count; i++)
		{
			setTimers[i].destTime = setTimer_destTime[i];
			runTimers.Add(InitTimer(setTimers[i]));
		}
	}
	void Update() 
	{
		
	}
	
	timer InitTimer(Timer timer)
	{
		GameObject g = Instantiate(Resources.Load<GameObject>("Prefabs/timer"), stage);
		timer t = g.GetComponent<timer>();
		t.isUsedAsClock = false;
		t.myname = timer.name;
		t.myDestTime = timer.destTime;
		t.mycolor = timer.color;
		return g.transform.GetComponent<timer>();
	}

}