using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//A class for working with primitive rectangles...
public class Prect
{
    public string name;
    public Rect rect;
    public int x, y, w, h;
    public bool hasCollision;
    public string tag;



    public Prect(string NAME, int XPOS, int YPOS, int Width, int Height, bool HASCOLLISION, string TAG)
    {
        name = NAME;
        x = XPOS;
        y = YPOS;
        w = Width;
        h = Height;
        rect.x = x;
        rect.y = y;
        rect.width = w;
        rect.height = h;
        hasCollision = HASCOLLISION;
        tag = TAG;
        
    }

    //default constructor
    public Prect() { }

}
