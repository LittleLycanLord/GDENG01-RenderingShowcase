using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class Crossfader : MonoBehaviour
{
    //* ╔════════════╗
    //* ║ Components ║
    //* ╚════════════╝
    private CanvasGroup crossfader;
    private Animator animator;

    //* ╔════════╗
    //* ║ Fields ║
    //* ╚════════╝
    [SerializeField]
    [Range(0.0f, 10.0f)]
    private float crossfadeDuration = 5.0f;

    private bool faded = false;

    //* ╔════════════╗
    //* ║ Attributes ║
    //* ╚════════════╝


    //* ╔══════════╗
    //* ║ Displays ║
    //* ╚══════════╝
    // [Header("Displays")]

    //* ╔═══════════════╗
    //* ║ Monobehaviour ║
    //* ╚═══════════════╝
    void Start()
    {
        crossfader = GetComponent<CanvasGroup>();
        animator = GetComponent<Animator>();
        if (faded)
            crossfader.alpha = 1.0f;
        else
            crossfader.alpha = 0.0f;
    }

    void Update()
    {
        animator.speed = 1 / crossfadeDuration;
        animator.SetBool("Faded", faded);
    }

    //* ╔═════════════════════╗
    //* ║ Non - Monobehaviour ║
    //* ╚═════════════════════╝
    public void Fade()
    {
        faded = true;
    }

    public void Fade(float duration)
    {
        faded = true;
        StartCoroutine(DefinedFade(duration));
    }

    private IEnumerator DefinedFade(float duration)
    {
        yield return new WaitForSeconds(duration);
        FadeToScene();
    }

    public void FadeToScene()
    {
        faded = false;
    }
}
