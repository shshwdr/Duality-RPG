using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllUI : Singleton<AllUI>
{

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void damage(int value = 1)
    {
        Debug.Log("damage " + value);
    }
    public void collect(int value = 1)
    {
        Debug.Log("collect " + value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
