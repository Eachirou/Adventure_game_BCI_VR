using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlowManager : MonoBehaviour
{
    // PlayerPositions list
    // ObjectsV to look at
    // ObjecstM to imagine a gesture at
    // ObjectsA to close eyes at

    //Big ugly class dont do this at home kids

    public TeleportController TeleportController;
    public AudioManager AudioManager;
    public UImanager UImanager;
    public VisualTargetsManager VisualTargetsManager;

    private void Start()
    {
        Invoke("StartSection1", 1f);
    }

    //SECTION 1
    public void StartSection1()
    {
        TeleportController.TeleportToLocation(0);
        UImanager.EnableOneDisableRest(0);
        VisualTargetsManager.StartVisualPuzzle(0);
    }

    //SECTION 2
    public void StartSection2()
    {
        //TeleportController.TeleportToLocation(1);
        AudioManager.PlaySfx(2);
        UImanager.EnableOneDisableRest(1);
        VisualTargetsManager.StartVisualPuzzle(1);
    }

    //SECTION 3
    public void StartSection3()
    {
        UImanager.EnableOneDisableRest(2);
        // TODO
    }

    //SECTION 4
    public void StartSection4()
    {

    }

    //SECTION 5
    public void StartSection5()
    {

    }

    //SECTION 6
    public void StartSection6()
    {

    }

    //SECTION 7
    public void StartSection7()
    {

    }

    //SECTION 8
    public void StartSection8()
    {

    }

    //SECTION 9
    public void StartSection9()
    {

    }

    //SECTION 10
    public void StartSection10()
    {

    }

    public void OnVisualPuzzleVerify(int puzzleId)
    {
        switch (puzzleId)
        {
            case 0:
                TeleportController.TeleportToLocation(1);
                Invoke("StartSection2", 2f);
                break;
            case 1:
                TeleportController.TeleportToLocation(2);
                Invoke("StartSection3", 2f);
                break;
            default:
                Console.WriteLine("huh");
                break;
        }
    }
}
