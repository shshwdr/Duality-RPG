using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public Transform targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();
        rigidbody = GetComponent<Rigidbody2D>();
        //Vector3 myVector = Vector3.zero;
        //DOTween.To(() => myVector, x => myVector = x, new Vector3(3, 4, 8), 1);
       // transform.DOMove(new Vector3(2, 2, 2), 1);
        rigidbody.DOMove((Vector2)targetPosition.position,1).SetLoops(-1, LoopType.Yoyo);
        //DOTween.To(() => rigidbody.position, x => (Vector2)targetPosition.position = x,(Vector2) targetPosition.position, 1).SetUpdate(true);

    }

    public void Touch()
    {
        AllUI.Instance.damage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
