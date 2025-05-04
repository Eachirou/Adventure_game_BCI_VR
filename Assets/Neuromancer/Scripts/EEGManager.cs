using System.Collections;
using System.Collections.Generic;
using Gtec.UnityInterface;
using UnityEngine;
using UnityEngine.Events;

public class EEGManager : MonoBehaviour
{
    public static EEGManager Instance { get; private set; }
    private string serialName = "UN-2023.03.17"; //EEG Headset name is UN-2023.03.17, for testing can use UN-0000.00.00
    [SerializeField] private Device BciDevice;
    public UnityEvent OnConnect;

    public bool IsVisual;
    public bool IsMotor;
    public bool IsAlpha;

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

    private void Start()
    {
        Invoke("ConnectToDevice", 5f);
    }

    public void ConnectToDevice()
    {
        BciDevice.Connect(serialName);

        OnConnect.Invoke();
    }
}
