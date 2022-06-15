using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    //create objects for the boundaries
    public static Prect lowerWall;
    public static Prect upperWall;
    public static Prect centerLine;
    Color wallColor = new Color(0, 1, 1, 1);
    Color centerLineColor = new Color(1, 0, 1, 0.5f);


    //used for paddle AI later...
    public static Vector2 ballLocation;

    //set initial ball speed
    public static float initBallSpeed = 1f;







    //create a list of all Prects that need to have collision detection
    public static List<Prect> colliderPrects = new List<Prect>();






    //Used for GUI.Box
    private static Texture2D _staticRectTexture;
    private static GUIStyle _staticRectStyle;



    //used for scoring
    public static int leftScore;
    public static int rightScore;
    private Rect leftScoreText;
    private Rect rightScoreText;

    void Start()
    {
        upperWall = new Prect("Upper Wall", 0, 0, Screen.width, 10, true, "WALL");
        lowerWall = new Prect("Lower Wall", 0, Screen.height - 10, Screen.width, 10, true, "WALL");
        centerLine = new Prect("Center Wall", Screen.width / 2, 0, 5, Screen.height, false, "CTRLINE");

        //add to colliderPrects the objects that nrequire collision
        colliderPrects.Add(upperWall);
        colliderPrects.Add(lowerWall);

        leftScore = 0;
        rightScore = 0;
        leftScoreText = new Rect(20, 20, 20, 20);
        rightScoreText = new Rect(Screen.width - 30, 20, 20, 20);

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("SPACE");
            foreach(Prect p in colliderPrects)
            {
                Debug.Log(p.name);
            }
        }
    }



    public static void GUIDrawRect(Rect position, Color color)
    {
        if(_staticRectTexture == null)
        {
            _staticRectTexture = new Texture2D(1, 1);

        }
        if (_staticRectStyle == null)
        {
            _staticRectStyle = new GUIStyle();
            _staticRectStyle.fontSize = 16;
        }

        _staticRectTexture.SetPixel(0, 0, color);
        _staticRectTexture.Apply();
        _staticRectStyle.normal.background = _staticRectTexture;
        GUI.Box(position,GUIContent.none,_staticRectStyle);
    }


    public static void GUIDrawRect(Rect position, Color color, string tex)
    {
        if (_staticRectTexture == null)
        {
            _staticRectTexture = new Texture2D(1, 1);

        }
        if (_staticRectStyle == null)
        {
            _staticRectStyle = new GUIStyle();
            _staticRectStyle.fontSize = 16;
        }

        _staticRectTexture.SetPixel(0, 0, color);
        _staticRectTexture.Apply();
        _staticRectStyle.normal.background = _staticRectTexture;
        GUI.Box(position, tex, _staticRectStyle);
    }




    private void OnGUI()
    {
        //order matters when drawn
        GUIDrawRect(centerLine.rect, centerLineColor); //first 
        GUIDrawRect(upperWall.rect, wallColor);//seconed
        GUIDrawRect(lowerWall.rect, wallColor);//third

        //these are overloads
        //they are what happens when a function has a same name, but diffrent overides that may or may not be about the same.
        GUIDrawRect(leftScoreText, wallColor, leftScore.ToString());
        GUIDrawRect(rightScoreText, wallColor, rightScore.ToString());
    }

}
