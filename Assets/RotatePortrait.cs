using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePortrait : MonoBehaviour
{
    Rigidbody2D rigidBody2D;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        rigidBody2D.rotation = 45f;
    }

    void FixedUpdate()
    {
        rigidBody2D.rotation += 1.0f;
    }
}
