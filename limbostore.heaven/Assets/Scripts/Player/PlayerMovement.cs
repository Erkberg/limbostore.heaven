using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform sprite;

    public float moveSpeed = 1f;
    public bool movementEnabled = true;    

    private void Update()
    {
        if(movementEnabled)
        {
            Move();

            if(rb.velocity != Vector2.zero)
            {
                Rotate(rb.velocity);
            }
        }
    }

    private void Move()
    {
        float horizontal = Input.GetAxis(InputStrings.HorizontalAxis);
        float vertical = Input.GetAxis(InputStrings.VerticalAxis);
        Vector2 movementAmount = new Vector2(horizontal, vertical);
        rb.velocity = movementAmount * moveSpeed;
    }

    private void Rotate(Vector3 movement)
    {
        float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
        sprite.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
