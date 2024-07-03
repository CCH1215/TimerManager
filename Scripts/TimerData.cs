using System;
using System.Collections.Generic;
using UnityEngine;

namespace CCH.TimerManager
{
	[Serializable]
	public class TimerData
	{
		[SerializeField] float _timeGap = 1;
		public float TimeGap
		{
			get => _timeGap;
			set => _timeGap = value;
		}
		
		[SerializeField] bool _onlyDoOnce;
		public bool OnlyDoOnce
		{
			get => _onlyDoOnce;
			set => _onlyDoOnce = value;
		}
		
		[SerializeField] float _timeScale = 1;
		
		[SerializeField] bool _autoRemove;
		public bool AutoRemove
		{
			get => _autoRemove;
			set => _autoRemove = value;
		}

		public bool RemoveCheck()
		{
			return _autoRemove && !_countTime;
		}

		float _timer;
		event Action _timeUpAction;
		bool _pause;
		bool _countTime;

		public bool CountTime => _countTime;

		readonly object _lock = new();
		
		public event Action TimeUpAction
		{
			add
			{
				lock (_lock)
				{
					if (_timeUpAction == null)
					{
						_timer = _timeGap;
						_countTime = true;
					}
					_timeUpAction += value;
				}
			}
			
			remove
			{
				lock (_lock)
				{
					_timeUpAction -= value;
					if (_timeUpAction == null)
					{
						_countTime = false;
					}
				}
			}
		}

		public void UpdateTimer(float time)
		{
			if (!_countTime || _pause)
			{
				return;
			}

			_timer -= (time * _timeScale);
			if (_timer <= 0)
			{
				_timeUpAction?.Invoke();
				if (_onlyDoOnce)
				{
					_countTime = false;
				}
				else
				{
					_timer += _timeGap;
				}
			}
		}

		public void Pause()
		{
			_pause = true;
		}
		
		public void Resume()
		{
			_pause = false;
		}

		public void SetTimeScale(float timeScale)
		{
			_timeScale = timeScale;
		}
	}
}
