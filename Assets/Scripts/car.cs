using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class car : MonoBehaviour
{
    //sgroundCheck groundCheck;
    public GameObject ball;
    public GameObject me;
    public Animator anim;
    public bool killed = false;
    bool bostActive = false;

    // Start is called before the first frame update
    void Start()
    {
        Task.Delay(150).Wait();

        //groundCheck = this.gameObject.GetComponentInChildren<groundCheck>();
        anim = gameObject.GetComponent<Animator>();
        me = this.gameObject;
        GameObject[] ballList = GameObject.FindGameObjectsWithTag("ball");
        foreach (GameObject item in ballList)
        {
            if (ball == null)
                ball = item;
            else
            {
                float ballDistance = Vector3.Distance(ball.transform.position, transform.position);
                float itemDistance = Vector3.Distance(item.transform.position, transform.position);
                if (itemDistance - ballDistance < 0)
                    ball = item;
            }
        }
        ball.GetComponent<ball>().myCar = this.gameObject;
        gameObject.GetComponentInChildren<ropeRenderer>().ball = ball;

        var controller = gameObject.GetComponentInChildren<RopeControler>();

        if (controller != null && ball != null)
            controller.joint.connectedBody = ball.GetComponent<Rigidbody>();
        else
            Debug.Log($"{this.name} | {ball?.name} controller not found");
    }
    private void Update()
    {
        //if (groundCheck != null)
        //{
        //    if (!groundCheck.isgorund)
        //    {
        //     gameObject.transform.FindChild("whell 1").GetComponentInChildren<TrailRenderer>().enabled = false;
        //        Debug.Log("enable false geldi");
        //    }
        //    else
        //    {
        //        gameObject.GetComponentInChildren<TrailRenderer>().enabled = true;
        //    }
        //}
                //sgameObject.GetComponentInChildren<ConfigurableJoint>().o
                animasion();

        if(bostActive)
            ball.transform.RotateAround(transform.position, new Vector3(0,12,0) , 700*Time.deltaTime);
        
    }
    public void boostStart()
    {
        StartCoroutine(boost());
    }
    public IEnumerator boost() 
    {
        bostActive= true;
        gameObject.GetComponentInChildren<LineRenderer>().enabled= false;
        yield return new WaitForSeconds(3);
        gameObject.GetComponentInChildren<LineRenderer>().enabled = true;
        bostActive = false;
    }
    public void animasion()
    {
        if(anim != null)
        {
            if (anim.GetBool("kill"))
            {
                anim.SetBool("kill", false);
            }
            if(killed)
            {
                anim.SetBool("kill", true);
            }
        }
        
    }
}
