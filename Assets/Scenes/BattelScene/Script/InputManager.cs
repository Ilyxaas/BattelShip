using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    //
    //Основной объект
    //
    public GameObject GameControl;

    //
    // Переключение камер (id клавиш)
    //


    public KeyCode Key_Globalc_Camere;
    public KeyCode key_MyCorner_Camera;
    public KeyCode Key_BotCorner_Camera;
    public KeyCode Key_MyViewAbove_Camera;
    public KeyCode Key_BotViewAbove_Camera;

    public KeyCode Key_Rotate_Left;
    public KeyCode Key_Rotate_Right;

    //
    // Тексты из меню  Input Setting
    //
    public Text Text_Globalc;
    public Text Text_MyCorner;
    public Text Text_BotCorner;
    public Text Text_MyViewAbove;
    public Text Text_BotViewAbove;

    public Text Text_Rotate_Left;
    public Text Text_Rotate_Right;

    public string Active;
    //
    // приватные объекты от Game Control;
    //

    ButtonManager buttonManager;
    private void Start()
    {
        
           
        Active = null;
        buttonManager = GameControl.GetComponent<ButtonManager>();
        //значения по умолчанию для камер

        if (Key_Globalc_Camere == KeyCode.None)
            Key_Globalc_Camere = KeyCode.F1;
        if (key_MyCorner_Camera == KeyCode.None)
            key_MyCorner_Camera = KeyCode.F2;
        if (Key_BotCorner_Camera == KeyCode.None)
            Key_BotCorner_Camera = KeyCode.F3;
        if (Key_MyViewAbove_Camera == KeyCode.None)
            Key_MyViewAbove_Camera = KeyCode.F4;
        if (Key_BotViewAbove_Camera == KeyCode.None)
            Key_BotViewAbove_Camera = KeyCode.F5;


        if (Key_Rotate_Left == KeyCode.None)
            Key_Rotate_Left = KeyCode.Q;
        if (Key_Rotate_Right == KeyCode.None)
            Key_Rotate_Right = KeyCode.E;
        //
        //Введем эти значения в текстовые поля
        //
        ResetInputText();
    }



    private void Update()
    {

        if (Input.anyKeyDown && Active != null && buttonManager.UI == "InputSettingsMenu" && buttonManager.Scene == "Menu")
        {
            print(Input.inputString);
            if (Input.GetKeyDown(KeyCode.Q))
                SetKeyCode(KeyCode.Q);
            else
                if (Input.GetKeyDown(KeyCode.W))
                SetKeyCode(KeyCode.W);
            else
                if (Input.GetKeyDown(KeyCode.S))
                SetKeyCode(KeyCode.S);
            else
                if (Input.GetKeyDown(KeyCode.R))
                SetKeyCode(KeyCode.R);
            else
                if (Input.GetKeyDown(KeyCode.T))
                SetKeyCode(KeyCode.T);
            else
                if (Input.GetKeyDown(KeyCode.Y))
                SetKeyCode(KeyCode.Y);
            else
                if (Input.GetKeyDown(KeyCode.U))
                SetKeyCode(KeyCode.U);
            else
                if (Input.GetKeyDown(KeyCode.I))
                SetKeyCode(KeyCode.I);
            else
                if (Input.GetKeyDown(KeyCode.O))
                SetKeyCode(KeyCode.O);
            else
                if (Input.GetKeyDown(KeyCode.P))
                SetKeyCode(KeyCode.P);
            else
                if (Input.GetKeyDown(KeyCode.A))
                SetKeyCode(KeyCode.A);
            else
                if (Input.GetKeyDown(KeyCode.S))
                SetKeyCode(KeyCode.S);
            else
                if (Input.GetKeyDown(KeyCode.D))
                SetKeyCode(KeyCode.D);
            else
                if (Input.GetKeyDown(KeyCode.F))
                SetKeyCode(KeyCode.F);
            else
                if (Input.GetKeyDown(KeyCode.G))
                SetKeyCode(KeyCode.G);
            else
                if (Input.GetKeyDown(KeyCode.H))
                SetKeyCode(KeyCode.H);
            else
                if (Input.GetKeyDown(KeyCode.J))
                SetKeyCode(KeyCode.J);
            else
                if (Input.GetKeyDown(KeyCode.K))
                SetKeyCode(KeyCode.K);
            else
                if (Input.GetKeyDown(KeyCode.L))
                SetKeyCode(KeyCode.L);
            else
                if (Input.GetKeyDown(KeyCode.Z))
                SetKeyCode(KeyCode.Z);
            else
                if (Input.GetKeyDown(KeyCode.Z))
                SetKeyCode(KeyCode.Z);
            else
                if (Input.GetKeyDown(KeyCode.X))
                SetKeyCode(KeyCode.X);
            else
                if (Input.GetKeyDown(KeyCode.C))
                SetKeyCode(KeyCode.C);
            else
                if (Input.GetKeyDown(KeyCode.V))
                SetKeyCode(KeyCode.V);
            else
                if (Input.GetKeyDown(KeyCode.B))
                SetKeyCode(KeyCode.B);
            else
                if (Input.GetKeyDown(KeyCode.N))
                SetKeyCode(KeyCode.N);
            else
                if (Input.GetKeyDown(KeyCode.M))
                SetKeyCode(KeyCode.M);
            else
                if (Input.GetKeyDown(KeyCode.F1))
                SetKeyCode(KeyCode.F1);
            else
                if (Input.GetKeyDown(KeyCode.F2))
                SetKeyCode(KeyCode.F2);
            else
                if (Input.GetKeyDown(KeyCode.F3))
                SetKeyCode(KeyCode.F3);
            else
                if (Input.GetKeyDown(KeyCode.F4))
                SetKeyCode(KeyCode.F4);
            else
                if (Input.GetKeyDown(KeyCode.F5))
                SetKeyCode(KeyCode.F5);
            else
                if (Input.GetKeyDown(KeyCode.F6))
                SetKeyCode(KeyCode.F6);
            else
                if (Input.GetKeyDown(KeyCode.F7))
                SetKeyCode(KeyCode.F7);
            else
                if (Input.GetKeyDown(KeyCode.F8))
                SetKeyCode(KeyCode.F8);
            else
                if (Input.GetKeyDown(KeyCode.F9))
                SetKeyCode(KeyCode.F9);
            else
                if (Input.GetKeyDown(KeyCode.F10))
                SetKeyCode(KeyCode.F10);
            else
                if (Input.GetKeyDown(KeyCode.F11))
                SetKeyCode(KeyCode.F11);
            else
                if (Input.GetKeyDown(KeyCode.F12))
                SetKeyCode(KeyCode.F12);
        }
    }

    public void InputTextSelected(string Act)
    {
        
            Active = Act;
        
    }



    void SetKeyCode(KeyCode keyCode)
    {
        if (Checking_same_values(keyCode))
            {
            if (Active == "General")
            {

                Key_Globalc_Camere = keyCode;
                Text_Globalc.text = keyCode.ToString();
                Active = null;
                return;
            }
            if (Active == "MyViewAbove")
            {
                Key_MyViewAbove_Camera = keyCode;
                Text_MyViewAbove.text = keyCode.ToString();
                Active = null;
                return;
            }
            if (Active == "BotViewAbove")
            {
                Key_BotViewAbove_Camera = keyCode;
                Text_BotViewAbove.text = keyCode.ToString();
                Active = null;
                return;
            }
            if (Active == "MyCorner")
            {
                key_MyCorner_Camera = keyCode;
                Text_MyCorner.text = keyCode.ToString();
                Active = null;
                return;
            }
            if (Active == "BotCorner")
            {
                Key_BotCorner_Camera = keyCode;
                Text_BotCorner.text = keyCode.ToString();
                Active = null;
                return;
            }
            if (Active == "RotateRight")
            {
                Key_Rotate_Right = keyCode;
                Text_Rotate_Right.text = keyCode.ToString();
                Active = null;
                return;
            }
            if (Active == "RotateLeft")
            {
                Key_Rotate_Left = keyCode;
                Text_Rotate_Left.text = keyCode.ToString();
                Active = null;
                return;
            }
        }
    }

    //
    // функция для установки стартовых значений в меню  Input
    //
    private void ResetInputText()
    {
        Text_Globalc.text = Key_Globalc_Camere.ToString();

        Text_MyViewAbove.text = Key_MyViewAbove_Camera.ToString();

        Text_BotViewAbove.text = Key_BotViewAbove_Camera.ToString();

        Text_MyCorner.text = key_MyCorner_Camera.ToString();

        Text_BotCorner.text = key_MyCorner_Camera.ToString();

        Text_Rotate_Right.text = Key_Rotate_Right.ToString();

        Text_Rotate_Left.text = Key_Rotate_Left.ToString();
    }



    private bool Checking_same_values(KeyCode keyCode)
    {
        bool Cheak = false;
        int sum = 0;
        if (Key_Globalc_Camere == keyCode) sum++;
        if (Key_MyViewAbove_Camera == keyCode) sum++;
        if (Key_BotViewAbove_Camera == keyCode) sum++;
        if (key_MyCorner_Camera == keyCode) sum++;
        if (Key_BotCorner_Camera == keyCode) sum++;
        if (Key_Rotate_Right == keyCode) sum++;
        if (Key_Rotate_Left == keyCode) sum++;
        print(sum);
        if (sum == 0)
            Cheak = true;
        
        return Cheak;
    }

}
