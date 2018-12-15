using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SubjectNerd.Utilities;

public class countdown: MonoBehaviour {
	static public countdown instance;
	public Transform stage;
	
	

	[Header("RUNTIME")]
	[Reorderable]
	public List<timer> runTimers;

	//-----------------------------------------------
	[Serializable]
	public class Timers
	{
		public List<Timer> setTimers;
	}
	
	[Serializable]
	public class Timer
	{
		public string name;
		public string dest = "2020/02/02 20:20:00";//for input
		public Color color;
	}

	void Start() 
	{
		instance = this;
		string save = Resources.Load<TextAsset>("SetTimers").text;
		List<Timer> setTimers = JsonUtility.FromJson<Timers>(save).setTimers;
		
		GameObject clock = Instantiate(Resources.Load<GameObject>("Prefabs/clock"), stage);
		for(int i = 0; i < setTimers.Count; i++)
		{
			timer x = InitTimer(setTimers[i]);
			if(x)
				runTimers.Add(x);
		}
	}
	void Update() 
	{
		
	}
	
	timer InitTimer(Timer timer)
	{
		DateTime destTime = DateTime.Parse(timer.dest, System.Globalization.CultureInfo.GetCultureInfo("zh-TW").DateTimeFormat);
		if(destTime.Subtract(DateTime.Now).TotalSeconds > 0)
		{
			GameObject g = Instantiate(Resources.Load<GameObject>("Prefabs/timer"), stage);
			timer t = g.GetComponent<timer>();
			t.isUsedAsClock = false;
			t.myname = timer.name;
			t.myDestTime = destTime;
			t.mycolor = timer.color;
			return g.transform.GetComponent<timer>();
		}
		else
		{
			Debug.LogWarning(timer.name+"時間已過");
			return null;
		}
	}

}