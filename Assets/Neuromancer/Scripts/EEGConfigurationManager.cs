using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Gtec.Chain.Common.SignalProcessingPipelines;
using Gtec.Chain.Common.Templates.Utilities;
using Gtec.UnityInterface;
using UnityEngine;
using UnityEngine.UI;
using static Gtec.Chain.Common.Nodes.InputNodes.ChannelQuality;

public class EEGConfigurationManager : MonoBehaviour
{
    // Start configuration with test of 1.
    // IF passed, test all 5 for 30 seconds.
    // After the time, load the beginning of the game.

    public bool CheckForTest1 = true;
    public float WaitTimeTest2 = 30f;

    public GameObject ConfigurationText1;
    public GameObject ConfigurationText2;
    public ERPParadigm _erpParadigm;
    public Gtec.UnityInterface.ERPPipeline _erpPipeline;
    public GameObject GameFlowManager;
    public GameObject BciConfiguration;
    //public GameObject BciGameplay;

    public Device Device;
    public EEGManager EEGManager;

    public List<GameObject> SpinningNeurons = new List<GameObject>();

    //The Brain
    public UnityEngine.Color ChannelGood;
    public UnityEngine.Color ChannelBad;
    public SignalQualityPipeline _signalQualityPipeline;
    public List<Image> Images = new List<Image>();

    public List<GameObject> ObjectsToDisable = new List<GameObject>();  

    private void Awake()
    {
        StartConfiguration();
        _erpPipeline.OnCalibrationResult.AddListener(OnClassifierAvailable);
        _signalQualityPipeline.OnSignalQualityAvailable.AddListener(OnSignalQualityAvailable);
    }

    private void StartConfiguration()
    {
        ConfigurationText1.SetActive(true);
        Invoke("StartParadigmTraining", 5f);
    }

    private void StartParadigmTraining()
    {
        _erpParadigm.StartParadigm(ParadigmMode.Training); //ParadigmMode.Training for one
    }

    private void StartParadigmApplication()
    {
        ConfigurationText1.SetActive(false);
        ConfigurationText2.SetActive(true);
        foreach (GameObject go in SpinningNeurons)
        { 
            go.SetActive(true); 
        }
        _erpParadigm.StartParadigm(ParadigmMode.Application); //ParadigmMode.Application for five
        Invoke("StartGameFlow", WaitTimeTest2);
    }

    private void OnClassifierAvailable(ERPParadigm paradigm, CalibrationResult result)
    {
        EventHandler.Instance.Enqueue(() =>
        {
            if (result != null && paradigm != null)
            {
                if (result.CalibrationQuality == CalibrationQuality.Good || result.CalibrationQuality == CalibrationQuality.Ok)
                {
                    //Continue to Test 2
                    StartParadigmApplication();
                }
                else if (result.CalibrationQuality == CalibrationQuality.Bad)
                {
                    if (CheckForTest1)
                    {
                        //Redo Test 1
                        StartParadigmTraining();
                    }
                    else
                    {
                        StartParadigmApplication();
                    }
                }
            }
            else
            {
                //Null?
            }
        });
    }

    private void StartGameFlow()
    {
        _erpParadigm.StopParadigm();
        //BciConfiguration.SetActive(false);
        //BciGameplay.SetActive(true);
        //EEGManager.Reconnect(Device);
        BciConfiguration.transform.position = new Vector3(0f, 2f, 0f);
        foreach(GameObject go in ObjectsToDisable)
        {
            go.SetActive(false);
        }
        GameFlowManager.SetActive(true);
    }

    private void OnSignalQualityAvailable(List<ChannelStates> signalQuality)
    {
        for (int i = 0; i < signalQuality.Count; i++)
        {
            if (signalQuality[i].Equals(ChannelStates.Good))
                Images[i].color = ChannelGood;
            else
                Images[i].color = ChannelBad;
            Debug.Log("Channel " + i + ": " + signalQuality[i].ToString());
        }
    }

    public void IsSimulating()
    {
        CheckForTest1 = false;
    }
}
