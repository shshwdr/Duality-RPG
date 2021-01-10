using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public AudioClip collectClip;
    public int type = 0;
    private void Awake()
    {

        if (type == 0)
        {
            AllUI.Instance.coin_total += 1;
        }
        else if (type == 1)
        {
            AllUI.Instance.chest_total += 1;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
    }
    public void Collect()
    {

        AllUI.Instance.collect(type, collectClip);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
