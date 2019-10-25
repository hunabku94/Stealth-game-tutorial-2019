using UnityEngine;

public class LaserBlinking : MonoBehaviour
{
    [SerializeField] float onTime = 0f;             // Amount of time in seconds the laser is on for.
    [SerializeField] float offTime = 0f;            // Amount of time in seconds the laser is off for.

    float timer = 0f;                               // Timer to time the laser blinking.

    Renderer rendererComponent = null;
    Light lightComponent = null;

    void Awake ()
    {
        rendererComponent = GetComponent<Renderer>();
        lightComponent = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update ()
    {
        // Increment the timer by the amount of time since the last frame.
        timer += Time.deltaTime;

        // If the beam is on and the onTime has been reached...
        if (rendererComponent.enabled && timer >= onTime)
        {
            // Switch the beam.
            SwitchBeam();
        }

        // If the beam is off and the offTime has been reached...
        if (!rendererComponent.enabled && timer >= offTime)
        {
            // Switch the beam.
            SwitchBeam();
        }
    }

    void SwitchBeam ()
    {
        // Reset the timer.
        timer = 0f;

        // Switch whether the beam and light are on or off.
        rendererComponent.enabled = !rendererComponent.enabled;
        lightComponent.enabled = !lightComponent.enabled;
    }
}
