using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RayDirection : MonoBehaviour
{

    Ray RayCamera;
    RaycastHit RaycastHit;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        //
        //Считываем нажатие мышки и запуск луча
        //
        if (Input.GetMouseButtonDown(0))//если мы нажали на правую кнопку мыши 
        {
            RayCamera = Camera.main.ScreenPointToRay(Input.mousePosition);// создадим луч проходящий через курсор мыши и если мы упираемся 
            Debug.DrawRay(RayCamera.origin, RayCamera.direction, Color.red);
            //print(Input.mousePosition);
            if (Physics.Raycast(RayCamera, out RaycastHit))
            {

                GameObject Water = RaycastHit.collider.gameObject;
                if (Water.name == "Water")
                {
                    //
                    //Находим координаты в сетке для поля
                    //

                    if (RaycastHit.point.x > 13 && RaycastHit.point.z < 25.1)
                    {
                        Vector3 Position = RaycastHit.point;
                        Position.x -= 13f;
                        Position.z -= 25f;
                        //print(Position.y);
                        int X = (int)(Position.x / 4f);
                        int Z = (int)(Position.z / 4f) * -1;
                        //print(X);
                        //print(Z);
                        //
                        //
                        

                    }
                    //print(RaycastHit.point);
                    //print("+");
                }
            }
        }

    }
    public Vector2Int GetPoint()
    {
        Vector2Int Point= new Vector2Int(-1,-1);
        RayCamera = Camera.main.ScreenPointToRay(Input.mousePosition);// создадим луч проходящий через курсор мыши и если мы упираемся 
        Debug.DrawRay(RayCamera.origin, RayCamera.direction, Color.red);
        //print(Input.mousePosition);
        if (Physics.Raycast(RayCamera, out RaycastHit))
        {

            GameObject Water = RaycastHit.collider.gameObject;
            if (Water.name == "Water")
            {
                //
                //Находим координаты в сетке для поля
                //

                if (RaycastHit.point.x > 13 && RaycastHit.point.z < 25.1)
                {
                    Vector3 Position = RaycastHit.point;
                    Position.x -= 13f;
                    Position.z -= 25f;
                    
                    int X = (int)(Position.x / 4f);
                    int Z = (int)(Position.z / 4f) * -1;

                   
                    if (X < 0 || X > 9) { X = -1; }
                    if (Z < 0 || Z > 9) { Z = -1; }

                    Point = new Vector2Int(X, Z);

                }
                
            }
        }
        return Point;
    }



    public Vector2Int GetPointBOT()
    {
        Vector2Int Point = new Vector2Int(-1, -1);
        RayCamera = Camera.main.ScreenPointToRay(Input.mousePosition);// создадим луч проходящий через курсор мыши и если мы упираемся 
        Debug.DrawRay(RayCamera.origin, RayCamera.direction, Color.red);
        //print(Input.mousePosition);
        if (Physics.Raycast(RayCamera, out RaycastHit))
        {

            GameObject Water = RaycastHit.collider.gameObject;
            if (Water.name == "Water")
            {
                //
                //Находим координаты в сетке для поля
                //

                if (RaycastHit.point.x < -2.43 && RaycastHit.point.z < 25.1)
                {
                    Vector3 Position = RaycastHit.point;
                    Position.x += 2.43f;
                    Position.z -= 25f;
                    
                    int X = (int)(Position.x / 4f) * -1 ;
                    int Z = (int)(Position.z / 4f) * -1;


                    if (X < 0 || X > 9) { X = -1; }
                    if (Z < 0 || Z > 9) { Z = -1; }

                    Point = new Vector2Int(X, Z);

                }

            }
        }
        return Point;
    }
}
