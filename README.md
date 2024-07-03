# TimerManager

TimerManager provides a easy way to set, operate and remove timer.

![](https://img.shields.io/badge/Unity-2018.2+-17b93.svg?style=flat&logo=unity)
[![](https://img.shields.io/github/v/release/CCH1215/TimerManager
)](https://github.com/CCH1215/TimerManager/releases/)
[![](https://img.shields.io/github/license/CCH1215/TimerManager
)](https://raw.githubusercontent.com/CCH1215/TimerManager/main/LICENSE)


## Set TimerManager
Add TimerManager script as a component

![](https://raw.githubusercontent.com/CCH1215/MyImages/main/TimerManager/AddComponent.png)

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

![](https://raw.githubusercontent.com/CCH1215/MyImages/main/TimerManager/PresetTimer.png)

Add callback to preset(existing) timers
```c#
TimerManager.Instance.AddTimerCallback("1Sec", MyCallback);
```
