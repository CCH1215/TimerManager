using System;
using System.Collections.Generic;
using UnityEngine;

namespace CCH.TimerManager
{
    public class TimerManager : MonoBehaviour
    {
        static TimerManager _instance = null;
        public static TimerManager Instance => _instance;
        bool _countTime = true;
        Dictionary<string, TimerData> _timerDataDictionary;

        [SerializeField] List<PresetTimerData> _presetTimers;
        
        void Awake()
        {
	        _instance = this;
	        _timerDataDictionary = new Dictionary<string, TimerData>();
	        SetPresetTimer();
        }

        #region -- Update --
		void Update()
		{
            if (_countTime)
            {
	            UpdateTimer(Time.deltaTime);
            }
		}

		void UpdateTimer(float deltaTime)
		{
			foreach (var timerData in _timerDataDictionary)
			{
				var timer = timerData.Value;
				timer.UpdateTimer(deltaTime);
				if (timer.RemoveCheck())
				{
					AddTimerToRemove(timerData.Key);
				}
			}

			if (_timerNamesToRemove.Count > 0)
			{
				RemoveTimerProcess();
			}
		}
		#endregion

		#region -- timer operation --
		TimerData CreateTimer(string timerName)
		{
			var timer = new TimerData();
			_timerDataDictionary[timerName] = timer;
			return timer;
		}
		
		TimerData GetTimer(string timerName)
		{
			if (!_timerDataDictionary.TryGetValue(timerName, out var timer))
			{
				Debug.LogWarning($"No timer data for key:{timerName}");
			}
			return timer;
		}

		void SetPresetTimer()
		{
			foreach (var presetTimer in _presetTimers)
			{
				_timerDataDictionary[presetTimer.TimeName] = presetTimer.Timer;
			}
		}
		
		/// <summary>
		/// Add a timer
		/// </summary>
		/// <param name="timerName">Name to operate timer.</param>
		/// <param name="timeGap">How long this timer would be triggered.</param>
		/// <param name="callback">A callback action would be call, everytime this timer is triggered.</param>
		/// <param name="onlyDoOnce">If true, this timer would be triggered one time only.</param>
		/// <param name="autoRemove">If true, this timer would be removed when onlyDoOnce is true or no callback.</param>
		public void AddTimer(string timerName, float timeGap, Action callback, bool onlyDoOnce = false, bool autoRemove = true)
		{
			var timer = GetTimer(timerName);
			if (timer == null)
			{
				timer = CreateTimer(timerName);
				timer.TimeGap = timeGap;
				timer.OnlyDoOnce = onlyDoOnce;
				timer.AutoRemove = autoRemove;
			}
			else
			{
				Debug.LogWarning($"Using existing timer:{timerName}");
			}
			timer.TimeUpAction += callback;
		}

		List<string> _timerNamesToRemove = new();
		public void AddTimerToRemove(string timerName)
		{
			_timerNamesToRemove.Add(timerName);
		}

		void RemoveTimerProcess()
		{
			foreach (var timerName in _timerNamesToRemove)
			{
				_timerDataDictionary.Remove(timerName);
			}
			_timerNamesToRemove.Clear();
		}
		
		public void AddTimerCallback(string timerName, Action callback)
		{
			var timer = GetTimer(timerName);
			timer.TimeUpAction += callback;
		}
		
		public void RemoveTimerCallback(string timerName, Action callback)
		{
			var timer = GetTimer(timerName);
			timer.TimeUpAction -= callback;
		}
		
		public void SetTimerPause(string timerName, bool isPause)
		{
			var timer = GetTimer(timerName);
			if (timer != null)
			{
				if (isPause)
				{
					timer.Pause();
				}
				else
				{
					timer.Resume();
				}
			}
		}

		public void SetTimerTimeScale(string timerName, float timeScale)
		{
			var timer = GetTimer(timerName);
			timer?.SetTimeScale(timeScale);
		}
		#endregion
    }
}
