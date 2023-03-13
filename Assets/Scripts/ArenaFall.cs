using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaFall : MonoBehaviour
{
    GameObject[] arena1;
    GameObject[] arena2;
    GameObject[] arena3;
    GameObject[] arena4;
    GameObject[] arena5;
    List<GameObject[]> arenas=new List<GameObject[]>();
    int timer = 20;
    int arenaCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < 6; i++)
        {
            arenas.Add(GameObject.FindGameObjectsWithTag("arena" + i.ToString()));
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (timer < Time.timeSinceLevelLoad )
        {
            GameObject[] objects = arenas[arenaCount];
            foreach (var game in objects)
            {
                game.GetComponent<Rigidbody>().useGravity = true;
                game.GetComponent<Rigidbody>().isKinematic = false;
            }
            timer += 20;
            arenaCount++;
        }
    }
}
