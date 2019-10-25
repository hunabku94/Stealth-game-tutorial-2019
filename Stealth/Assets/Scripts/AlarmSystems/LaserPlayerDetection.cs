using UnityEngine;

public class LaserPlayerDetection : MonoBehaviour
{
    GameObject player = null;                           // Reference to the player.
    LastPlayerSighting lastPlayerSighting = null;      // Reference to the global last sighting of the player.

    Renderer rendererComponent = null;

    void Awake ()
    {
        rendererComponent = GetComponent<Renderer>();

        // Setting up references.
        player = GameObject.FindGameObjectWithTag(Tags.player);
        lastPlayerSighting = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<LastPlayerSighting>();
    }

    void OnTriggerStay (Collider other)
    {
        // If the beam is on...
        if (rendererComponent.enabled)
        {

            // ... and if the colliding gameobject is the player...
            if (other.gameObject == player)
            {
                // ... set the last global sighting of the player to the colliding object's position.
                lastPlayerSighting.position = other.transform.position;
            }

        }
    }
}
