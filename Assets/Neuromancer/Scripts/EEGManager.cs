using System.Collections;
using System.Collections.Generic;
using Gtec.UnityInterface;
using UnityEngine;
using UnityEngine.Events;
using static Gtec.Chain.Common.Nodes.InputNodes.ChannelQuality;

public class EEGManager : MonoBehaviour
{
    public static EEGManager Instance { get; private set; }
    private string serialName = "UN-0000.00.00"; //EEG Headset name is UN-2023.03.17, for testing can use UN-0000.00.00
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
        ConnectToDevice();
    }

    public void ConnectToDevice()
    {
        BciDevice.Connect(serialName);

        OnConnect.Invoke();
    }

    #region Signal Quality Pipeline Events
    public void OnSignalQualityAvailable(List<ChannelStates> channelStates)
    {
        string channelStatesString = string.Empty;
        for (int i = 0; i < channelStates.Count; i++)
            channelStatesString += string.Format("{0}: {1}, ", i + 1, channelStates[i].ToString());
        Debug.Log(channelStatesString);
    }

    public void OnDataAvailable(float[,] e)
    {
        string channelDataString = string.Empty;
        for (int row = 0; row < e.GetLength(0); row++)
            for (int col = 0; col < e.GetLength(1); col++)
                channelDataString += string.Format("Frame:{0}, EEG Channel:{1}, Value:{2}, ", row + 1, col + 1, e[row, col].ToString());
        Debug.Log(channelDataString);
    }
    #endregion
}
