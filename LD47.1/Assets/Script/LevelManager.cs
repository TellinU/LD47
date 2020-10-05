using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    GameObject green;
    public GameObject red;
    public GameObject blue;
    public GameObject pink;
    public GameObject yellow;

    public float loadTime;
    float Timer;

    void Awake()
    {
        green = GameObject.FindGameObjectWithTag("Green");
        Timer = loadTime;
    }

    // Update is called once per frame
    void Update()
    {
        playerDead();

        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            Timer = loadTime;
            instantiateGuys();
        }
    }

    void playerDead()
    {
        if (green.activeSelf==false)
        {
            SceneManager.LoadScene(0);
        }
    }

    void instantiateGuys()
    {
        Vector3 redPosition = new Vector3(19.5f, -5.5f, 0f);
        Vector3 bluePosition = new Vector3(19.5f, 6.5f, 0f);
        Vector3 pinkPosition = new Vector3(-10.5f, 6.5f, 0f);
        Vector3 yellowPosition = new Vector3(-10.5f, -5.5f, 0f);

        Instantiate(yellow, yellowPosition, Quaternion.identity);
        Instantiate(pink, pinkPosition, Quaternion.identity);
        Instantiate(blue, bluePosition, Quaternion.identity);
        Instantiate(red, redPosition, Quaternion.identity);
    }
}
