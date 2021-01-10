using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody2D rigidbody;
    Collider2D collider;
    public Rigidbody2D another;
    public bool isActive;
    int speed = 100;
    bool rotationDir = false;
    int collideWithWater = 0;
    int collideWithPlatform = 0;
    HingeJoint2D hingeJoint;
    public float activeTorque = 50;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        hingeJoint = GetComponent<HingeJoint2D>();
        collider = GetComponent<Collider2D>();
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
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "water")
        {
            collideWithWater++;
        }else if (other.GetComponent<Platformer>())
        {
            collideWithPlatform++;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "water")
        {
            collideWithWater--;
        }
        else if (other.GetComponent<Platformer>())
        {
            collideWithPlatform--;
        }
        else if (other.GetComponent<Collectable>())
        {
            other.GetComponent<Collectable>().Collect();

        }
        else if (other.GetComponent<Enemy>())
        {
            other.GetComponent<Enemy>().Touch();

        }
    }
    public int CanToggle()
    {
        if (hitIceGround())
        {
            return 2;
        }
        if (hitPlatformer())
        {
            return 1;
        }
        if (collideWithWater == 0)
        {
            return 1;
        }
        return 0;
    }

    GameObject hitPlatformer()
    {
        return hitSpecialGround(Globals.Instance.platformers);
    }

    GameObject hitButtons()
    {
        return hitSpecialGround(Globals.Instance.buttons);
    }
    GameObject hitIceGround()
    {
        return hitSpecialGround(Globals.Instance.iceGrounds);
    }
    GameObject hitSpecialGround(List<GameObject> specialGrounds)
    {
        bool foundHingeObject = false;
        foreach (GameObject platformer in specialGrounds)
        {
            Collider2D c = platformer.GetComponent<Collider2D>();
            if (c.bounds.Contains(rigidbody.position))
            {
                // hingeJoint.connectedBody = platformer.GetComponent<Rigidbody2D>();
                //foundHingeObject = true;
                return platformer;
            }
        }
        if (!foundHingeObject)
        {
            // hingeJoint.connectedBody = null;
        }
        return null;
    }
    public void Anchor()
    {
        GameObject hittedPlatformer = hitPlatformer();
        hingeJoint.connectedBody = hittedPlatformer ? hitPlatformer().GetComponent<Rigidbody2D>():null;
        hingeJoint.enabled = true;
        rigidbody.drag = 0;
    }

    void updateConstrains()
    {
        if (isActive)
        {
            // rigidbody.constraints = RigidbodyConstraints2D.None;
            hingeJoint.enabled = false;
            rigidbody.drag = 0;
        }
        else
        {
            //bool foundHingeObject = false;
            //foreach (GameObject platformer in Globals.Instance.platformers)
            //{
            //    Collider2D c = platformer.GetComponent<Collider2D>();
            //    if (collider.bounds.Intersects(c.bounds))
            //    {
            //        hingeJoint.connectedBody = platformer.GetComponent<Rigidbody2D>();
            //        foundHingeObject = true;
            //        break;
            //    }
            //}
            //if (!foundHingeObject)
            //{
            //}
            GameObject iceGround = hitIceGround();
            if (iceGround && iceGround.GetComponent<IceGround>().enabled)
            {
                rigidbody.drag = iceGround.GetComponent<IceGround>().linearDrag;

            }
            else
            {
                Anchor();
                GameObject hitButton = hitButtons();
                if (hitButton)
                {
                    hitButton.GetComponent<PresseableButton>().Press();
                }
            }
            //rigidbody.velocity = Vector2.zero;
            // rigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
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
            GetComponent<Rigidbody2D>().AddTorque(activeTorque, ForceMode2D.Force);
            //Vector2 dir = (rigidbody.position - another.position).normalized;
            //Debug.Log("dir " + dir+" this position "+ rigidbody.position+" center position "+ another.position);
            //Vector2 perpen = Vector2.Perpendicular(dir);
            //GetComponent<Rigidbody2D>().AddForce(perpen * speed);
        }
    }
}
