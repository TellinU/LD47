using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class Yellow : MonoBehaviour
{
    public AIDestinationSetter aiDS;

    void Awake()
    {
        aiDS = GetComponent<AIDestinationSetter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Green")
        {
            collision.gameObject.SetActive(false);
            aiDS.target = null;
        }
    }
}
