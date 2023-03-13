using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeControler : MonoBehaviour
{
    public ConfigurableJoint joint;
    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {

        //joint = this.GetComponent<ConfigurableJoint>();


        //ball = gameObject.GetComponentInParent<car>().ball;
        //joint.connectedBody = ball.GetComponent<Rigidbody>();
    }

}
