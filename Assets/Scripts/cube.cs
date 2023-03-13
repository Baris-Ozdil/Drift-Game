using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(destroyTimer());
    }
    IEnumerator destroyTimer()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject.transform.GetChild(0).gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.transform.parent.tag == "player" || other.gameObject.transform.parent.tag == "enemy")
        {
            //StartCoroutine( other.gameObject.GetComponentInParent<car>().boost());
            other.gameObject.GetComponentInParent<car>().boostStart();
            Destroy(gameObject);
        }
    }
}
