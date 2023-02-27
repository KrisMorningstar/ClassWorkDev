using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Only one instance should exist");
        }
    }

    public delegate void LoseHealth(float _damage);
    public static LoseHealth loseHealthEvent;

    public delegate void GainHealth(float _damage);
    public static GainHealth gainHealthEvent;

    public delegate void ChangeLight(int lightID, string lightName);
    public static ChangeLight changeLightEvent;

    public delegate void IncreaseCarsWaiting(int amount, string lightName);
    public static IncreaseCarsWaiting increaseCarsWaitingEvent;
}
