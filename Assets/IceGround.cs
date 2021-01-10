using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceGround : MonoBehaviour
{
    public  float linearDrag = 10;
    // Start is called before the first frame update
    void Start()
    {

        Globals.Instance.iceGrounds.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Move movePart = collision.GetComponent<Move>();
        if (movePart && !movePart.isActive)
        {
            movePart.Anchor();
            
        }
    }
}
