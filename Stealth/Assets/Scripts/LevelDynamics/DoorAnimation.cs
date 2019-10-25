using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    public bool requireKey = false;                         // Whether or not a key is required.
    public AudioClip doorSwishClip = null;                  // Clip to play when the doors open or close.
    public AudioClip accessDeniedClip = null;               // Clip to play when the player doesn't have the key for the door.

    Animator anim = null;                                   // Reference to the animator component.
    HashIDs hash = null;                                    // Reference to the HashIDs script.
    GameObject player = null;                               // Reference to the player GameObject.
    PlayerInventory playerInventory = null;                 // Reference to the PlayerInventory script.
    int count = 0;                                          // The number of colliders present that should open the doors.

    private AudioSource audioSource = null;

    void Awake ()
    {
        // Setting up the references.
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashIDs>();
        player = GameObject.FindGameObjectWithTag(Tags.player);
        playerInventory = player.GetComponent<PlayerInventory>();
    }

    void Update ()
    {
        // Set the open parameter.
        anim.SetBool(hash.openBool, count > 0);

        // If the door is opening or closing...
        if (anim.IsInTransition(0) && !audioSource.isPlaying)
        {
            // ... play the door swish audio clip.
            audioSource.clip = doorSwishClip;
            audioSource.Play();
        }
    }

    void OnTriggerEnter (Collider other)
    {
        // If the triggering gameobject is the player...
        if (other.gameObject == player)
        {
            // ... if this door requires a key...
            if (requireKey)
            {
                // ... if the player has the key...
                if (playerInventory.hasKey)
                {
                    // ... increase the count of triggering objects.
                    count++;
                }
                else
                {
                    // If the player doesn't have the key play the access denied audio clip.
                    audioSource.clip = accessDeniedClip;
                    audioSource.Play();
                }
            }
            else
            {
                // If the door doesn't require a key, increase the count of triggering objects.
                count++;
            }
        }
        // If the triggering gameobject is an enemy...
        else if (other.gameObject.tag == Tags.enemy)
        {
            // ... if the triggering collider is a capsule collider...
            if (other is CapsuleCollider)
            {
                // ... increase the count of triggering objects.
                count++;
            }
        }
    }

    void OnTriggerExit (Collider other)
    {
        // If the leaving gameobject is the player or an enemy and the collider is a capsule collider...
        if (other.gameObject == player || (other.gameObject.tag == Tags.enemy && other is CapsuleCollider))
        {
            // decrease the count of triggering objects.
            count = Mathf.Max(0, count - 1);
        }
    }

}
