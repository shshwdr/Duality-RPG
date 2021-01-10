using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Patrol : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public Transform targetPosition;
    public float patrolTime = 3;
    public float waitTime = 2;
    public float intervalTime = 5;
    public bool patrol = true;
    // Start is called before the first frame update
    void Start()
    {
        if (!targetPosition)
        {
            targetPosition = transform.GetChild(0).GetComponentInChildren<Transform>();
            Debug.Log("update target position " + targetPosition);
        }
        DOTween.Init();
        rigidbody = GetComponent<Rigidbody2D>();
        Vector2 originPosition = rigidbody.position;
        //Vector3 myVector = Vector3.zero;
        //DOTween.To(() => myVector, x => myVector = x, new Vector3(3, 4, 8), 1);
        // transform.DOMove(new Vector3(2, 2, 2), 1);
        if (patrol)
        {
            Sequence seq = DOTween.Sequence();
            seq.Append(rigidbody.DOMove((Vector2)targetPosition.position, patrolTime));
            seq.AppendInterval(waitTime);
            seq.Append(rigidbody.DOMove(originPosition, patrolTime));

            seq.AppendInterval(intervalTime);
            seq.SetLoops(-1, LoopType.Restart);

            
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
