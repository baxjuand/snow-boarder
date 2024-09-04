using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float defaultSpeed = 20f;
    [SerializeField] float boostAmount = 1f;
    SurfaceEffector2D surfaceEffector2D;
    Rigidbody2D rigBod2d;
    bool canMove = true;

    void Start()
    {
        rigBod2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
        
    }

    public void DisableControls()
    {
        canMove = false;
    }
    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            surfaceEffector2D.speed /= boostAmount;
        }
        else
        {
            surfaceEffector2D.speed = defaultSpeed;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rigBod2d.AddTorque(torqueAmount);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            rigBod2d.AddTorque(-torqueAmount);
        }
    }
}
