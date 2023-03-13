using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ropeRenderer : MonoBehaviour
{
    private LineRenderer lr;
    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        lr = gameObject.GetComponent<LineRenderer>();
        lr.positionCount = 2;
        //ball = gameObject.GetComponentInParent<car>().ball;
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        lr.SetPosition(0, this.transform.position);
        if (ball != null)
            lr.SetPosition(1, ball.transform.position);
    }
}
