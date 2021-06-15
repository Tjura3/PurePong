using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour
{
    public GameObject brickTemplate;
    Color[] coulours = new Color[] { Color.red, Color.green, Color.blue, Color.yellow };

    void Start()
    {
        for (int y = 0; y<4; y++)
        {
            for (int x = 0; x<5; x++)
            {
                GameObject brick = Instantiate(brickTemplate);
                brick.transform.position = new Vector3(x * 3, 4 - y) + new Vector3(-6, 0);
                SpriteRenderer renderer = brick.GetComponent<SpriteRenderer>();
                renderer.material.color = coulours[y];
            }
        }
    }

}
