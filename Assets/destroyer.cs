using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class destroyer : MonoBehaviour
{
    int enemy = 0;
    int player = 0;
    int current;
    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.transform.parent)
        //    Destroy(other.gameObject.transform.parent);
        Destroy(other.gameObject);
        if (other.gameObject.tag == "player")
            player++;
        if(other.gameObject.tag == "enemy")
            enemy++;
    }
    private void Update()
    {
        if(player==1)
            SceneManager.LoadScene(3);
        else if(enemy == 3)
            SceneManager.LoadScene(2);
        current = (int)(1f / Time.unscaledDeltaTime);
        Debug.Log("fps:" + current);
    }
}
