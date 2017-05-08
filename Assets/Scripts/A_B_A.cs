using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_B_A : MonoBehaviour {

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
        if (transform.position == untoeth) {
            //Debug.Log("AAAAA");
            transform.position = frometh;
        }
    }

    /*void OnCollisionEnter(Collision col)
    {
        Debug.Log("AAAAAA");
        Debug.Log(col.gameObject);
        if (col.gameObject.tag == "WallDown")
        {
            Debug.Log("BBBBBB");
            //EndGame = true;​
            //Destroy(col.gameObject);
        }
    }*/

    /*public Transform farEnd;
    private Vector3 frometh;
    private Vector3 untoeth;
    private float secondsForOneLength = 7f;

    void Start()
    {
        frometh = transform.position;
        untoeth = farEnd.position;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(frometh, untoeth,
         Mathf.SmoothStep(0f, 1f,
          Mathf.PingPong(Time.time / secondsForOneLength, 1f)
        ));

        if (transform.position.z < -20) {
            Debug.Log("AAA");
            transform.position = frometh;
            Debug.Log(frometh);
            Debug.Log(transform.position);
        }*/
    /*transform.position = Vector3.Lerp(frometh, untoeth, 10 * Time.deltaTime);*/
}
