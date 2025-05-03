using System.Collections;
using System.Collections.Generic;
using Gtec.UnityInterface;
using UnityEngine;

public class EEGConfigurationManager : MonoBehaviour
{
    public GameObject ConfigurationUI;
    private ERPParadigm _erpParadigm;

    private void Awake()
    {
        StartConfiguration();
    }

    private void StartConfiguration()
    {
        ConfigurationUI.SetActive(true);
        Debug.Log("Im here!");
        _erpParadigm.StartParadigm(ParadigmMode.Training);
    }
}
