﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {



	public class TimedEvent {
		public float TimeToExecute;
		public Callback Method;
	}

	public delegate void Callback();
	private List<TimedEvent> events;


	public void Add (Callback method, float inSeconds) {
		events.Add (new TimedEvent {
			Method = method,
			TimeToExecute = Time.time + inSeconds
		}); 
	}


	void Awake () {
		events = new List<TimedEvent> ();
	}
	

	void Update () {
		if (events.Count == 0)
			return;

		for (int i = 0; i < events.Count; i++) {
			var timedEvent = events [i];

			if (timedEvent.TimeToExecute <= Time.time) {
				timedEvent.Method ();
				events.Remove (timedEvent);
			}
		}
	}


}
