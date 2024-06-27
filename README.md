# TimerManager

TimerManager provides a easy way to set, operate and remove timer.

[![](https://img.shields.io/badge/any_text-you_like-blue)](https://openupm.com/packages/com.coffee.ui-particle/)
![Made with Unity](https://img.shields.io/badge/Made_with-Unity-red.svg?style=flat&logo=unity)
![Made with Unity](https://img.shields.io/badge/Made_with-Unity-57b9d3.svg?style=flat&logo=unity)

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
