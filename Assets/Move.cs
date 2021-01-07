using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public Rigidbody2D another;
    public bool isActive;
    int speed = 80;
    bool rotationDir = false;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        updateConstrains();
    }
    public Vector2 previousVelocity()
    {
        return rigidbody.velocity;
    }
    public void setVelocity(Vector2 velocity)
    {
        rigidbody.velocity = velocity;
    }
    void updateConstrains()
    {
        if (isActive)
        {
            rigidbody.constraints = RigidbodyConstraints2D.None;

        }
        else
        {
            rigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
           // rigidbody.velocity = Vector2.zero;
            //rigidbody.a
        }
    }
    public void toggleActive()
    {
        isActive = !isActive;
        updateConstrains();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (isActive)
        {

            Vector2 dir = (rigidbody.position - another.position).normalized;
            Vector2 perpen = Vector2.Perpendicular(dir);
            GetComponent<Rigidbody2D>().AddForce(perpen * speed);
        }
    }
}
