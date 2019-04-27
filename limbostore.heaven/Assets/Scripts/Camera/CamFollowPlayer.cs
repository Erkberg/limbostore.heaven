using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    public Transform player;

    private float followSmoothTime = 0.33f;
    private Vector3 followRefVelocity;

    private Vector3 camToPlayerOffset = new Vector3(0f, 0f, -10f);

    private void Start()
    {
        if(!player)
        {
            player = GameObject.FindGameObjectWithTag(Tags.PlayerTag).transform;
        }
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.position + camToPlayerOffset, ref followRefVelocity, followSmoothTime);
    }
}
