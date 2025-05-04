using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    public List<GameObject> gameObjects = new List<GameObject>();

    public void EnableOneDisableRest(int id)
    {
        foreach (GameObject go in gameObjects)
        {
            go.SetActive(false);
        }
        gameObjects[id].SetActive(true);
    }
}
