using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppEvents
{
    public delegate void MouseCursorEnable(bool enable); //Delegate
    public static event MouseCursorEnable MouseCurserEnable; //Event

    public static void Invoke_MouseCursorEnable(bool enabled)
    {
        MouseCurserEnable?.Invoke(enabled);
    }
}
