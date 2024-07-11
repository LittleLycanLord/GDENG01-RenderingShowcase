using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Crossfader))]
public class CrossfadeSceneSwitcher : MonoBehaviour
{
    //* ╔════════════╗
    //* ║ Components ║
    //* ╚════════════╝
    Crossfader crossfader;

    //* ╔════════╗
    //* ║ Fields ║
    //* ╚════════╝
    [SerializeField]
    [Range(0.5f, 10.0f)]
    float crossfadeDuration = 1.0f;

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
        crossfader = GetComponent<Crossfader>();
    }

    public IEnumerator CrossfadeToScene(string sceneName)
    {
        Debug.Log("Fading to " + sceneName + "...");
        crossfader.Fade();
        yield return new WaitForSeconds(crossfadeDuration);
        SceneManager.LoadScene(sceneName);
    }

    //* ╔═════════════════════╗
    //* ║ Non - Monobehaviour ║
    //* ╚═════════════════════╝
}
