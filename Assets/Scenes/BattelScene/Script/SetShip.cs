using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SetShip : MonoBehaviour
{
    //
    //Кораблики
    //
    public GameObject Ship_1;
    public GameObject Ship_2;
    public GameObject Ship_3;
    public GameObject Ship_4;
    //
    //Тексты С кнопок меню 
    //
    public Text Text_Ship1;
    public Text Text_Ship2;
    public Text Text_Ship3;
    public Text Text_Ship4;
    //
    //Основные объекты
    //
    public GameObject GameControl;//основной объект

    public GameObject MassTitle;//объект к которому мы будем прикреплять созданные Title

    public GameObject MassShip;//объект к которому мы будем прикреплять созданные Кораблики

    public GameObject Title;//ячейка
    public GameObject Title2;//ячейка
    public GameObject Title3;//ячейка
    public GameObject Title4;//ячейка
    //
    // Материалы рендера
    //
    public Material Senter_Yes; //  материал клетки на котором находится кораблик если место свободно
    public Material Senter_No; //  материал клетки на котором находится кораблик если место занято
    public Material Perimeter; // материал клетки по периметру от кораблика

    //
    //Кнопка Start (По умолчанию выключена)
    //
    public GameObject StartButton;

    int[] Ship = new int[] { 1, 2, 3, 4 };

    public string Active;// выбран ли кораблик
    public string Rotate; //Up // Down // Left //Right
    public int PosX;// позиция в поле по Х
    public int PosY;// позиция в поле по Y

    private bool ActiveAs; //Находится курсор на поле после выбора кораблика.



    private InputManager InputManager => GameControl.GetComponent<InputManager>();
    private ButtonManager ButtonManager => GameControl.GetComponent<ButtonManager>();
    private BattelControl BattelControl => GameControl.GetComponent<BattelControl>();
    // Start is called before the first frame update
    void Start()
    {
        
        StartButton.SetActive(false);

        
        Rotate = "Up";
        Ship[0] = 4;   // 0 - 1 клеточный
        Ship[1] = 3;   // 1 - 2 клеточный
        Ship[2] = 2;   // 2 - 3 клеточный
        Ship[3] = 1;   // 3 - 4 клеточный
        Active = null;
        ActiveAs = false;
    }
    public void SetActiveShip(int Type) // значение из кнопки 
    {
        switch (Type)
        {
            case 1: { Active = "One"; break; }
            case 2: { Active = "Two"; break; }
            case 3: { Active = "Tree"; break; }
            case 4: { Active = "Fore"; break; }

        }

    }

    //
    // перевод активного значение из строки в int
    //

    public int ActiveToInt(string Active)
    {
        int X = -1;
        switch (Active)
        {
            case "One": { X = 0; break; }
            case "Two": { X = 1; break; }
            case "Tree": { X = 2; break; }
            case "Fore": { X = 3; break; }

        }
        return X;
    }
    public string ActiveToString(int Active)
    {
        string X = null;
        switch (Active)
        {
            case 0: { X = "One"; break; }
            case 1: { X = "Two"; break; }
            case 2: { X = "Tree"; break; }
            case 3: { X = "Fore"; break; }

        }
        return X;
    }
    public string RotateToString(int Rotate)
    {
        string X = null;
        switch (Rotate)
        {
            case 0: { X = "Up"; break; }
            case 1: { X = "Down"; break; }
            case 2: { X = "Right"; break; }
            case 3: { X = "Left"; break; }

        }
        return X;
    }
    public int RotateToInt(string Rotate)
    {
        int X = -1;
        switch (Rotate)
        {
            case "Up": { X = 0; break; }
            case "Down": { X = 1; break; }
            case "Right": { X = 2; break; }
            case "Left": { X = 3; break; }

        }
        return X;
    }


    private void SetTitleMaterial(string Type)
    {
        if (Type == "Empty")
        {
            Title.GetComponent<Renderer>().material = Senter_Yes;
            Title2.GetComponent<Renderer>().material = Senter_Yes;
            Title3.GetComponent<Renderer>().material = Senter_Yes;
            Title4.GetComponent<Renderer>().material = Senter_Yes;

        }
        if (Type == "Occupied")
        {
            Title.GetComponent<Renderer>().material = Senter_No;
            Title2.GetComponent<Renderer>().material = Senter_No;
            Title3.GetComponent<Renderer>().material = Senter_No;
            Title4.GetComponent<Renderer>().material = Senter_No;

        }
    }
    //
    //функция перемещения активных тайтлов и караблика в соответствии с курсором на поле
    //

    private void MoveActiveTitle()
    {


        if (Active == "One")
        {
            //перемещаем Title под выбранную точку с учтом поворота
            Title.transform.position = new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - PosY * 3.9667f);

            //перемещаем Кораблик под выбранную точку с учтом поворота
            Ship_1.transform.position = new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - PosY * 3.9667f);
            


        }
        else
        {
            if (Active == "Two")
            {

                
                if (Rotate == "Up" && PosY < 9)
                {
                    //перемещаем Title под выбранную точку с учтом поворота
                    Title.transform.position = new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - PosY * 3.9667f);
                    Title2.transform.position = new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - (PosY +1)* 3.9667f);

                    //перемещаем Кораблик под выбранную точку с учтом поворота
                    Ship_2.transform.position = new Vector3(15.2f + PosX * 3.9667f, 4.66f, 21f - PosY * 3.9667f);
                    return;
                }
                if (Rotate == "Down" && PosY > 0)
                {
                    //перемещаем Title под выбранную точку с учтом поворота
                    Title.transform.position = new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - PosY * 3.9667f);
                    Title2.transform.position = new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - (PosY - 1) * 3.9667f);

                    //перемещаем Кораблик под выбранную точку с учтом поворота
                    Ship_2.transform.position = new Vector3(15.2f + PosX * 3.9667f, 4.66f, 24.6f - PosY * 3.9667f);
                    return;
                }
                if (Rotate == "Right" && PosX > 0)
                {
                    //перемещаем Title под выбранную точку с учтом поворота
                    Title.transform.position = new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - PosY * 3.9667f);
                    Title2.transform.position = new Vector3(15.2f + (PosX-1) * 3.9667f, 4.66f, 22.8f - (PosY) * 3.9667f);

                    //перемещаем Кораблик под выбранную точку с учтом поворота
                    Ship_2.transform.position = new Vector3(13.4f + PosX * 3.9667f, 4.66f, 22.8f - PosY * 3.9667f);
                    return;
                }
                if (Rotate == "Left" && PosX < 9)
                {
                    //перемещаем Title под выбранную точку с учтом поворота
                    Title.transform.position = new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - PosY * 3.9667f);
                    Title2.transform.position = new Vector3(15.2f + (PosX + 1) * 3.9667f, 4.66f, 22.8f - (PosY) * 3.9667f);

                    //перемещаем Кораблик под выбранную точку с учтом поворота
                    Ship_2.transform.position = new Vector3(17f + PosX * 3.9667f, 4.66f, 22.8f - PosY * 3.9667f);
                    return;
                }

            }
            else
            {
                if (Active == "Tree")
                {
                    
                    if (Rotate == "Up" && PosY < 8)
                    {
                        //перемещаем Title под выбранную точку с учтом поворота
                        Title.transform.position = new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - PosY * 3.9667f);
                        Title2.transform.position = new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - (PosY + 1) * 3.9667f);
                        Title3.transform.position = new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - (PosY + 2) * 3.9667f);

                        //перемещаем Кораблик под выбранную точку с учтом поворота
                        Ship_3.transform.position = new Vector3(15.2f + PosX * 3.9667f, 4.66f, 19.2f - PosY * 3.9667f);
                        return;
                    }
                    if (Rotate == "Down" && PosY > 1)
                    {
                        //перемещаем Title под выбранную точку с учтом поворота
                        Title.transform.position = new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - PosY * 3.9667f);
                        Title2.transform.position = new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - (PosY - 1) * 3.9667f);
                        Title3.transform.position = new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - (PosY - 2) * 3.9667f);

                        //перемещаем Кораблик под выбранную точку с учтом поворота
                        Ship_3.transform.position = new Vector3(15.2f + PosX * 3.9667f, 4.66f, 26.4f - PosY * 3.9667f);
                        return;
                    }
                    if (Rotate == "Right" && PosX > 1)
                    {
                        //перемещаем Title под выбранную точку с учтом поворота
                        Title.transform.position = new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - PosY * 3.9667f);
                        Title2.transform.position = new Vector3(15.2f + (PosX - 1) * 3.9667f, 4.66f, 22.8f - (PosY) * 3.9667f);
                        Title3.transform.position = new Vector3(15.2f + (PosX - 2) * 3.9667f, 4.66f, 22.8f - (PosY) * 3.9667f);

                        //перемещаем Кораблик под выбранную точку с учтом поворота
                        Ship_3.transform.position = new Vector3(11.6f + PosX * 3.9667f, 4.66f, 22.8f - PosY * 3.9667f);
                        return;
                    }
                    if (Rotate == "Left" && PosX < 8)
                    {
                        //перемещаем Title под выбранную точку с учтом поворота
                        Title.transform.position = new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - PosY * 3.9667f);
                        Title2.transform.position = new Vector3(15.2f + (PosX + 1) * 3.9667f, 4.66f, 22.8f - (PosY) * 3.9667f);
                        Title3.transform.position = new Vector3(15.2f + (PosX + 2) * 3.9667f, 4.66f, 22.8f - (PosY) * 3.9667f);

                        //перемещаем Кораблик под выбранную точку с учтом поворота
                        Ship_3.transform.position = new Vector3(18.8f + PosX * 3.9667f, 4.66f, 22.8f - PosY * 3.9667f);
                        return;
                    }




                }
                else
                {

                    if (Rotate == "Up" && PosY < 7)
                    {
                        //перемещаем Title под выбранную точку с учтом поворота
                        Title.transform.position = new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - PosY * 3.9667f);
                        Title2.transform.position = new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - (PosY + 1) * 3.9667f);
                        Title3.transform.position = new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - (PosY + 2) * 3.9667f);
                        Title4.transform.position = new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - (PosY + 3) * 3.9667f);

                        //перемещаем Кораблик под выбранную точку с учтом поворота
                        Ship_4.transform.position = new Vector3(15.2f + PosX * 3.9667f, 4.66f, 17.4f - PosY * 3.9667f);

                        return;
                    }
                    if (Rotate == "Down" && PosY > 2)
                    {
                        //перемещаем Title под выбранную точку с учтом поворота
                        Title.transform.position = new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - PosY * 3.9667f);
                        Title2.transform.position = new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - (PosY - 1) * 3.9667f);
                        Title3.transform.position = new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - (PosY - 2) * 3.9667f);
                        Title4.transform.position = new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - (PosY - 3) * 3.9667f);

                        //перемещаем Кораблик под выбранную точку с учтом поворота
                        Ship_4.transform.position = new Vector3(15.2f + PosX * 3.9667f, 4.66f, 28.2f - PosY * 3.9667f);
                        return;
                    }
                    if (Rotate == "Right" && PosX > 2)
                    {
                        //перемещаем Title под выбранную точку с учтом поворота
                        Title.transform.position = new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - PosY * 3.9667f);
                        Title2.transform.position = new Vector3(15.2f + (PosX - 1) * 3.9667f, 4.66f, 22.8f - (PosY) * 3.9667f);
                        Title3.transform.position = new Vector3(15.2f + (PosX - 2) * 3.9667f, 4.66f, 22.8f - (PosY) * 3.9667f);
                        Title4.transform.position = new Vector3(15.2f + (PosX - 3) * 3.9667f, 4.66f, 22.8f - (PosY) * 3.9667f);

                        //перемещаем Кораблик под выбранную точку с учтом поворота
                        Ship_4.transform.position = new Vector3(9.8f + PosX * 3.9667f, 4.66f, 22.8f - PosY * 3.9667f);
                        return;
                    }
                    if (Rotate == "Left" && PosX < 7)
                    {
                        //перемещаем Title под выбранную точку с учтом поворота
                        Title.transform.position = new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - PosY * 3.9667f);
                        Title2.transform.position = new Vector3(15.2f + (PosX + 1) * 3.9667f, 4.66f, 22.8f - (PosY) * 3.9667f);
                        Title3.transform.position = new Vector3(15.2f + (PosX + 2) * 3.9667f, 4.66f, 22.8f - (PosY) * 3.9667f);
                        Title4.transform.position = new Vector3(15.2f + (PosX + 3) * 3.9667f, 4.66f, 22.8f - (PosY) * 3.9667f);

                        //перемещаем Кораблик под выбранную точку с учтом поворота
                        Ship_4.transform.position = new Vector3(20.6f + PosX * 3.9667f, 4.66f, 22.8f - PosY * 3.9667f);
                        return;
                    }


                }

            }
        }
    }

    //
    //Функция создания кораблика на нашем поле
    //

    private void CreateTtile()
    {
       
        
        if (Active == "One")
        {
            //
            //создадим  тайтл
            BattelControl.My_Title[PosX, PosY] = Instantiate(Title, new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - PosY * 3.9667f), Quaternion.identity, MassTitle.transform);
            //
            //создадим кораблик
            BattelControl.ListShip.Add(Instantiate(Ship_1, new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - PosY * 3.9667f), Ship_1.transform.rotation, MassShip.transform));

            //на массиве клеточик установим  ( 1 ) в поле где кораблик установлен
            BattelControl.My_field[PosX, PosY] = 1;
            
        }
        else
        {
            if (Active == "Two")
            {
                if (Rotate == "Up" && PosY < 9)
                {
                    //
                    //создадим  тайтл
                    BattelControl.My_Title[PosX, PosY] = Instantiate(Title, new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - PosY * 3.9667f), Quaternion.identity, MassTitle.transform);
                    BattelControl.My_Title[PosX, PosY + 1] = Instantiate(Title, new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - (PosY + 1) * 3.9667f), Quaternion.identity, MassTitle.transform);
                    //
                    //создадим кораблик
                    BattelControl.ListShip.Add(Instantiate(Ship_2, new Vector3(15.2f + PosX * 3.9667f, 4.66f, 21f - PosY * 3.9667f), Ship_2.transform.rotation, MassShip.transform));
                    //
                    //на массиве клеточик установим  ( 1 ) в поле где кораблик установлен
                    BattelControl.My_field[PosX, PosY] = 1;
                    BattelControl.My_field[PosX, PosY + 1] = 1;

                }
                if (Rotate == "Down" && PosY > 0)
                {
                    //
                    //создадим  тайтл
                    BattelControl.My_Title[PosX, PosY] = Instantiate(Title, new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - PosY * 3.9667f), Quaternion.identity, MassTitle.transform);
                    BattelControl.My_Title[PosX, PosY - 1] = Instantiate(Title, new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - (PosY - 1) * 3.9667f), Quaternion.identity, MassTitle.transform);
                    //
                    //создадим кораблик
                    BattelControl.ListShip.Add(Instantiate(Ship_2, new Vector3(15.2f + PosX * 3.9667f, 4.66f, 24.6f - PosY * 3.9667f), Ship_2.transform.rotation, MassShip.transform));
                    //
                    //на массиве клеточик установим  ( 1 ) в поле где кораблик установлен
                    BattelControl.My_field[PosX, PosY] = 1;
                    BattelControl.My_field[PosX, PosY - 1] = 1;
                }
                if (Rotate == "Right" && PosX > 0)
                {
                    //
                    //создадим  тайтл
                    BattelControl.My_Title[PosX, PosY] = Instantiate(Title, new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - PosY * 3.9667f), Quaternion.identity, MassTitle.transform);
                    BattelControl.My_Title[PosX - 1, PosY] = Instantiate(Title, new Vector3(15.2f + (PosX - 1) * 3.9667f, 4.66f, 22.8f - (PosY) * 3.9667f), Quaternion.identity, MassTitle.transform);
                    //
                    //создадим кораблик
                    BattelControl.ListShip.Add(Instantiate(Ship_2, new Vector3(13.4f + PosX * 3.9667f, 4.66f, 22.8f - PosY * 3.9667f), Ship_2.transform.rotation, MassShip.transform));
                    //
                    //на массиве клеточик установим  ( 1 ) в поле где кораблик установлен
                    BattelControl.My_field[PosX, PosY] = 1;
                    BattelControl.My_field[PosX - 1, PosY] = 1;
                }
                if (Rotate == "Left" && PosX < 9)
                {
                    //
                    //создадим  тайтл
                    BattelControl.My_Title[PosX, PosY] = Instantiate(Title, new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - PosY * 3.9667f), Quaternion.identity, MassTitle.transform);
                    BattelControl.My_Title[PosX + 1, PosY] = Instantiate(Title, new Vector3(15.2f + (PosX + 1) * 3.9667f, 4.66f, 22.8f - (PosY) * 3.9667f), Quaternion.identity, MassTitle.transform);
                    //
                    //создадим кораблик
                    BattelControl.ListShip.Add(Instantiate(Ship_2, new Vector3(17f + PosX * 3.9667f, 4.66f, 22.8f - PosY * 3.9667f), Ship_2.transform.rotation, MassShip.transform));
                    //
                    //на массиве клеточик установим  ( 1 ) в поле где кораблик установлен
                    BattelControl.My_field[PosX, PosY] = 1;
                    BattelControl.My_field[PosX + 1, PosY] = 1;
                }
            }
            else
            {
                if (Active == "Tree")
                {
                    if (Rotate == "Up" && PosY < 8)
                    {
                        //
                        //создадим  тайтл
                        BattelControl.My_Title[PosX, PosY] = Instantiate(Title, new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - PosY * 3.9667f), Quaternion.identity, MassTitle.transform);
                        BattelControl.My_Title[PosX, PosY + 1] = Instantiate(Title, new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - (PosY + 1) * 3.9667f), Quaternion.identity, MassTitle.transform);
                        BattelControl.My_Title[PosX, PosY + 2] = Instantiate(Title, new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - (PosY + 2) * 3.9667f), Quaternion.identity, MassTitle.transform);
                        //
                        //создадим кораблик
                        BattelControl.ListShip.Add(Instantiate(Ship_3, new Vector3(15.2f + PosX * 3.9667f, 4.66f, 19.2f - PosY * 3.9667f), Ship_3.transform.rotation, MassShip.transform));
                        //
                        //на массиве клеточик установим  ( 1 ) в поле где кораблик установлен
                        BattelControl.My_field[PosX, PosY] = 1;
                        BattelControl.My_field[PosX, PosY + 1] = 1;
                        BattelControl.My_field[PosX, PosY + 2] = 1;

                    }
                    if (Rotate == "Down" && PosY > 1)
                    {
                        //
                        //создадим  тайтл
                        BattelControl.My_Title[PosX, PosY] = Instantiate(Title, new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - PosY * 3.9667f), Quaternion.identity, MassTitle.transform);
                        BattelControl.My_Title[PosX, PosY - 1] = Instantiate(Title, new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - (PosY - 1) * 3.9667f), Quaternion.identity, MassTitle.transform);
                        BattelControl.My_Title[PosX, PosY - 2] = Instantiate(Title, new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - (PosY - 2) * 3.9667f), Quaternion.identity, MassTitle.transform);
                        //
                        //создадим кораблик
                        BattelControl.ListShip.Add(Instantiate(Ship_3, new Vector3(15.2f + PosX * 3.9667f, 4.66f, 26.4f - PosY * 3.9667f), Ship_3.transform.rotation, MassShip.transform));
                        //
                        //на массиве клеточик установим  ( 1 ) в поле где кораблик установлен
                        BattelControl.My_field[PosX, PosY] = 1;
                        BattelControl.My_field[PosX, PosY - 1] = 1;
                        BattelControl.My_field[PosX, PosY - 2] = 1;
                    }
                    if (Rotate == "Right" && PosX > 1)
                    {
                        //
                        //создадим  тайтл
                        BattelControl.My_Title[PosX, PosY] = Instantiate(Title, new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - PosY * 3.9667f), Quaternion.identity, MassTitle.transform);
                        BattelControl.My_Title[PosX - 1, PosY] = Instantiate(Title, new Vector3(15.2f + (PosX - 1) * 3.9667f, 4.66f, 22.8f - (PosY) * 3.9667f), Quaternion.identity, MassTitle.transform);
                        BattelControl.My_Title[PosX - 2, PosY] = Instantiate(Title, new Vector3(15.2f + (PosX - 2) * 3.9667f, 4.66f, 22.8f - (PosY) * 3.9667f), Quaternion.identity, MassTitle.transform);
                        //
                        //создадим кораблик
                        BattelControl.ListShip.Add(Instantiate(Ship_3, new Vector3(11.6f + PosX * 3.9667f, 4.66f, 22.8f - PosY * 3.9667f), Ship_3.transform.rotation, MassShip.transform));
                        //
                        //на массиве клеточик установим  ( 1 ) в поле где кораблик установлен
                        BattelControl.My_field[PosX, PosY] = 1;
                        BattelControl.My_field[PosX - 1, PosY] = 1;
                        BattelControl.My_field[PosX - 2, PosY] = 1;
                    }
                    if (Rotate == "Left" && PosX < 8)
                    {
                        //
                        //создадим  тайтл
                        BattelControl.My_Title[PosX, PosY] = Instantiate(Title, new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - PosY * 3.9667f), Quaternion.identity, MassTitle.transform);
                        BattelControl.My_Title[PosX + 1, PosY] = Instantiate(Title, new Vector3(15.2f + (PosX + 1) * 3.9667f, 4.66f, 22.8f - (PosY) * 3.9667f), Quaternion.identity, MassTitle.transform);
                        BattelControl.My_Title[PosX + 2, PosY] = Instantiate(Title, new Vector3(15.2f + (PosX + 2) * 3.9667f, 4.66f, 22.8f - (PosY) * 3.9667f), Quaternion.identity, MassTitle.transform);
                        //
                        //создадим кораблик
                        BattelControl.ListShip.Add(Instantiate(Ship_3, new Vector3(18.8f + PosX * 3.9667f, 4.66f, 22.8f - PosY * 3.9667f), Ship_3.transform.rotation, MassShip.transform));
                        //
                        //на массиве клеточик установим  ( 1 ) в поле где кораблик установлен
                        BattelControl.My_field[PosX, PosY] = 1;
                        BattelControl.My_field[PosX + 1, PosY] = 1;
                        BattelControl.My_field[PosX + 2, PosY] = 1;
                    }
                }
                else
                {
                    if (Rotate == "Up" && PosY < 7)
                    {
                        //
                        //создадим  тайтл
                        BattelControl.My_Title[PosX, PosY] = Instantiate(Title, new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - PosY * 3.9667f), Quaternion.identity, MassTitle.transform);
                        BattelControl.My_Title[PosX, PosY + 1] = Instantiate(Title, new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - (PosY + 1) * 3.9667f), Quaternion.identity, MassTitle.transform);
                        BattelControl.My_Title[PosX, PosY + 2] = Instantiate(Title, new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - (PosY + 2) * 3.9667f), Quaternion.identity, MassTitle.transform);
                        BattelControl.My_Title[PosX, PosY + 3] = Instantiate(Title, new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - (PosY + 3) * 3.9667f), Quaternion.identity, MassTitle.transform);
                        //
                        //создадим кораблик
                        BattelControl.ListShip.Add(Instantiate(Ship_4, new Vector3(15.2f + PosX * 3.9667f, 4.66f, 17.4f - PosY * 3.9667f), Ship_4.transform.rotation, MassShip.transform));
                        //
                        //на массиве клеточик установим  ( 1 ) в поле где кораблик установлен
                        BattelControl.My_field[PosX, PosY] = 1;
                        BattelControl.My_field[PosX, PosY + 1] = 1;
                        BattelControl.My_field[PosX, PosY + 2] = 1;
                        BattelControl.My_field[PosX, PosY + 3] = 1;
                    }
                    if (Rotate == "Down" && PosY > 2)
                    {
                        //
                        //создадим  тайтл
                        BattelControl.My_Title[PosX, PosY] = Instantiate(Title, new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - PosY * 3.9667f), Quaternion.identity, MassTitle.transform);
                        BattelControl.My_Title[PosX, PosY - 1] = Instantiate(Title, new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - (PosY - 1) * 3.9667f), Quaternion.identity, MassTitle.transform);
                        BattelControl.My_Title[PosX, PosY - 2] = Instantiate(Title, new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - (PosY - 2) * 3.9667f), Quaternion.identity, MassTitle.transform);
                        BattelControl.My_Title[PosX, PosY - 3] = Instantiate(Title, new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - (PosY - 3) * 3.9667f), Quaternion.identity, MassTitle.transform);
                        //
                        //создадим кораблик
                        BattelControl.ListShip.Add(Instantiate(Ship_4, new Vector3(15.2f + PosX * 3.9667f, 4.66f, 28.2f - PosY * 3.9667f), Ship_4.transform.rotation, MassShip.transform));
                        //
                        //на массиве клеточик установим  ( 1 ) в поле где кораблик установлен
                        BattelControl.My_field[PosX, PosY] = 1;
                        BattelControl.My_field[PosX, PosY - 1] = 1;
                        BattelControl.My_field[PosX, PosY - 2] = 1;
                        BattelControl.My_field[PosX, PosY - 3] = 1;
                    }
                    if (Rotate == "Right" && PosX > 2)
                    {
                        //
                        //создадим  тайтл
                        BattelControl.My_Title[PosX, PosY] = Instantiate(Title, new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - PosY * 3.9667f), Quaternion.identity, MassTitle.transform);
                        BattelControl.My_Title[PosX - 1, PosY] = Instantiate(Title, new Vector3(15.2f + (PosX - 1) * 3.9667f, 4.66f, 22.8f - (PosY) * 3.9667f), Quaternion.identity, MassTitle.transform);
                        BattelControl.My_Title[PosX - 2, PosY] = Instantiate(Title, new Vector3(15.2f + (PosX - 2) * 3.9667f, 4.66f, 22.8f - (PosY) * 3.9667f), Quaternion.identity, MassTitle.transform);
                        BattelControl.My_Title[PosX - 3, PosY] = Instantiate(Title, new Vector3(15.2f + (PosX - 3) * 3.9667f, 4.66f, 22.8f - (PosY) * 3.9667f), Quaternion.identity, MassTitle.transform);
                        //
                        //создадим кораблик
                        BattelControl.ListShip.Add(Instantiate(Ship_4, new Vector3(9.8f + PosX * 3.9667f, 4.66f, 22.8f - PosY * 3.9667f), Ship_4.transform.rotation, MassShip.transform));
                        //
                        //на массиве клеточик установим  ( 1 ) в поле где кораблик установлен
                        BattelControl.My_field[PosX, PosY] = 1;
                        BattelControl.My_field[PosX - 1, PosY] = 1;
                        BattelControl.My_field[PosX - 2, PosY] = 1;
                        BattelControl.My_field[PosX - 3, PosY] = 1;
                    }
                    if (Rotate == "Left" && PosX < 7)
                    {
                        //
                        //создадим  тайтл
                        BattelControl.My_Title[PosX, PosY] = Instantiate(Title, new Vector3(15.2f + PosX * 3.9667f, 4.66f, 22.8f - PosY * 3.9667f), Quaternion.identity, MassTitle.transform);
                        BattelControl.My_Title[PosX + 1, PosY] = Instantiate(Title, new Vector3(15.2f + (PosX + 1) * 3.9667f, 4.66f, 22.8f - (PosY) * 3.9667f), Quaternion.identity, MassTitle.transform);
                        BattelControl.My_Title[PosX + 2, PosY] = Instantiate(Title, new Vector3(15.2f + (PosX + 2) * 3.9667f, 4.66f, 22.8f - (PosY) * 3.9667f), Quaternion.identity, MassTitle.transform);
                        BattelControl.My_Title[PosX + 3, PosY] = Instantiate(Title, new Vector3(15.2f + (PosX + 3) * 3.9667f, 4.66f, 22.8f - (PosY) * 3.9667f), Quaternion.identity, MassTitle.transform);
                        //
                        //создадим кораблик
                        BattelControl.ListShip.Add(Instantiate(Ship_4, new Vector3(20.6f + PosX * 3.9667f, 4.66f, 22.8f - PosY * 3.9667f), Ship_4.transform.rotation, MassShip.transform));
                        //
                        //на массиве клеточик установим  ( 1 ) в поле где кораблик установлен
                        BattelControl.My_field[PosX, PosY] = 1;
                        BattelControl.My_field[PosX + 1, PosY] = 1;
                        BattelControl.My_field[PosX + 2, PosY] = 1;
                        BattelControl.My_field[PosX + 3, PosY] = 1;
                    }



                }

            }
        }

    }

    //
    //Cброс в начальное состояние
    //


    public void Reset()
    {

        //
        //Установим значение по умолчанию
        //
        StartButton.SetActive(false);
        BattelControl.Massive_Reset_ALL();

        Rotate = "Up";
        Ship[0] = 4;   // 0 - 1 клеточный
        Ship[1] = 3;   // 1 - 2 клеточный
        Ship[2] = 2;   // 2 - 3 клеточный
        Ship[3] = 1;   // 3 - 4 клеточный
        Active = null;
        ActiveAs = false;

        
        //
        //Cбрасываем текстовые поля
        //
        Text_Ship1.text = Ship[0].ToString();
        Text_Ship2.text = Ship[1].ToString();
        Text_Ship3.text = Ship[2].ToString();
        Text_Ship4.text = Ship[3].ToString();

       
    }

    //
    //Функция проверки на то что бы активировать кнопку старта игры при условии что все объекты раставленны по полю
    //

    private bool SheckStart()
    {
        bool Sheck = false;
        if(Ship[0] == 0 && Ship[1] == 0 && Ship[2] == 0 && Ship[3] == 0)// 0 - 1 клеточный
           Sheck = true;

        return Sheck;
    }

    //
    // Основная функция
    //

    public void Update()
    {
        if (ButtonManager.Scene == "SetShip" && Active != null && Ship[ActiveToInt(Active)] >=1)
        {
           Vector2Int Point = GameControl.GetComponent<RayDirection>().GetPoint();
            if (Point.x == -1 || Point.y == -1)
            {
                PosX = Point.x;
                PosY = Point.y;
                ActiveAs = false;
                //
                //Установим в  0  значение передвежный   titlev
                //
                Title.transform.position = new Vector3(0, 0, 0);
                Title2.transform.position = new Vector3(0, 0, 0);
                Title3.transform.position = new Vector3(0, 0, 0);
                Title4.transform.position = new Vector3(0, 0, 0);
                //
                // Установим в   0 значение передвежных кораблей
                //
                Ship_1.transform.position = new Vector3(0, 0, 0);
                Ship_2.transform.position = new Vector3(0, 0, 0);
                Ship_3.transform.position = new Vector3(0, 0, 0);
                Ship_4.transform.position = new Vector3(0, 0, 0);
            }
            else
            {
                ActiveAs = true;
                PosX = Point.x;
                PosY = Point.y;

                if (BattelControl.Place_Check(PosX, PosY, Active, Rotate) == true)
                {
                    //print("пусто");
                    SetTitleMaterial("Empty");
                }
                else
                {
                    //print("занято");
                    SetTitleMaterial("Occupied");
                }
                    MoveActiveTitle();

               
            }
            
        }


        if (Input.GetMouseButtonDown(0))
        {
            if (Active != null && Ship[ActiveToInt(Active)] >= 1 && ActiveAs && ButtonManager.Scene == "SetShip")
            {
                //
                //Как только прошли проверку все передвежный тайтлы отправляем в 0 0 0
                //
                Title.transform.position = new Vector3(0, 0, 0);
                Title2.transform.position = new Vector3(0, 0, 0);
                Title3.transform.position = new Vector3(0, 0, 0);
                Title4.transform.position = new Vector3(0, 0, 0);
                //
                // Установим в   0 значение передвежных кораблей
                //
                Ship_1.transform.position = new Vector3(0, 0, 0);
                Ship_2.transform.position = new Vector3(0, 0, 0);
                Ship_3.transform.position = new Vector3(0, 0, 0);
                Ship_4.transform.position = new Vector3(0, 0, 0);

                if (BattelControl.Place_Check(PosX, PosY, Active, Rotate) == true)
                {
                    CreateTtile();

                    Ship[ActiveToInt(Active)]--;
                    if (Active == "One")
                        Text_Ship1.text = Ship[ActiveToInt(Active)].ToString();
                    if (Active == "Two")
                        Text_Ship2.text = Ship[ActiveToInt(Active)].ToString();
                    if (Active == "Tree")
                        Text_Ship3.text = Ship[ActiveToInt(Active)].ToString();
                    if (Active == "Fore")
                        Text_Ship4.text = Ship[ActiveToInt(Active)].ToString();
                    //
                    //Если все кораблики раставленны то включим кнопку играть
                    //и уберем активые элементы в любом случае
                    //
                    //print(Sum());
                    if (SheckStart())
                    {

                        StartButton.SetActive(true);

                    }
                    Active = null;
                }

                
            }
            else
            {
              //  Active = null;
            }
        }



        //
        // повороты налево и направо
        //

        if (Input.GetKeyDown(InputManager.Key_Rotate_Right) && ButtonManager.Scene == "SetShip")//можем повернуть если находимся только на сцене растановки корабликов
        {
            if (Rotate == "Up")
            {
                Rotate = "Right";
                
            }
            else
            {
                if (Rotate == "Right")
                {
                    Rotate = "Down";
                   
                }
                else
                {
                    if (Rotate == "Down")
                    {
                        Rotate = "Left";
                        
                    }
                    else
                    {
                        Rotate = "Up";
                        
                    }
                }
            }
            RotateShip();

        }
        if (Input.GetKeyDown(InputManager.Key_Rotate_Left) && ButtonManager.Scene == "SetShip")//можем повернуть если находимся только на сцене растановки корабликов
        {
            if(Rotate == "Up")
            {
                Rotate = "Left";
                
            }
            else
            {
                if (Rotate == "Right")
                {
                    Rotate = "Up";
                    
                }
                else
                {
                    if (Rotate == "Down")
                    {
                        Rotate = "Right";
                        
                    }
                    else
                    {
                        Rotate = "Down";
                        
                    }
                }
            }
            RotateShip();
        }
        
    }


    //
    //   Установка кораблей под правильным углом
    //

    private void RotateShip()
    {
        switch (Rotate)
        {
            case "Up": {
                    Ship_1.transform.eulerAngles = new Vector3(0, 0, 0);
                    Ship_2.transform.eulerAngles = new Vector3(0, 0, 0);
                    Ship_3.transform.eulerAngles = new Vector3(0, 0, 0);
                    Ship_4.transform.eulerAngles = new Vector3(0, 0, 0);

                    break;
            }
            case "Right":
                {
                    Ship_1.transform.eulerAngles = new Vector3(0, 90, 0);
                    Ship_2.transform.eulerAngles = new Vector3(0, 90, 0);
                    Ship_3.transform.eulerAngles = new Vector3(0, 90, 0);
                    Ship_4.transform.eulerAngles = new Vector3(0, 90, 0);


                    break;
                }
            case "Down":
                {
                    Ship_1.transform.eulerAngles = new Vector3(0, 180, 0);
                    Ship_2.transform.eulerAngles = new Vector3(0, 180, 0);
                    Ship_3.transform.eulerAngles = new Vector3(0, 180, 0);
                    Ship_4.transform.eulerAngles = new Vector3(0, 180, 0);


                    break;
                }
            case "Left":
                {
                    Ship_1.transform.eulerAngles = new Vector3(0, 270, 0);
                    Ship_2.transform.eulerAngles = new Vector3(0, 270, 0);
                    Ship_3.transform.eulerAngles = new Vector3(0, 270, 0);
                    Ship_4.transform.eulerAngles = new Vector3(0, 270, 0);


                    break;
                }
        }
    }
    //
    //
    //

    //
    // Ниже идут функция связанные  с растановкой кораблей на поле противника при нажатии на кнопку старт
    //

    //
    //
    //

    public void SetBotShip()
    {
        //
        // Заполним массив корабликами
        // Для начала установим 4 палубный кораблик
        //
        System.Random rnd = new System.Random();

        //
        // 
        //
        int Type = 3; ;
        for (int j = 0; j < 10; j++)
        {
            
            if (j == 0) { Type = 3; }
            if (j > 0 && j < 3) { Type = 2; }
            if (j > 2 && j < 6) { Type = 1; }
            if (j > 5 && j < 10) { Type = 0; }

            int Bot_PosX = rnd.Next(0, 10);
            int Bot_PosY = rnd.Next(0, 10);            
            int Rotate = rnd.Next(0, 4);
            if (BattelControl.BOT_Place_Check(Bot_PosX, Bot_PosY, ActiveToString(Type), RotateToString(Rotate))) // если место свободно тогда заполняем клетки иначе ищем ту клетку где будет свободно
            {
                print("SET-1");
                BattelControl.Set_BOT_Ship(Bot_PosX, Bot_PosY, ActiveToString(Type), RotateToString(Rotate));
            }
            else
            {
                do
                {
                    Bot_PosX = rnd.Next(0, 10);
                    Bot_PosY = rnd.Next(0, 10);                    
                    Rotate = rnd.Next(0, 4);
                    if (BattelControl.BOT_Place_Check(Bot_PosX, Bot_PosY, ActiveToString(Type), RotateToString(Rotate)))
                    {
                        BattelControl.Set_BOT_Ship(Bot_PosX, Bot_PosY, ActiveToString(Type), RotateToString(Rotate));
                        print("SET-2");
                        break;
                    }
                } while (true == true);
            }

        }
        BattelControl.ResetValues();


    }
}
