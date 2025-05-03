using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EEGInteractableObject : MonoBehaviour
{
    [SerializeField] EEGSignalTypes EEGSignalType = new EEGSignalTypes();
    public GameObject VisualSignalReceiverUI;
}

public enum EEGSignalTypes
{
    Visual = 1,
    Motor = 2,
    Alpha = 3
}
