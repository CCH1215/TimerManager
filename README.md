# TimerManager

TimerManager provides a easy way to set, operate and remove timer.

![Made with Unity](https://img.shields.io/badge/Made_with-Unity-red.svg?style=flat&logo=unity)

## Set TimerManager
Add TimerManager script as a component

![](https://raw.githubusercontent.com/CCH1215/TimerManager/main/Assets/AddComponent.png)

## Example
Add a custom timer.

If timerName is existing, this would only add callback to the timer with the name of timerName.
```c#
TimerManager.Instance.AddTimer(timerName, 3.0f, MyCallback, autoRemove:false);
```
Pause a timer
```c#
TimerManager.Instance.SetTimerPause("TimerName", true);
```
Resume a timer
```c#
TimerManager.Instance.SetTimerPause("TimerName", false);
```

Preset Timer

![](https://raw.githubusercontent.com/CCH1215/TimerManager/main/Assets/PresetTimer.png)

Add callback to preset(existing) timers
```c#
TimerManager.Instance.AddTimerCallback("1Sec", MyCallback);
```
