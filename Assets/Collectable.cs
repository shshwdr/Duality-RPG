using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Collect()
    {

        AllUI.Instance.collect();
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
