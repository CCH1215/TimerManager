# TimerManager

TimerManager provides a easy way to set, operate and remove timer.

![Made with Unity](https://img.shields.io/badge/Made_with-Unity-red.svg?style=flat&logo=unity)

## Set TimerManager
Add TimerManager script as a component


## Example
Add a custom timer
```c#
TimerManager.Instance.AddTimer(_timerName, 3.0f, CustomTimeUp, autoRemove:false);
```
Pause a timer
```c#
TimerManager.Instance.SetTimerPause("TimerName", true);
```
Resume a timer
```c#
TimerManager.Instance.SetTimerPause("TimerName", false);
```
