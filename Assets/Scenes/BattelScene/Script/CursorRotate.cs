using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorRotate : MonoBehaviour
{
    public bool Enable;

    public float Angle;
    public float Speed;
    public float Up;
    public float Down;


    public string Up_or_Down;
    // Start is called before the first frame update
    void Start()
    {
        Up_or_Down = "Down";
        Enable = false;
        Angle = 2;
        Speed = 2;
        Up = 15;
        Down = 13;
    }

    // Update is called once per frame
    void Update()
    {
        if (Enable)
        {
            transform.eulerAngles += new Vector3(0,Angle,0);
            if (transform.position.y > Down && Up_or_Down == "Down")
            {
                transform.Translate(new Vector3(0, 0, -Speed) * Time.deltaTime);
                if (transform.position.y <= Down)
                    Up_or_Down = "Up";
            }
            if (transform.position.y < Up && Up_or_Down == "Up")
            {
                transform.Translate(new Vector3(0, 0 , Speed) * Time.deltaTime);
                if (transform.position.y >= Up)
                    Up_or_Down = "Down";
            }

            if (transform.position.y  < 0f)
            {
                transform.position = new Vector3(transform.position.x,Up,transform.position.z);
                Up_or_Down = "Down";
            }
            
        }
    }
}

public class LDPoint
{
    public Vector2Int Point;
    public string Rotate;

    public const string Up = "Up";
    public const string Down = "Down";
    public const string Left = "Left";
    public const string Right = "Right";

    public LDPoint(Vector2Int point, string rotate)
    {
        Point = point;
        Rotate = rotate;
        
        
    }
    public LDPoint() { }
    ~LDPoint() {}
   
}
