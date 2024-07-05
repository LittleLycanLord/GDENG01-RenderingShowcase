using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    [SerializeField]
    private bool isOn = false;

    [Header("Flicker")]
    [SerializeField]
    private bool flickers = false;

    [SerializeField]
    private float flickerMinTime = 1f;

    [SerializeField]
    private float flickerMaxTime = 10;

    [SerializeField]
    private Material onMaterial;

    [SerializeField]
    private Material offMaterial;
    private List<Light> lightComponents = new List<Light>();
    private List<GameObject> bulbs = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(flickering());
        foreach (Transform child in this.transform)
        {
            if (child.name == "Bulb")
            {
                bulbs.Add(child.gameObject);
                Light lightComponent = child.GetComponentInChildren<Light>();
                lightComponent.enabled = isOn;
                lightComponents.Add(lightComponent);
            }
        }
    }

    void Update()
    {
        foreach (GameObject bulb in bulbs)
        {
            if (bulb.GetComponentInChildren<Light>().enabled)
            {
                if (transform.Find("Bulb").GetComponent<MeshRenderer>() != null)
                    bulb.GetComponent<MeshRenderer>().material = onMaterial;
            }
            else
            {
                if (transform.Find("Bulb").GetComponent<MeshRenderer>() != null)
                    bulb.GetComponent<MeshRenderer>().material = offMaterial;
            }
        }
    }

    // Update is called once per frame
    IEnumerator flickering()
    {
        while (flickers)
        {
            yield return new WaitForSeconds(Random.Range(flickerMinTime, flickerMaxTime));
            foreach (Light lightComponent in lightComponents)
            {
                lightComponent.enabled = !lightComponent.enabled;
            }
        }
    }
}
