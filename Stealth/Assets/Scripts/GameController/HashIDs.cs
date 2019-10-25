using UnityEngine;

public class HashIDs : MonoBehaviour
{
    // Here we store the hash tags for various strings used in our animators.
    public int dyingState = 0;
    public int locomotionState = 0;
    public int shoutState = 0;
    public int deadBool = 0;
    public int speedFloat = 0;
    public int sneakingBool = 0;
    public int shoutingBool = 0;
    public int playerInSightBool = 0;
    public int shotFloat = 0;
    public int aimWeightFloat = 0;
    public int angularSpeedFloat = 0;
    public int openBool = 0;
    
    void Awake ()
    {
        dyingState = Animator.StringToHash("Base.Dying");
        locomotionState = Animator.StringToHash("Base.Locomotion");
        shoutState = Animator.StringToHash("Shouting.Shout");
        deadBool = Animator.StringToHash("Dead");
        speedFloat = Animator.StringToHash("Speed");
        sneakingBool = Animator.StringToHash("Sneaking");
        shoutingBool = Animator.StringToHash("Shouting");

        playerInSightBool = Animator.StringToHash("PlayerInSight");
        shotFloat = Animator.StringToHash("Shot");
        aimWeightFloat = Animator.StringToHash("AimWeight");
        angularSpeedFloat = Animator.StringToHash("AngularSpeed");
        openBool = Animator.StringToHash("Open");
    }
}
