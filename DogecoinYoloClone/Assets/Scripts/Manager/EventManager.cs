using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{

    public static UnityEvent OnPressedUp = new UnityEvent();
    public static UnityEvent OnPressedDown = new UnityEvent();

    public static UnityEvent OnCubeFinished = new UnityEvent();



}
