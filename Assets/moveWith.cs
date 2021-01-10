using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveWith : MonoBehaviour
{
    public GameObject moveWithObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = moveWithObject.transform.position;
    }
}
