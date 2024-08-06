using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeRotations : MonoBehaviour
{
    
    private void Awake()
    {
        Vector3 rot = Vector3.zero;
        rot.y = Random.Range(-180f, 180f);
        transform.Rotate(rot);

        Vector3 offset = Vector3.zero;
        offset.x = Random.Range(-0.25f, 0.25f);
        offset.z = Random.Range(-0.25f, 0.25f);

        transform.Translate(offset);


        if (Random.Range(0, 100) < 50)
            gameObject.SetActive(false);
    }

}
