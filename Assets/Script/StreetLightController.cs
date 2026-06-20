using UnityEngine;

public class StreetLightController : MonoBehaviour
{
    public Light Sun;

    private Light[] StreetLights;

    void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("StreetLight");

        StreetLights = new Light[objs.Length];

        for (int i = 0; i < objs.Length; i++)
        {
            StreetLights[i] = objs[i].GetComponent<Light>();
        }
    }

    void Update()
    {
        bool isNight = Sun.transform.forward.y < -0.1f;

        foreach (Light l in StreetLights)
        {
            if (l != null)
                l.enabled = isNight;
        }
    }

}
