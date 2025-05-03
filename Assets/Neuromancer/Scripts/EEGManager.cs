using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EEGManager : MonoBehaviour
{
    public static EEGManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public bool IsVisual;
    public bool IsMotor;
    public bool IsAlpha;
}
