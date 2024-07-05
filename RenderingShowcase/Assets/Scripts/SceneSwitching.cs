using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitching : MonoBehaviour
{
    [SerializeField] private string ConradScene_Tag;
    [SerializeField] private string LanceScene_Tag;
    [SerializeField] private string NicoScene_Tag;
    [SerializeField] private string CurrentScene_Tag;

    private void loadScene()
    {
        if (CurrentScene_Tag == ConradScene_Tag)
        {
            SceneManager.LoadScene("Conrad's Workspace");
        }
        else if (CurrentScene_Tag == LanceScene_Tag)
        {
            SceneManager.LoadScene("Lance's Workspace");
        }
        else if (CurrentScene_Tag == NicoScene_Tag)
        {
            SceneManager.LoadScene("Nico's Workspace");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Player"))
        {
            this.loadScene();
        }
    }
}
