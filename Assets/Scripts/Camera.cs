using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject target;
    public Vector3 cameraOfset;

    public float smoothFactor = 0.5f;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("player");
        if(cameraOfset!= null)
            cameraOfset = transform.position - target.transform.position;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
       
    }
    private void Update()
    {
        if(target != null) {
            Vector3 newPosition = target.transform.position + cameraOfset;
            transform.position = Vector3.Slerp(transform.position, newPosition, smoothFactor);
        }
        
    }
}
