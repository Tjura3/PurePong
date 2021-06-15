using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    readonly float LEFTRIGHT = 7.75f;

    readonly float TOPBOTTOM = 4.25f;

    Vector2 speed = new Vector2(4, -4);

    bool ballServed = false;


    //audiothings maybe
    public GameController gameController;

 
    void Update()
    {
        if (Input.GetButton("Fire1") && !ballServed)
        {
            ballServed = true;
            StartCoroutine(Run());
        }
    }

    IEnumerator Run()
    {
        while (ballServed)
        {



            Vector3 delta = speed * Time.deltaTime;
            Vector3 newPos = transform.position + delta;

            if (newPos.x < -LEFTRIGHT)
            {
                newPos.x = -LEFTRIGHT;
                speed.x *= -1;
            }
            else if (newPos.x > LEFTRIGHT)
            {
                newPos.x = LEFTRIGHT;
                speed.x *= -1;
            }
            else if (newPos.y < -TOPBOTTOM)   //death here I think
            {
                ballServed = false;
                newPos = new Vector3(-7.75f, 0, 0);
                gameController.Lives--;
               
            }
            else if (newPos.y > TOPBOTTOM) //not here btw
            {
                newPos.y = TOPBOTTOM;
                speed.y *= -1;

            }
            transform.position = newPos;

            yield return new WaitForEndOfFrame();

        }
    }

    private void OnCollisionEnter2D(Collision2D c)
    {
        speed.y *= -1;

        if (c.gameObject.tag != "Player")
        {
            Destroy(c.gameObject);
            gameController.Score += 10;
        }
        else
        {
            gameController.Score += 5;
        }

    }

}
