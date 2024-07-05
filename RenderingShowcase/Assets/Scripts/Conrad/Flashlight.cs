using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField]
    private int level = 0;
    private Light flashlight;

    // Start is called before the first frame update
    void Start()
    {
        flashlight = GetComponentInChildren<Light>();
    }

    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            if (level == 3)
                level = 0;
            else
                level++;
        }
        flashlight.intensity = level;
        flashlight.range = 20 + (level * 2);
    }
}
