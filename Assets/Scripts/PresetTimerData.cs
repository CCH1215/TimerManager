using System;
using System.Collections.Generic;
using UnityEngine;

namespace CCH.TimerManager
{
	[Serializable]
	public class PresetTimerData
	{
		[SerializeField] string _timerName ;
		public string TimeName => _timerName;
		
		[SerializeField] TimerData _timer;
		public TimerData Timer => _timer;
	}
}
