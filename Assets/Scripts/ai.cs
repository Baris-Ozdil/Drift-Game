using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ai : MonoBehaviour
{
    private Vector3 moveForce;
    public GameObject ball;
    groundCheck groundCheck;
    List<GameObject[]> targets = new List<GameObject[]>();
    public GameObject target;

    public float moveSpeed = 50;
    public float maxSpeed = 15;
    public float stearAngle = 15;
    public float drag = 0.98f;
    public float traction = 1;
    public float airCorrectSpeed = 50;
    public float stearInput = 0;
    public Vector3 localTargetPos;

    // Start is called before the first frame update
    void Start()
    {
        groundCheck = this.gameObject.GetComponentInChildren<groundCheck>();
        ball = GetComponent<car>().ball;

    }

    // Update is called once per frame
    void Update()
    {
        targets.Clear();
        targets.Add(GameObject.FindGameObjectsWithTag("enemy"));
        targets.Add(GameObject.FindGameObjectsWithTag("player"));
        if (groundCheck != null)
        {
            if (groundCheck.isgorund)
            {
                //target choice
                foreach (GameObject[] objects in targets)
                {
                    foreach(GameObject obje in objects)
                    {
                        if(obje.transform.position != gameObject.transform.position)
                        {
                            if (target == null || 
                                Vector3.Distance(gameObject.transform.position, obje.transform.position) < Vector3.Distance(gameObject.transform.position, target.transform.position))
                                target = obje;
                        }
                        
                    }
                }

                if(target!= null)
                {
                    //Moving
                    moveForce += transform.right * moveSpeed * Time.deltaTime;
                    transform.position += moveForce * Time.deltaTime;
                    localTargetPos =target.transform.InverseTransformPoint(transform.position);



                    //if (localTargetPos.x  <0)
                    //{
                    //    stearInput = -1;
                    //}
                    //else if (localTargetPos.x>0)
                    //{
                    //    stearInput = 1;
                    //}else if(localTargetPos.x == 0)
                    //{
                    //    stearInput= 0;
                    //}

                    stearInput = AngleDir(transform.right, target.transform.position - gameObject.transform.position, transform.up);
                    transform.Rotate(Vector3.up * stearInput * moveForce.magnitude * stearAngle * Time.deltaTime);
                    moveForce *= drag;
                    //Max Speed
                    moveForce = Vector3.ClampMagnitude(moveForce, maxSpeed);

                    //if (ball != null && (stearInput == 1 || stearInput == -1))
                    //{
                    //    ball.GetComponent<Rigidbody>().AddForce(moveForce.normalized * 10);
                    //}
                    //Traction
                    moveForce = Vector3.Lerp(moveForce.normalized, transform.right, traction * Time.deltaTime) * moveForce.magnitude;
                    Debug.DrawRay(transform.position, moveForce * 3, Color.blue);
                }
                

            }
            else
            {

                Quaternion newRotation = Quaternion.Euler(0f, transform.rotation.y, 0f);
                //transform.RotateAround(new Vector3(0,0,0), new Vector3(100,100,100),1000f);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, transform.rotation.y, 0f), airCorrectSpeed * Time.deltaTime);

            }
        }
        else
        {
            Debug.Log("dont find groundchek");
        }

    }


    //returns -1 when to the left, 1 to the right, and 0 for forward/backward
    public float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up)
    {
        Vector3 perp = Vector3.Cross(fwd, targetDir);
        float dir = Vector3.Dot(perp, up);

        if (dir > 0.0f)
        {
            return 1.0f;
        }
        else if (dir < 0.0f)
        {
            return -1.0f;
        }
        else
        {
            return 0.0f;
        }
    }
}
