using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class TeleportController : MonoBehaviour
{
    public List<Transform> TeleportLocations = new List<Transform>();
    public Transform Player;
    public VignetteController Vignette;
    public AudioManager AudioManager;
    private int _locationId = 0;

    public void TeleportToLocation(int locationId)
    {
        Vignette.Vignette();
        AudioManager.PlayTeleportSfx();
        Invoke("TeleportDelay", 1f);
    }
    private void TeleportDelay()
    {
        Player.position = TeleportLocations[_locationId].position;
    }
}
