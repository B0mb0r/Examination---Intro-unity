using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skepp : MonoBehaviour
{
    public float speed;
    [Range(-720, 720)]
    public float turnSpeed;
    public SpriteRenderer rend;
    public float timer;
    public float timerPrint;
    
    // Use this for initialization
    void Start()
    {
        //När spelet startas placeras man på en random location
        transform.position = new Vector3(Random.Range(-10f, 10f), Random.Range(-5f, 5f));
        //Skeppets fart blir random vid start av spel.
        speed = Random.Range(4, 8);
    }

    // Update is called once per frame
    void Update()
    {
        //Gör att skeppet åker framåt
        transform.Translate(
            speed * Time.deltaTime, 
            0f, 
            0f);
        //När A är nertryckt så händer något
        if (Input.GetKey(KeyCode.A))
        {
            //Skeppet svänger vänster
            transform.Rotate(
                0f,
                0f,
                turnSpeed / 2 * Time.deltaTime);
            //Skeppet blir grönt
            rend.color = new Color(0f, 1f, 0f);
        }
        //När D är nertryckt så händer något
        if (Input.GetKey(KeyCode.D))
        {
            //Skeppet svänger höger
            transform.Rotate(
                0f,
                0f,
                -turnSpeed * Time.deltaTime);
            //Skeppet blir blått
            rend.color = new Color(0f, 0f, 1f);
        }
        //När S är nertryckt så händer något
        if (Input.GetKey(KeyCode.S))
        {
            //Skeppet åker långsammare
            transform.Translate(
            speed / 4 * Time.deltaTime,
            0f,
            0f);
        }
        //Om S inte är intryckt så
        else
        {
            //Skeppet åker vanlig fart
            transform.Translate(
            speed * Time.deltaTime,
            0f,
            0f);
        }
        //Timern ökar
        timer = timer + 1 * Time.deltaTime;
        //Timern skrivs ut varje sekund
        if (timerPrint >= 1)
        {
            print(string.Format(
                "Timer:" + timer));
            timerPrint = 0;
        }
        //Variabel som används för att checka när timer ska printas
        timerPrint = timerPrint + 1 * Time.deltaTime;
        //Skeppet får en ny färg om space trycks ner
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rend.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
        //När skeppet kör in i kanterna warpas den till andra sidan
        if (transform.position.x >= 10)
        {
            transform.position = new Vector3(transform.position.y, - 10);
        }
        if (transform.position.x <= -10)
        {
            transform.position = new Vector3(10, transform.position.y);
        }
        if (transform.position.y >= 5)
        {
            transform.position = new Vector3(-5, transform.position.x);
        }
        if (transform.position.y <= -5)
        {
            transform.position = new Vector3(transform.position.x, 5);
        }
    }
}
