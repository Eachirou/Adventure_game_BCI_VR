using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource Music;
    public AudioSource SFX;
    public AudioSource Dialogue;

    public List<AudioClip> SfxClips = new List<AudioClip>();

    public void PlayDialogue()
    {
        Dialogue.Play();
    }

    public void PlaySfx(int sfxIndex)
    {
        SFX.clip = SfxClips[sfxIndex];
        SFX.Play();
    }

    public void PlayTeleportSfx()
    {
        SFX.clip = SfxClips[10];
        Invoke("PlayDelayedSfx", 1f);
    }

    private void PlayDelayedSfx()
    {
        SFX.Play();
    }
}
