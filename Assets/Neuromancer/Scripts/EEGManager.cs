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
    public EEGConfigurationManager ConfigManager;

    public bool IsSimulating;
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
        if (IsSimulating)
            serialName = "UN-0000.00.00";
        Invoke("ConnectToDevice", 5f);
    }

    public void ConnectToDevice()
    {
        BciDevice.Connect(serialName);

        if (IsSimulating)
            ConfigManager.IsSimulating();
        ConfigManager.gameObject.SetActive(true);
    }

    //public void Reconnect(Device device)
    //{
    //    Debug.Log("Attempting to reconnect...");
    //    BciDevice.Disconnect();
    //    BciDevice = device;
    //    BciDevice.Connect(serialName);
    //}
}
