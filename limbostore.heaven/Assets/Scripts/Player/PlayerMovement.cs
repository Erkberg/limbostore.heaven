using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Refs")]
    public Rigidbody2D rb;
    public PlayerAnimation playerAnimation;
    [Header("Speeds")]
    public float moveSpeed = 1f;
    public float runMultiplier = 2f;
    public float sneakMultiplier = 0.5f;
    [Header("State")]
    public bool isMoving = false;
    public bool isRunning = false;
    public bool isSneaking = false;

    private Vector3 startingPosition;
    private Quaternion startingRotation;

    private void Start()
    {
        startingPosition = transform.position;
        startingRotation = transform.rotation;
        GameManager.Current.events.Death.AddListener(PlayerDeath);
        GameManager.Current.events.NewGame.AddListener(Reset);
        GameManager.Current.events.Sneak.AddListener(() => SetSneaking(true));
        GameManager.Current.events.StopSneak.AddListener(() => SetSneaking(false));
    }

    void PlayerDeath()
    {
        
    }

    public void Reset()
    {
        transform.position = startingPosition;
        transform.rotation = startingRotation;
        isRunning = false;
        isMoving = false;
        isSneaking = false;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
    }

    private void Update()
    {
        if(!GameManager.Current.PlayerLocked)
        {
            Move();

            if(rb.velocity != Vector2.zero)
            {
                playerAnimation.SetMoving(true);
                isMoving = true;
                Rotate(rb.velocity);
            }
            else
            {
                playerAnimation.SetMoving(false);
                isMoving = false;
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void Move()
    {
        float horizontal = Input.GetAxis(InputStrings.HorizontalAxis);
        float vertical = Input.GetAxis(InputStrings.VerticalAxis);
        Vector2 movementAmount = new Vector2(horizontal, vertical).normalized;

        if (isSneaking)
        {
            movementAmount *= sneakMultiplier;
        }
        else
        {
            CheckRunning(ref movementAmount);    
        }
        //CheckSneaking(ref movementAmount);

        rb.velocity = movementAmount * moveSpeed;
    }

    private void Rotate(Vector3 movement)
    {
        float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
        playerAnimation.transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void CheckRunning(ref Vector2 movementAmount)
    {
        if(Input.GetButton(InputStrings.RunButton))
        {
            SetRunning(true);
            isRunning = true;
            movementAmount *= runMultiplier;
        }
        else
        {
            SetRunning(false);
        }
    }

    private void SetRunning(bool running)
    {
        playerAnimation.SetRunning(running);
        isRunning = running;
    }

    private void CheckSneaking(ref Vector2 movementAmount)
    {
        if (GameManager.Current.skillz.CanDo(SkillType.Sneak))
        {
            if (Input.GetButton(InputStrings.SneakButton))
            {
                SetSneaking(true);
                isSneaking = true;
                movementAmount *= sneakMultiplier;
            }
            else
            {
                SetSneaking(false);
            }
        }
        else
        {
            SetSneaking(false);
        }
    }

    private void SetSneaking(bool sneaking)
    {
        playerAnimation.SetSneaking(sneaking);
        isSneaking = sneaking;
    }
}
