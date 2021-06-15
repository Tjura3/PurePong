using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour
{

    
    
        void Update()
        {
            if (Input.GetKey("escape"))
            {
                Application.Quit();
            }
        }
    
   
}
