using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Platformer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Globals.Instance.platformers.Add(gameObject);
    }


    // Update is called once per frame
    void Update()
    {

    }
}
