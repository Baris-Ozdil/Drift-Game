using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    private Vector3 moveForce;
    public GameObject ball;
    Joistic Joistic;
    groundCheck groundCheck;

    public float moveSpeed = 50;
    public float maxSpeed = 15;
    public float stearAngle = 15;
    public float drag = 0.98f;
    public float traction = 1;
    public float airCorrectSpeed = 50;

    // Start is called before the first frame update
    void Start()
    {
        groundCheck = this.gameObject.GetComponentInChildren<groundCheck>();
        ball = GetComponent<car>().ball;
        Joistic= GameObject.FindGameObjectWithTag("canva").GetComponentInChildren<Joistic>();

    }

    // Update is called once per frame
    void Update()
    {
        if(groundCheck != null)
        {
            if (groundCheck.isgorund)
            {
                //Moving
                moveForce += transform.right * moveSpeed * Time.deltaTime;
                transform.position += moveForce * Time.deltaTime;
                float stearInput = /*Input.GetAxis("Horizontal");*/ Joistic.joysticVec.x;
                if(stearInput <= -0.8 || stearInput>=0.8)
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
                Debug.DrawRay(transform.position, moveForce*3, Color.blue);
                
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


    
}
