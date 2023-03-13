using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck : MonoBehaviour
{
    public bool isgorund = false;
    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if (other.tag.StartsWith("arena"))
        {
            isgorund = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag.StartsWith("arena"))
        {
            isgorund = false; ;
        }
    }
}
