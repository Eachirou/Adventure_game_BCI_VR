using UnityEngine;

public class FlowerGrowController : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;

    void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Call this to trigger both the animation and sound
    public void PlayGrowSequence()
    {
        if (animator != null)
        {
            animator.Play("FlowerGrow");
        }

        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
