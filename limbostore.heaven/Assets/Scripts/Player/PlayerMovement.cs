using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public float moveSpeed = 1f;
    public bool movementEnabled = true;    

    private void Update()
    {
        if(movementEnabled)
        {
            Move();
        }
    }

    private void Move()
    {
        float horizontal = Input.GetAxis(InputStrings.HorizontalAxis);
        float vertical = Input.GetAxis(InputStrings.VerticalAxis);
        Vector2 movementAmount = new Vector2(horizontal, vertical);
        rb.velocity = movementAmount * moveSpeed;
    }
}
