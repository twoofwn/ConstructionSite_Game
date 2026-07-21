using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public float dayDuration = 60f;

    void Update()
    {
        float rotationSpeed = 360f / dayDuration;

        transform.Rotate(
            rotationSpeed * Time.deltaTime,
            0,
            0
        );

        float sunHeight = transform.forward.y;

        Light sun = GetComponent<Light>();
        sun.intensity = Mathf.Clamp01(sunHeight * 2f);
        //float t = Mathf.Clamp01(sunHeight * 0.5f + 0.5f);
        //sun.intensity = Mathf.Lerp(0f, 70000f, t);
    }

}
