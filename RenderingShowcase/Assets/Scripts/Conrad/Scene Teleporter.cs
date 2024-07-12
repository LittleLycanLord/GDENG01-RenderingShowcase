using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTeleporter : MonoBehaviour
{
    AudioManager audioManager;

    [SerializeField]
    string targetScene;

    void Start()
    {
        audioManager = AudioManager.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag != "Player")
            return;
        
        Debug.Log("Switching to " + targetScene + "...");
        if (targetScene == null || targetScene.Equals(""))
            Debug.LogWarning(name + "'s Target Scene not set.");
        else
        {
            StartCoroutine(
                GameObject
                    .Find("Crossfader")
                    ?.GetComponent<CrossfadeSceneSwitcher>()
                    ?.CrossfadeToScene(targetScene)
            );
            audioManager.Play("Horror Stinger");
        }
    }
}
