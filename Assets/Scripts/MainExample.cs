using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CCH.TimerManager;
using TMPro;
using UnityEngine.UI;

public class MainExample : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI _1SecText;
	[SerializeField] TextMeshProUGUI _5SecText;
	[SerializeField] TextMeshProUGUI _customText;
	
	[SerializeField] TextMeshProUGUI _pauseBottonText;
	[SerializeField] TextMeshProUGUI _timeScaleBottonText;
	
	bool _pause = false;
	float _timeScale = 1.0f;
	const string _timerName = "CustomTimer";

	void Start()
	{
		InitTimer();

		Debug.Log($"Start time:{DateTime.Now}");
		InitUI();
	}

	void InitTimer()
	{
		// Add to preset timers
		TimerManager.Instance.AddTimerCallback("1Sec", OneSecTimerUp);
		TimerManager.Instance.AddTimerCallback("5Sec", FiveSecTimerUp);
		
		// Add a custom timer
		TimerManager.Instance.AddTimer(_timerName, 3.0f, CustomTimeUp, autoRemove:false);
	}
	
	void InitUI()
	{
		CustomTimeUp();
		OneSecTimerUp();
		FiveSecTimerUp();

		SetPauseBottonText();
		SetTimeScaleBottonText();
	}

	void CustomTimeUp()
	{
		_customText.text = $"{DateTime.Now:HH:mm:ss}";
	}

	void OneSecTimerUp()
	{
		_1SecText.text = $"{DateTime.Now:HH:mm:ss}";
	}

	void FiveSecTimerUp()
	{
		_5SecText.text = $"{DateTime.Now:HH:mm:ss}";
	}

	void SetPauseBottonText()
	{
		_pauseBottonText.text = _pause ? "Resume" : "Pause";
	}
	
	void SetTimeScaleBottonText()
	{
		_timeScaleBottonText.text = $"TimeScale:{_timeScale}";
	}
	
	
	public void ClickPauseButton()
	{
		_pause = !_pause;
		SetPauseBottonText();
		TimerManager.Instance.SetTimerPause(_timerName, _pause);
	}

	public void ClickSetTimeScaleButton()
	{
		// timeScale: 1 is normal, bigger is faster and vice versa.
		_timeScale = Mathf.Approximately(_timeScale, 1.0f) ? 0.5f : 1.0f;
		SetTimeScaleBottonText();
		TimerManager.Instance.SetTimerTimeScale(_timerName, _timeScale);
	}

	public void ClickRemoveCallbackButton()
	{
		TimerManager.Instance.RemoveTimerCallback(_timerName, CustomTimeUp);
	}
}