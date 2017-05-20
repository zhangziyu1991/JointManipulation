using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{

    public Transform target;
    public float speed;
    public Transform start;

    private Vector3 frometh;
    private Vector3 untoeth;

    void Start()
    {
        frometh = start.position;
        untoeth = target.position;
    }


    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        if (transform.position == untoeth)
        {
            //Debug.Log("AAAAA");
            transform.position = frometh;
        }
    }

}