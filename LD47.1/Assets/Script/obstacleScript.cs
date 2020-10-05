using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleScript : MonoBehaviour
{
    public float destroyTime;
    float Timer;

    public AstarPath astarPath;

    void Awake()
    {
        Timer = destroyTime;

        astarPath = GameObject.Find("Astar").GetComponent<AstarPath>();
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer<=0)
        {
            Destroy(this.gameObject);
            astarPath.Scan();
        }
    }
}
