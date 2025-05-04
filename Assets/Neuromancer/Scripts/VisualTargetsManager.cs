using System.Collections;
using System.Collections.Generic;
using Gtec.Chain.Common.SignalProcessingPipelines;
using Gtec.Chain.Common.Templates.Utilities;
using Gtec.UnityInterface;
using UnityEngine;

public class VisualTargetsManager : MonoBehaviour
{
    public EEGManager EEGManager;
    public GameFlowManager GameFlowManager;
    public List<Transform> TargetLocations = new List<Transform>();
    public GameObject ErpTag;
    public GameObject ErpTagNeuron;
    public ERPParadigm _erpParadigm;
    public Gtec.UnityInterface.ERPPipeline _erpPipeline;
    private int _currentPuzzleId = 0;

    public void StartVisualPuzzle(int targetLocationId)
    {
        _currentPuzzleId = targetLocationId;
        _erpPipeline.OnCalibrationResult.AddListener(OnClassifierAvailable);
        ErpTag.SetActive(true);
        ErpTag.transform.position = TargetLocations[targetLocationId].position;
        ErpTagNeuron.SetActive(true);
        ErpTagNeuron.transform.position = TargetLocations[targetLocationId].position;
        _erpParadigm.StartParadigm(ParadigmMode.Training);
    }

    public void VerifyVisualPuzzleFinished()
    {
        _erpParadigm.StopParadigm();
        GameFlowManager.OnVisualPuzzleVerify(_currentPuzzleId);
        ErpTag.SetActive(false);
        ErpTagNeuron.SetActive(false);
    }

    private void OnClassifierAvailable(ERPParadigm paradigm, CalibrationResult result)
    {
        EventHandler.Instance.Enqueue(() =>
        {
            Debug.Log("HERE 1");
            if (result != null && paradigm != null)
            {
                if (result.CalibrationQuality == CalibrationQuality.Good || result.CalibrationQuality == CalibrationQuality.Ok)
                {
                    VerifyVisualPuzzleFinished();
                }
                else if (result.CalibrationQuality == CalibrationQuality.Bad)
                {
                    if (EEGManager.IsSimulating)
                    {
                        Debug.Log("HERE 2");
                        VerifyVisualPuzzleFinished();
                    }
                    else
                    {
                        Debug.Log("HERE 3");
                        _erpParadigm.StartParadigm(ParadigmMode.Training);
                    }
                }
            }
            else
            {
                //Null?
                Debug.Log("HERE 4");
            }
        });
    }
}
