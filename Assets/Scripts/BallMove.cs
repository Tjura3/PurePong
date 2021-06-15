using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMove : MonoBehaviour
{
    readonly float LEFTRIGHT = 7.75f;

    readonly float TOPBOTTOM = 4.25f;

    Vector2 speed = new Vector2(4, -4);

    bool ballServed = false;
    int brickcount = 0;


    //audiothings maybe
    public GameController gameController;

    private void Start()
    {
        gameController.Score = PlayerPrefs.GetInt("lastscore", 0);
    }


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
                newPos = new Vector3(-2.46f, -1.19f, 0);
                gameController.Lives--;

                if (gameController.Lives == 0)
                {
                    //save score
                    PlayerPrefs.SetInt("lastscore", gameController.Score);
                    //game over
                    SceneManager.LoadScene("GameOver");
                }
               
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
            brickcount++;
            if(brickcount == 20)
            {
                PlayerPrefs.SetInt("lastscore", gameController.Score);
                SceneManager.LoadScene("Retroactive");
            }

        }
        else
        {
            gameController.Score += 5;
        }

    }

}
