using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    Vector3 hitObjePos;
    Vector3 hitVector;
    public GameObject myCar;
    public GameObject colOB = null;
    bool debug = false;
    
    private void OnCollisionEnter(Collision collision)
    {

        //if (collision.gameObject.tag !=("player") && collision.gameObject.tag != ("enemy"))
        //{
        //    return;
        //}
        if (collision.gameObject.tag == "player" || collision.gameObject.tag == ("enemy"))
        {
            if (collision.gameObject.GetComponent<car>().me != myCar)
            {
                hitObjePos = collision.gameObject.transform.position;
                hitVector = hitObjePos - gameObject.transform.position + new Vector3(0, 30, 0);
                collision.gameObject.transform.GetComponentInParent<Rigidbody>().AddForce(hitVector.normalized * 1000);
                colOB = collision.gameObject;
                debug = true;

            }
        }

        //if (collision.gameObject.transform.parent == null)
        //{
        //    return;
        //}
        //else if (collision.gameObject.transform.parent.tag == ("player") || collision.gameObject.transform.parent.tag == ("enemy"))
        //{
        //    if (collision.gameObject.GetComponentInParent<car>().me != myCar)
        //    {
        //        hitObjePos = collision.gameObject.transform.position;
        //        hitVector = hitObjePos - gameObject.transform.position + new Vector3(0, 100, 0);
        //        collision.gameObject.transform.GetComponentInParent<Rigidbody>().AddForce(hitVector.normalized * 1000);
        //        colOB = collision.gameObject;
        //        debug = true;

        //    }
        //}


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(colOB == null && debug)
        {
            myCar.GetComponent<car>().killed= true;
            Debug.Log("animasyon");
            debug= false;
        }
       
    }
}
