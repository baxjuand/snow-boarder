using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    Rigidbody2D rigBod2d;

    void Start()
    {
        rigBod2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
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
