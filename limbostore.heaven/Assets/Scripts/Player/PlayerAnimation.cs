using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;

    private const string movingBool = "moving";
    private const string runningBool = "running";
    private const string sneakingBool = "sneaking";

    public void SetMoving(bool moving)
    {
        animator.SetBool(movingBool, moving);
    }

    public void SetRunning(bool running)
    {
        animator.SetBool(runningBool, running);
    }

    public void SetSneaking(bool sneaking)
    {
        animator.SetBool(sneakingBool, sneaking);
    }
}
