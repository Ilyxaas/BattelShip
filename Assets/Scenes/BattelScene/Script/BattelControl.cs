using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BattelControl : MonoBehaviour
{
    public GameObject GameControl;
    public GameObject AudioManager;
    public GameObject Title;
    public GameObject Cursor;
    public GameObject Dagger;

    public GameObject WinText;
    public GameObject DefeatText;

    public GameObject MassTitle;
    //
    // Материалы рендера
    //
    public Material Senter_Yes; //  материал клетки на котором находится кораблик если место свободно
    public Material Senter_No; //  материал клетки на котором находится кораблик если место занято
    public Material Perimeter; // материал клетки по периметру от кораблика

    public int[,] My_field = new int[10, 10];
    public int[,] Bot_field = new int[10, 10];

    public GameObject[,] My_Title = new GameObject[10, 10];
    public GameObject[,] Bot_Title = new GameObject[10, 10];
    public List<GameObject> ListShip = null;
    public Text Xode;


    private SoundControler SoundControler;
    private ButtonManager ButtonManager;
    //
    // переменные необходимые для самого сражения при запуженной сцене  Battel
    //
    public int MyEmpty; //  сколько осталось пустых клеток на моем поле
    public int BotEmpty; // сколько осталось пустных клеток на поле апонента

    public int MyEmptyShip; // сколько клеток кораблей на моем поле на которые еще не поле
    public int BotEmptyShip; // сколько клеток кораблей на поле апонента на которые еще не поле


    public int Number_Xod; // номер хода

    public string Motion; // чей ход



    public void Start()
    {
        SoundControler = AudioManager.GetComponent<SoundControler>();
        ButtonManager = GameControl.GetComponent<ButtonManager>();

        Motion = "My";
        Number_Xod = 0;

        for (int i = 0; i < 10; i++)
            for (int j = 0; j < 10; j++)
            {
                //
                //Заполним масивы значениями по умолчанию
                //
                My_field[i, j] = 0;
                Bot_field[i, j] = 0;
            }
    }
    //
    //пересчет значений переменных
    //

    public void ResetValues()
    {
        int myEmpty = 0; //  сколько осталось пустых клеток на моем поле
        int botEmpty = 0; // сколько осталось пустных клеток на поле апонента
        int myEmptyShip = 0; // сколько клеток кораблей на моем поле на которые еще не поле
        int botEmptyShip = 0; // сколько клеток кораблей на поле апонента на которые еще не поле

        for (int i = 0; i < 10; i++)
            for (int j = 0; j < 10; j++)
            {
                if (My_field[i, j] < 2) myEmpty++;
                if (My_field[i, j] == 1) myEmptyShip++;
                if (Bot_field[i, j] < 2) botEmpty++;
                if (Bot_field[i, j] == 1) botEmptyShip++;
            }

        MyEmpty = myEmpty;
        BotEmpty = botEmpty;
        MyEmptyShip = myEmptyShip;
        BotEmptyShip = botEmptyShip;

        Xode.text = Number_Xod.ToString();
    }

    //
    // очистка массивов
    //
    public void Massive_Reset_ALL()
    {
        ResetValues();
        //
        // Очистим массивы в 0
        //
        for (int i = 0; i < 10; i++)
            for (int j = 0; j < 10; j++)
            {
                //
                //Очистим масивы значени
                //
                My_field[i, j] = 0;
                Bot_field[i, j] = 0;
                //
                //очистим массивы Titlov
                //
                Bot_field[i, j] = 0;
                My_field[i, j] = 0;
                if (My_Title[i, j] != null)
                    Destroy(My_Title[i, j]);
                if (Bot_Title[i, j] != null)
                    Destroy(Bot_Title[i, j]);
            }
        //
        //Очищаем список кораблей
        //
        foreach (GameObject i in ListShip)
        {
            Destroy(i);
        }

        ListShip.Clear();



    }
    public bool Place_Check(int PosX, int PosY, string Active, string Rotate)
    {
        //создадим переменную отвечающую за пустоту и по умолчанию говорим что места нет
        const int Size = 3; // минимальное поле 3 на 3 для единичного кораблики

        bool Place_Check = false;

        int ActiveIndex = 0;

        //string Print;
        //
        //
        //

        if (Active == "One")
            ActiveIndex = 0;
        if (Active == "Two")
            ActiveIndex = 1;
        if (Active == "Tree")
            ActiveIndex = 2;
        if (Active == "Fore")
            ActiveIndex = 3;


        if (Rotate == "Up")
        {

            int sum = 0;  //   кол во перечечений с другими кораблями
            for (int i = 0; i < Size; i++) // i - x ; j - y
                for (int j = 0; j < Size + ActiveIndex; j++)
                {

                    if (PosX - i + 1 < 10 && PosY - j + 1 + ActiveIndex < 10 && PosX - i + 1 > -1 && PosY - j + 1 + ActiveIndex > -1) //если мы не вышли за границы поля
                    {
                        //Print = "X :" + (PosX - i + 1).ToString() + " | " + "Y :" + (PosY - j + 1 + ActiveIndex).ToString() + " == " + My_field[PosX - i + 1, PosY - j + 1 + ActiveIndex].ToString();
                        if (My_field[PosX - i + 1, PosY - j + 1 + ActiveIndex] == 1)
                            sum++;
                        //print(Print);
                    }
                }

            if (sum == 0) Place_Check = true; //если мы не встретили пересечений с кораблями значит сум равна нулю тогда это место свободно для нашего кораблика
        }

        if (Rotate == "Down")
        {

            int sum = 0;  //   кол во перечечений с другими кораблями
            for (int i = 0; i < Size; i++) // i - x ; j - y
                for (int j = 0; j < Size + ActiveIndex; j++)
                {

                    if (PosX - i + 1 < 10 && PosY - j + 1 < 10 && PosX - i + 1 > -1 && PosY - j + 1 > -1) //если мы не вышли за границы поля
                    {
                        //Print = "X :" + (PosX - i + 1).ToString() + " | " + "Y :" + (PosY - j + 1 ).ToString() + " == " + My_field[PosX - i + 1, PosY - j + 1 ].ToString();
                        if (My_field[PosX - i + 1, PosY - j + 1] == 1)
                            sum++;
                        //print(Print);
                    }
                }

            if (sum == 0) Place_Check = true; //если мы не встретили пересечений с кораблями значит сум равна нулю тогда это место свободно для нашего кораблика
        }


        if (Rotate == "Right")
        {


            int sum = 0;  //   кол во перечечений с другими кораблями
            for (int i = 0; i < Size + ActiveIndex; i++) // i - x ; j - y
                for (int j = 0; j < Size; j++)
                {

                    if (PosX - i + 1 < 10 && PosY - j + 1 < 10 && PosX - i + 1 > -1 && PosY - j + 1 > -1) //если мы не вышли за границы поля
                    {
                        //Print = "X :" + (PosX - i + 1).ToString() + " | " + "Y :" + (PosY - j + 1).ToString() + " == " + My_field[PosX - i + 1, PosY - j + 1].ToString();
                        if (My_field[PosX - i + 1, PosY - j + 1] == 1)
                            sum++;
                        //print(Print);
                    }
                }

            if (sum == 0) Place_Check = true; //если мы не встретили пересечений с кораблями значит сум равна нулю тогда это место свободно для нашего кораблика
        }


        if (Rotate == "Left")
        {

            int sum = 0;  //   кол во перечечений с другими кораблями
            for (int i = 0; i < Size + ActiveIndex; i++) // i - x ; j - y
                for (int j = 0; j < Size; j++)
                {

                    if (PosX - i + 1 + ActiveIndex < 10 && PosY - j + 1 < 10 && PosX - i + 1 + ActiveIndex > -1 && PosY - j + 1 > -1) //если мы не вышли за границы поля
                    {
                        //Print = "X :" + (PosX - i + 1 + ActiveIndex).ToString() + " | " + "Y :" + (PosY - j + 1).ToString() + " == " + My_field[PosX - i + 1 + ActiveIndex, PosY - j + 1].ToString();
                        if (My_field[PosX - i + 1 + ActiveIndex, PosY - j + 1] == 1)
                            sum++;
                        //print(Print);
                    }
                }

            if (sum == 0) Place_Check = true; //если мы не встретили пересечений с кораблями значит сум равна нулю тогда это место свободно для нашего кораблика


        }

        return Place_Check;
    }



    //
    //  Точно такая же функция для поля противника
    //
    //

    public bool BOT_Place_Check(int PosX, int PosY, string Active, string Rotate)
    {
        //создадим переменную отвечающую за пустоту и по умолчанию говорим что места нет
        const int Size = 3; // минимальное поле 3 на 3 для единичного кораблики

        bool Place_Check = false;

        int ActiveIndex = 0;

        //string Print;
        //
        //
        //

        if (Active == "One")
            ActiveIndex = 0;
        if (Active == "Two")
            ActiveIndex = 1;
        if (Active == "Tree")
            ActiveIndex = 2;
        if (Active == "Fore")
            ActiveIndex = 3;


        if (Rotate == "Up")
        {
            if (PosY + ActiveIndex > 9)
                return false;


            int sum = 0;  //   кол во перечечений с другими кораблями
            for (int i = 0; i < Size; i++) // i - x ; j - y
                for (int j = 0; j < Size + ActiveIndex; j++)
                {

                    if (PosX - i + 1 < 10 && PosY - j + 1 + ActiveIndex < 10 && PosX - i + 1 > -1 && PosY - j + 1 + ActiveIndex > -1) //если мы не вышли за границы поля
                    {
                        //Print = "X :" + (PosX - i + 1).ToString() + " | " + "Y :" + (PosY - j + 1 + ActiveIndex).ToString() + " == " + My_field[PosX - i + 1, PosY - j + 1 + ActiveIndex].ToString();
                        if (Bot_field[PosX - i + 1, PosY - j + 1 + ActiveIndex] == 1)
                            sum++;
                        //print(Print);
                    }
                }

            if (sum == 0) Place_Check = true; //если мы не встретили пересечений с кораблями значит сум равна нулю тогда это место свободно для нашего кораблика
        }

        if (Rotate == "Down")
        {
            if (PosY - ActiveIndex < 0)
                return false;

            int sum = 0;  //   кол во перечечений с другими кораблями
            for (int i = 0; i < Size; i++) // i - x ; j - y
                for (int j = 0; j < Size + ActiveIndex; j++)
                {

                    if (PosX - i + 1 < 10 && PosY - j + 1 < 10 && PosX - i + 1 > -1 && PosY - j + 1 > -1) //если мы не вышли за границы поля
                    {
                        //Print = "X :" + (PosX - i + 1).ToString() + " | " + "Y :" + (PosY - j + 1 ).ToString() + " == " + My_field[PosX - i + 1, PosY - j + 1 ].ToString();
                        if (Bot_field[PosX - i + 1, PosY - j + 1] == 1)
                            sum++;
                        //print(Print);
                    }
                }

            if (sum == 0) Place_Check = true; //если мы не встретили пересечений с кораблями значит сум равна нулю тогда это место свободно для нашего кораблика
        }


        if (Rotate == "Right")
        {
            if (PosX - ActiveIndex < 0)
                return false;

            int sum = 0;  //   кол во перечечений с другими кораблями
            for (int i = 0; i < Size + ActiveIndex; i++) // i - x ; j - y
                for (int j = 0; j < Size; j++)
                {

                    if (PosX - i + 1 < 10 && PosY - j + 1 < 10 && PosX - i + 1 > -1 && PosY - j + 1 > -1) //если мы не вышли за границы поля
                    {
                        //Print = "X :" + (PosX - i + 1).ToString() + " | " + "Y :" + (PosY - j + 1).ToString() + " == " + My_field[PosX - i + 1, PosY - j + 1].ToString();
                        if (Bot_field[PosX - i + 1, PosY - j + 1] == 1)
                            sum++;
                        //print(Print);
                    }
                }

            if (sum == 0) Place_Check = true; //если мы не встретили пересечений с кораблями значит сум равна нулю тогда это место свободно для нашего кораблика
        }


        if (Rotate == "Left")
        {
            if (PosX + ActiveIndex > 9)
                return false;


            int sum = 0;  //   кол во перечечений с другими кораблями
            for (int i = 0; i < Size + ActiveIndex; i++) // i - x ; j - y
                for (int j = 0; j < Size; j++)
                {

                    if (PosX - i + 1 + ActiveIndex < 10 && PosY - j + 1 < 10 && PosX - i + 1 + ActiveIndex > -1 && PosY - j + 1 > -1) //если мы не вышли за границы поля
                    {
                        //Print = "X :" + (PosX - i + 1 + ActiveIndex).ToString() + " | " + "Y :" + (PosY - j + 1).ToString() + " == " + My_field[PosX - i + 1 + ActiveIndex, PosY - j + 1].ToString();
                        if (Bot_field[PosX - i + 1 + ActiveIndex, PosY - j + 1] == 1)
                            sum++;
                        //print(Print);
                    }
                }

            if (sum == 0) Place_Check = true; //если мы не встретили пересечений с кораблями значит сум равна нулю тогда это место свободно для нашего кораблика


        }

        return Place_Check;
    }





    public void Set_BOT_Ship(int PosX, int PosY, string Active, string Rotate)
    {

        int ActiveIndex = 0;

        //string Print;
        //
        //
        //

        if (Active == "One")
            ActiveIndex = 1;
        if (Active == "Two")
            ActiveIndex = 2;
        if (Active == "Tree")
            ActiveIndex = 3;
        if (Active == "Fore")
            ActiveIndex = 4;

        if (Rotate == "Up")
        {
            for (int i = 0; i < ActiveIndex; i++)
                Bot_field[PosX, PosY + i] = 1;
            return;
        }
        if (Rotate == "Down")
        {
            for (int i = 0; i < ActiveIndex; i++)
                Bot_field[PosX, PosY - i] = 1;
            return;
        }
        if (Rotate == "Right")
        {
            for (int i = 0; i < ActiveIndex; i++)
                Bot_field[PosX - i, PosY] = 1;
            return;
        }
        if (Rotate == "Left")
        {
            for (int i = 0; i < ActiveIndex; i++)
                Bot_field[PosX + i, PosY] = 1;
            return;
        }
    }

    //
    //Функция которая остонавливает поток на какое то значение в милисикундах
    //

    public void Pause(int Second)
    {
        float Milisecond = 0f;
        while (Milisecond <= Second)
        {
            Milisecond += Time.deltaTime;
        }
        return;
    }


    //
    //Функция которая вызывается при ходе бота
    //
    private void Bot_Xode()
    {
        System.Random rnd = new System.Random();
        int X = rnd.Next(0, 10);
        int Y = rnd.Next(0, 10);
        if (My_field[X, Y] > 1)
        {
            do
            {
                X = rnd.Next(0, 10);
                Y = rnd.Next(0, 10);

            }
            while (My_field[X, Y] > 1);
        }


        if (My_field[X, Y] == 0)// если мы попали в свободную клетку и она пустая
        {
            My_Title[X, Y] = Instantiate(Title, new Vector3(15.2f + X * 3.9667f, 4.66f, 22.8f - Y * 3.9667f), Quaternion.identity, MassTitle.transform);
            My_Title[X, Y].GetComponent<Renderer>().material = Senter_No;
            My_field[X, Y] = 3;
            Motion = "My";
            Number_Xod++;
            ResetValues();
        }
        if (My_field[X, Y] == 1)// если мы попали в свободную клетку и на ней стоит кораблик
        {
            My_Title[X, Y] = Instantiate(Dagger, new Vector3(15.2f + X * 3.9667f, 4.66f, 22.8f - Y * 3.9667f), Dagger.transform.rotation, MassTitle.transform);
            My_field[X, Y] = 2;
            Motion = "Bot";
            Number_Xod++;
            //
            //если мы попали по кораблику то это могла бы быть последняя клетка с кораблем значит надо проверить не выйграли ли мы
            //
            ResetValues();
            if (MyEmptyShip == 0)
            {
                SetWin(false);
            }
            else
            {
                Bot_Xode();
            }

        }

    }

    private bool CheakDead(Vector2Int Point, string Floor, string direction)
    {
        int PosX = Point.x;
        int PosY = Point.y;
        if (Floor == "My")
        {
            if (direction == "Up")
            {
                while (My_field[PosX, PosY] == 2)
                {
                    if (PosY <= 9)
                        PosY++;
                }
                if (My_field[PosX, PosY] == 1)
                    return false;
                else
                    return true;
            }
            if (direction == "Left")
            {
                while (My_field[PosX, PosY] == 2)
                {
                    if (PosX <= 9)
                        PosX++;
                }
                if (My_field[PosX, PosY] == 1)
                    return false;
                else
                    return true;
            }
            return true;
        }
        else
        {
            if (direction == "Up")
            {
                while (Bot_field[PosX, PosY] == 2)
                {
                    if (PosY <= 9)
                        PosY++;
                }
                if (Bot_field[PosX, PosY] == 1)
                    return false;
                else
                    return true;
            }
            if (direction == "Left")
            {
                while (Bot_field[PosX, PosY] == 2)
                {
                    if (PosX <= 9)
                        PosX++;
                }
                if (Bot_field[PosX, PosY] == 1)
                    return false;
                else
                    return true;
            }
            return true;
        }
    }

    //\
    // Функция которая возвращает объект точку и направление
    //

    private LDPoint SetLDPoint(Vector2Int Point, string Floor, string direction = null)
    {

        if (Floor == "My")
        {
            //
            //Для начала проверим находимся ли мы на центральной клетки корабля или же нет
            //
            if (Point.x > 0 && My_field[Point.x - 1, Point.y] == 2 && direction == null)
            {
                return SetLDPoint(new Vector2Int(Point.x - 1, Point.y), Floor, "Right");
            }

            if (Point.x < 9 && My_field[Point.x + 1, Point.y] == 2 && direction == null && Point.x > 0 && My_field[Point.x - 1, Point.y] != 2)
            {
                print("12");
                return new LDPoint(Point, LDPoint.Right);
            }
            if (Point.y > 0 && My_field[Point.x, Point.y - 1] == 2 && direction == null)
            {
                return SetLDPoint(new Vector2Int(Point.x, Point.y - 1), Floor, "Down");
            }

            if (Point.y < 9 && Bot_field[Point.y, Point.y + 1] == 2 && direction == null && Point.y > 0 && Bot_field[Point.x, Point.y - 1] != 2)
            {
                print("10");
                return new LDPoint(Point, LDPoint.Up);
            }

            //
            //  если мы знаяем что либо правее или левее есть точнка корабля которая подбита то перемещаемся в нее 
            //

            if (direction == "Right")
            {
                if (Point.x > 0 && My_field[Point.x - 1, Point.y] == 2)
                {
                    return SetLDPoint(new Vector2Int(Point.x - 1, Point.y), Floor, "Right");

                }
                if ((Point.x > 0 && My_field[Point.x - 1, Point.y] == 0) || (Point.x > 0 && My_field[Point.x - 1, Point.y] == 3))
                {
                    return new LDPoint(Point, LDPoint.Left);
                }


            }

            if (direction == "Down")
            {
                if (Point.y > 0 && My_field[Point.x, Point.y - 1] == 2)
                {
                    return SetLDPoint(new Vector2Int(Point.x, Point.y - 1), Floor, "Down");

                }
                if ((Point.y > 0 && My_field[Point.x, Point.y - 1] == 0) || (Point.y > 0 && My_field[Point.x, Point.y - 1] == 3))
                {
                    return new LDPoint(Point, LDPoint.Up);
                }

            }
        }
        else
        {
            //
            //Для начала проверим находимся ли мы на центральной клетки корабля или же нет
            //
            if (Point.x > 0 && Bot_field[Point.x - 1, Point.y] == 2 && direction == null)
            {
                return SetLDPoint(new Vector2Int(Point.x - 1, Point.y), Floor, "Left");
            }

            if (Point.x < 9 && Bot_field[Point.x + 1, Point.y] == 2 && direction == null && Point.x > 0 && Bot_field[Point.x - 1, Point.y] != 2)
            {
                print("12");
                return new LDPoint(Point, LDPoint.Right);
            }


            if (Point.y > 0 && Bot_field[Point.x, Point.y - 1] == 2 && direction == null)
            {
                return SetLDPoint(new Vector2Int(Point.x, Point.y - 1), Floor, "Down");
            }


            if (Point.y < 9 && Bot_field[Point.y, Point.y + 1] == 2 && direction == null && Point.y > 0 && Bot_field[Point.x, Point.y - 1] != 2)
            {
                print("10");
                return new LDPoint(Point, LDPoint.Up);
            }

            //
            //  если мы знаяем что либо правее или левее есть точнка корабля которая подбита то перемещаемся в нее 
            //

            if (direction == "Left")
            {
                if (Point.x > 0 && Bot_field[Point.x - 1, Point.y] == 2)
                {
                    return SetLDPoint(new Vector2Int(Point.x - 1, Point.y), Floor, "Left");

                }
                if ((Point.x > 0 && Bot_field[Point.x - 1, Point.y] == 0) || (Point.x > 0 && Bot_field[Point.x - 1, Point.y] == 3))
                {
                    return new LDPoint(Point, LDPoint.Right);
                }


            }

            if (direction == "Down")
            {
                if (Point.y > 0 && Bot_field[Point.x, Point.y - 1] == 2)
                {
                    return SetLDPoint(new Vector2Int(Point.x, Point.y - 1), Floor, "Down");

                }
                if ((Point.y > 0 && Bot_field[Point.x, Point.y - 1] == 0) || (Point.y > 0 && Bot_field[Point.x, Point.y - 1] == 3))
                {

                    return new LDPoint(Point, LDPoint.Up);
                }

            }



        }
        return new LDPoint(Point, LDPoint.Up);
    }


    //
    //Функция проверки на то что подбит ли кораблик полностью  (Рекурсивная функция)
    //

    private bool CheakShepFullDEad(Vector2Int Point, string Floor, string direction = null)
    {


        if (Floor == "My")
        {
            //
            //Для начала проверим находимся ли мы на центральной клетки корабля или же нет
            //
            if (Point.x > 0 && My_field[Point.x - 1, Point.y] == 2 && direction == null)
            {
                return CheakShepFullDEad(new Vector2Int(Point.x - 1, Point.y), Floor, "Right");
            }

            if (Point.y > 0 && My_field[Point.x, Point.y - 1] == 2 && direction == null)
            {
                return CheakShepFullDEad(new Vector2Int(Point.x, Point.y - 1), Floor, "Down");
            }

            //
            //  если мы знаяем что либо правее или левее есть точнка корабля которая подбита то перемещаемся в нее 
            //

            if (direction == "Right")
            {
                if (Point.x > 0 && My_field[Point.x - 1, Point.y] == 2)
                {
                    return CheakShepFullDEad(new Vector2Int(Point.x - 1, Point.y), Floor, "Right");

                }
                if ((Point.x > 0 && My_field[Point.x - 1, Point.y] == 0) || (Point.x > 0 && My_field[Point.x - 1, Point.y] == 3))
                {
                    return CheakDead(new Vector2Int(Point.x, Point.y), Floor, "Left");
                }
                else
                    return false;

            }

            if (direction == "Down")
            {
                if (Point.y > 0 && My_field[Point.x, Point.y - 1] == 2)
                {
                    return CheakShepFullDEad(new Vector2Int(Point.x, Point.y - 1), Floor, "Down");

                }
                if ((Point.y > 0 && My_field[Point.x, Point.y - 1] == 0) || (Point.y > 0 && My_field[Point.x, Point.y - 1] == 3))
                {
                    return CheakDead(new Vector2Int(Point.x, Point.y), Floor, "Up");
                }
                else
                    return false;
            }

            //
            if (Point.x < 9)
                if (My_field[Point.x + 1, Point.y] == 1)
                    return false;
            if (Point.x > 0)
                if (My_field[Point.x - 1, Point.y] == 1)
                    return false;
            if (Point.y < 9)
                if (My_field[Point.x, Point.y + 1] == 1)
                    return false;
            if (Point.y > 0)
                if (My_field[Point.x, Point.y - 1] == 1)
                    return false;

            return true;
        }
        else
        {
            //
            //Для начала проверим находимся ли мы на центральной клетки корабля или же нет
            //
            if (Point.x > 0 && Bot_field[Point.x - 1, Point.y] == 2 && direction == null)
            {
                return CheakShepFullDEad(new Vector2Int(Point.x - 1, Point.y), Floor, "Right");
            }

            if (Point.y > 0 && Bot_field[Point.x, Point.y - 1] == 2 && direction == null)
            {
                return CheakShepFullDEad(new Vector2Int(Point.x, Point.y - 1), Floor, "Down");
            }

            //
            //  если мы знаяем что либо правее или левее есть точнка корабля которая подбита то перемещаемся в нее 
            //

            if (direction == "Right")
            {
                if (Point.x > 0 && Bot_field[Point.x - 1, Point.y] == 2)
                {
                    return CheakShepFullDEad(new Vector2Int(Point.x - 1, Point.y), Floor, "Right");

                }
                if ((Point.x > 0 && Bot_field[Point.x - 1, Point.y] == 0) || (Point.x > 0 && Bot_field[Point.x - 1, Point.y] == 3))
                {
                    return CheakDead(new Vector2Int(Point.x, Point.y), Floor, "Left");
                }
                else
                    return false;

            }

            if (direction == "Down")
            {
                if (Point.y > 0 && Bot_field[Point.x, Point.y - 1] == 2)
                {
                    return CheakShepFullDEad(new Vector2Int(Point.x, Point.y - 1), Floor, "Down");

                }
                if ((Point.y > 0 && Bot_field[Point.x, Point.y - 1] == 0) || (Point.y > 0 && Bot_field[Point.x, Point.y - 1] == 3))
                {
                    return CheakDead(new Vector2Int(Point.x, Point.y), Floor, "Up");
                }
                else
                    return false;
            }

            //
            if (Point.x < 9)
                if (Bot_field[Point.x + 1, Point.y] == 1)
                    return false;
            if (Point.x > 0)
                if (Bot_field[Point.x - 1, Point.y] == 1)
                    return false;
            if (Point.y < 9)
                if (Bot_field[Point.x, Point.y + 1] == 1)
                    return false;
            if (Point.y > 0)
                if (Bot_field[Point.x, Point.y - 1] == 1)
                    return false;

            return true;
        }
    }


    private void SetTitlePerimetr(Vector2Int Point, string Floor, string Rotate) // Floor -  вид поля
    {
        //  на вход подаем либо крайнию правую или саму нижнюю точку корабля
        //  в данном функции мы уже точно знаем что кораблик полностью уничтожен и нет клеток равных [ 1 ]
        if (Floor == "Bot")
        {
            if (Rotate == "Up")
            {
                int set = 2;
                int PosX = Point.x;
                int PosY = Point.y - 1;

                while (set > 0)
                {
                    //
                    //если клетка на PosX PosY равна  2 то увиличиваем set
                    //
                    if(PosY + 1 < 10)
                       if (Bot_field[PosX, PosY + 1] == 2) set++;


                    //для началмы должны проверить если клетка не самая нижняя то должны поставить 3 нижних красных тайтла
                    if (PosY >= 0 && PosY < 10)
                    {
                        if (Bot_Title[PosX, PosY] == null)
                        {
                            Bot_Title[PosX, PosY] = Instantiate(Title, new Vector3(3.6f - (PosX + 2) * 3.9667f, 4.66f, 24.85f - (PosY) * 3.9667f - 2f), Quaternion.identity, MassTitle.transform);
                            Bot_Title[PosX, PosY].GetComponent<Renderer>().material = Senter_No;
                            Bot_field[PosX, PosY] = 3;
                        }

                        if (PosX - 1 >= 0 && PosX - 1 < 10)
                        {
                            if (Bot_Title[PosX - 1, PosY] == null)
                            {
                                Bot_Title[PosX - 1, PosY] = Instantiate(Title, new Vector3(3.6f - (PosX + 2 - 1) * 3.9667f, 4.66f, 24.85f - (PosY) * 3.9667f - 2f), Quaternion.identity, MassTitle.transform);
                                Bot_Title[PosX - 1, PosY].GetComponent<Renderer>().material = Senter_No;
                                Bot_field[PosX - 1, PosY] = 3;
                            }
                        }
                        if (PosX + 1 >= 0 && PosX + 1 < 10)
                        {
                            if (Bot_Title[PosX + 1, PosY] == null)
                            {
                                Bot_Title[PosX + 1, PosY] = Instantiate(Title, new Vector3(3.6f - (PosX + 2 + 1) * 3.9667f, 4.66f, 24.85f - (PosY) * 3.9667f - 2f), Quaternion.identity, MassTitle.transform);
                                Bot_Title[PosX + 1, PosY].GetComponent<Renderer>().material = Senter_No;
                                Bot_field[PosX + 1, PosY] = 3;
                            }
                        }
                    }



                    //
                    // после каждой итерации цикла мы уменьшаем set и увеличиваем y и проверяем если там кораблик
                    //
                    set--;
                    PosY++;
                }

            }
            if (Rotate == "Right")
            {
                int set = 2;
                int PosX = Point.x - 1;
                int PosY = Point.y;

                while (set > 0)
                {
                    //
                    //если клетка на PosX PosY равна  2 то увиличиваем set
                    //
                    if (PosX + 1 < 10)
                        if (Bot_field[PosX + 1, PosY] == 2) set++;


                    //для началмы должны проверить если клетка не самая нижняя то должны поставить 3 нижних красных тайтла
                    if (PosX >= 0 && PosX < 10)
                    {
                        if (Bot_Title[PosX, PosY] == null)
                        {
                            Bot_Title[PosX, PosY] = Instantiate(Title, new Vector3(3.6f - (PosX + 2) * 3.9667f, 4.66f, 24.85f - (PosY) * 3.9667f - 2f), Quaternion.identity, MassTitle.transform);
                            Bot_Title[PosX, PosY].GetComponent<Renderer>().material = Senter_No;
                            Bot_field[PosX, PosY] = 3;
                        }


                        if (PosY - 1 >= 0 && PosY - 1 < 10)
                        {
                            if (Bot_Title[PosX, PosY - 1] == null)
                            {
                                Bot_Title[PosX, PosY - 1] = Instantiate(Title, new Vector3(3.6f - (PosX + 2) * 3.9667f, 4.66f, 24.85f - (PosY - 1) * 3.9667f - 2f), Quaternion.identity, MassTitle.transform);
                                Bot_Title[PosX, PosY - 1].GetComponent<Renderer>().material = Senter_No;
                                Bot_field[PosX, PosY - 1] = 3;
                            }
                        }
                        if (PosY + 1 >= 0 && PosY + 1 < 10)
                        {
                            if (Bot_Title[PosX, PosY + 1] == null)
                            {
                                Bot_Title[PosX, PosY + 1] = Instantiate(Title, new Vector3(3.6f - (PosX + 2) * 3.9667f, 4.66f, 24.85f - (PosY + 1) * 3.9667f - 2f), Quaternion.identity, MassTitle.transform);
                                Bot_Title[PosX, PosY + 1].GetComponent<Renderer>().material = Senter_No;
                                Bot_field[PosX, PosY + 1] = 3;
                            }
                        }
                    }



                    //
                    // после каждой итерации цикла мы уменьшаем set и увеличиваем y и проверяем если там кораблик
                    //

                    set--;
                    PosX++;
                }

            }
        }
        else
        {




        }
    }




    private void Update()
    {
        if (ButtonManager.Scene == "Battel" && ButtonManager.UI == "Global" && Motion == "My") // если сейчас сцена боя и не на паузе и мой ход тогда проверяем находится ли курсор на поле аппонента
        {
            //print("1");
            Vector2Int Point = GameControl.GetComponent<RayDirection>().GetPointBOT();

            if (Point.x == -1 || Point.y == -1) // если находимя на поле аппонента
            {
                //print("4");
                Cursor.GetComponent<CursorRotate>().Enable = false;
                Cursor.transform.position = new Vector3(0, -1, 0);
                Title.transform.position = new Vector3(0, 0, 0);
            }
            else
            {
                if (Bot_field[Point.x, Point.y] < 2)
                {
                    //print("2");
                    Cursor.GetComponent<CursorRotate>().Enable = true;
                    Cursor.transform.position = new Vector3(3.6f - (Point.x + 2) * 3.9667f, Cursor.transform.position.y, 25f - (Point.y) * 3.9667f - 2f);
                    Title.transform.position = new Vector3(3.6f - (Point.x + 2) * 3.9667f, 4.66f, 24.85f - (Point.y) * 3.9667f - 2f);
                    Title.GetComponent<Renderer>().material = Perimeter;
                }
                else
                {
                    Cursor.GetComponent<CursorRotate>().Enable = false;
                    Cursor.transform.position = new Vector3(0, -1, 0);
                    Title.transform.position = new Vector3(0, 0, 0);

                }

            }

        }



        
        if (Input.GetMouseButtonDown(0) && ButtonManager.Scene == "Battel") // если мы нажали на клавишу то
        {
            //
            // если это наш год и клетка не занятая
            //

          Vector2Int Point = GameControl.GetComponent<RayDirection>().GetPointBOT();
          if (Point.x < 10 && Point.x >= 0 && Point.y < 10 && Point.y >= 0)
            if (Bot_field[Point.x, Point.y] < 2 )
            {
                //
                //если на данной клетке есть кораблик то тогда ставим крестик и тайтл красим в зеленый цвет иначе крестик и красный цвет
                //
                if (Bot_field[Point.x, Point.y] == 1)// если кораблик стоит
                {

                    Bot_field[Point.x, Point.y] = 2;
                    Bot_Title[Point.x, Point.y] = Instantiate(Title, new Vector3(3.6f - (Point.x + 2) * 3.9667f, 4.66f, 24.85f - (Point.y) * 3.9667f - 2f), Quaternion.identity, MassTitle.transform);
                    Bot_Title[Point.x, Point.y].GetComponent<Renderer>().material = Senter_Yes;
                    Motion = "My";
                    Number_Xod++;

                    if (CheakShepFullDEad(new Vector2Int(Point.x, Point.y), "Bot")) //если мы попали в кораблик и он полностью уничтожен то мы должны по периметру закрастить красными клетками
                    {
                        //
                        //  найдем самую правую и нижнию клетку кораблика
                        //
                        print(Point);
                        LDPoint lDPoint = SetLDPoint(new Vector2Int(Point.x, Point.y), "Bot");
                        print(lDPoint.Point);
                        print(lDPoint.Rotate);
                        SetTitlePerimetr(lDPoint.Point, "Bot", lDPoint.Rotate);
                        print("Уничтожен");


                    }
                    else
                        print("подбит");

                    if (MyEmpty > 0)
                        Bot_Xode();

                    ResetValues();


                    //
                    //если мы попали по кораблику то это могла бы быть последняя клетка с кораблем значит надо проверить не выйграли ли мы
                    //



                }
                if (Bot_field[Point.x, Point.y] == 0)//если клетка пустая
                {
                    Bot_field[Point.x, Point.y] = 3;
                    Bot_Title[Point.x, Point.y] = Instantiate(Title, new Vector3(3.6f - (Point.x + 2) * 3.9667f, 4.66f, 24.85f - (Point.y) * 3.9667f - 2f), Quaternion.identity, MassTitle.transform);
                    Bot_Title[Point.x, Point.y].GetComponent<Renderer>().material = Senter_No;
                    Motion = "Bot";
                    Number_Xod++;

                    //
                    //ход апонента
                    //
                    if (MyEmpty > 0)
                        Bot_Xode();

                    ResetValues();


                }


            }
            //print(Point);

        }



        if (BotEmptyShip == 0 && ButtonManager.Scene == "Battel" && ButtonManager.UI == "Global")
        {
            SetWin(true);
        }
        if (MyEmptyShip == 0 && ButtonManager.Scene == "Battel" && ButtonManager.UI == "Global")
        {
            SetWin(false);
        }

    }

    private void SetWin(bool win)
    {
        if (win)
        {
            WinText.GetComponent<Text>().enabled = true;

            DefeatText.GetComponent<Text>().enabled = false;

            SoundControler.Play("Win");
            

            ButtonManager.SetWinMenu();
            print("Победа");



            
        }
        else
        {
            WinText.GetComponent<Text>().enabled = false;


            DefeatText.GetComponent<Text>().enabled = true;

            SoundControler.Play("Defeat");
           

            ButtonManager.SetWinMenu();
            print("Поражение");



        }



    }

}
