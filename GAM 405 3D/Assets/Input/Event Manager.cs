using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class EventManager
{
    public static event Action<bool> TogglePause;
    public static void InvokeTogglePause(bool pause) => TogglePause?.Invoke(pause);
}

