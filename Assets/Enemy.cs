using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{

    public void Touch()
    {
        AllUI.Instance.damage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
