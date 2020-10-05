using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Pathfinding;

public class Green : MonoBehaviour
{
    public float speed;
    Rigidbody2D rigidbody;
    bool shift = false;
    bool accelerated = false;

    public GameObject Obstacle;
    public AstarPath astarPath;
    bool canPut = true;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        astarPath= GameObject.Find("Astar").GetComponent<AstarPath>();
    }

    void Update()
    {
        shift = Input.GetButton("Fire2");
        PutObstacle();
    }

    void FixedUpdate()
    {
        move();
    }

    void move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (h != 0 && v == 0)
        {
            rigidbody.velocity = new Vector2(h * speed, 0);
            if (shift && accelerated == false)
            {
                accelerated = true;
                rigidbody.velocity = new Vector2(h * 1.5f * speed, 0); 
            }
        }
        else if (h == 0 && v != 0)
        {
            rigidbody.velocity = new Vector2(0, v * speed);
            if (shift && accelerated == false)
            {
                accelerated = true;
                rigidbody.velocity = new Vector2(0, v * 1.5f * speed);
            }
        }
        else if (h == 0 && v == 0)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, rigidbody.velocity.y);
            if (shift && accelerated == false)
            {
                accelerated = true;
                rigidbody.velocity = new Vector2(1.5f * rigidbody.velocity.x, 1.5f * rigidbody.velocity.y); 
            }
        }
        if (shift == false) accelerated = false;
        
    }

    void PutObstacle()
    {
        if (Input.GetButtonDown("Fire1")&&canPut)
        {
            Vector3 putpositon;
            putpositon = Input.mousePosition;
            putpositon = Camera.main.ScreenToWorldPoint(putpositon);
            putpositon = new Vector3(putpositon.x, putpositon.y, 0);
            Instantiate(Obstacle, putpositon, Quaternion.identity);

            astarPath.Scan();
            canPut = false;
            StartCoroutine(PutTimer());
        }
    }

    IEnumerator PutTimer()
    {
        yield return new WaitForSeconds(3f);
        canPut = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Red")
        {
            collision.gameObject.SetActive(false);
        }
        /*else if(collision.tag=="Blue"||collision.tag=="Pink"||collision.tag=="Purple")
        {
            rigidbody.velocity = new Vector2(-5f * rigidbody.velocity.x, -5f * rigidbody.velocity.y);
        }*/
    }
}
