using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public Canvas MainCanvas; //главный экран Menu

    //
    // Меню переходящие из главного меню
    //

    public Canvas ExitMenuCanvas;
    public Canvas SettingsMenuCanvas;
    public Canvas SelectLevelCanvas;

    //
    // Меню переходящие из меню настроек
    //

    public Canvas SoundSettingCanvas;
    public Canvas InputSettingCanvas;
    public Canvas GraficSettingCanvas;
    public Canvas AboutUsSettingCanvas;

    //
    //  Меню переходнящее из меню играть
    //
    public Canvas CreateNewGameCanvas; // канвас для растановки кораблей в поле

    public Canvas GameCanvas; // основной канвас для сражения

    public Canvas PauseGameCanvas; // меню паузы
    //
    public Canvas PauseExitCanvas;//  выход из меню паузы

    public Canvas CanvasExitOrBackGame; //подтверждение или возвращение обратно в меню
    //
    //
    public Canvas CanvasWinMenu;

    public string Scene;  // меню или сцена с двигающиеся водой или сцена раставления кораблей;

    public string UI; //активный UI
                      //
    public string Previous; // предыдущая меню используется для меню настроект 
    // Start is called before the first frame update
    void Start()
    {
        Previous = null;
        Scene = "Menu";        
        SetMainMenu();
    }
   
    private void OffEnable()
    {
        CanvasWinMenu.enabled = false;
        CanvasExitOrBackGame.enabled = false;
        PauseExitCanvas.enabled = false;
        PauseGameCanvas.enabled = false;
        GameCanvas.enabled = false;
        CreateNewGameCanvas.enabled = false;
        SelectLevelCanvas.enabled = false;
        MainCanvas.enabled = false;
        ExitMenuCanvas.enabled = false;
        SettingsMenuCanvas.enabled = false;
        SoundSettingCanvas.enabled = false;
        InputSettingCanvas.enabled = false;
        GraficSettingCanvas.enabled = false;
        AboutUsSettingCanvas.enabled = false;

    }

    public void Setprevious(string previous)
    {
        Previous = previous;
    }

    public void SetMainMenu()//включить главный экран
    {
        OffEnable();
        if (Previous == "Pause")
        {
            OffEnable();
            GameCanvas.enabled = true;
            UI = "Global";
            Scene = "Battel";
        }
        else
        {
            MainCanvas.enabled = true;
            UI = "MainMenu";
            Scene = "Menu";
        }
    }
    public void SetExitMenu()//включить экран подтверждения выхода
    {
        OffEnable();
        ExitMenuCanvas.enabled = true;        
        UI = "ExitMenu";
        Scene = "Menu";
    }
    public void Leave()//выход
    {
        Application.Quit();
    }
    public void SetSettingsMenu()//включить экран выбора настроек
    {
        OffEnable();        
        SettingsMenuCanvas.enabled = true;
        UI = "SettingsMenu";
        Scene = "Menu";
    }
    public void SetSoundSettingsMenu()//включить экран выбора настроек
    {
        OffEnable();
        SoundSettingCanvas.enabled = true;
        UI = "SoundSettingsMenu";
        Scene = "Menu";
    }
    public void SetGraficSettingsMenu()//включить экран выбора настроек
    {
        OffEnable();
        GraficSettingCanvas.enabled = true;
        UI = "GraficSettingsMenu";
        Scene = "Menu";
    }
    public void SetInputSettingsMenu()//включить экран выбора настроек
    {
        OffEnable();
        InputSettingCanvas.enabled = true;
        UI = "InputSettingsMenu";
        Scene = "Menu";
    }
    public void SetAboutUsMenu()//включить экран выбора настроек
    {
        OffEnable();
        AboutUsSettingCanvas.enabled = true;
        UI = "AbouUsSettingMenu";
        Scene = "Menu";
    }
    public void SetSelectedLevelMenu()
    {
        OffEnable();
        SelectLevelCanvas.enabled = true;
        UI = "SelectedLevelMenu";
        Scene = "Menu";
    }
    public void SetCreateNewGameMenu()
    {
        OffEnable();
        CreateNewGameCanvas.enabled = true;
        UI = "SelectedLevelMenu";
        Scene = "SetShip";
    }
    public void SetBattelGame()
    {
        OffEnable();
        GameCanvas.enabled = true;
        UI = "Global";
        Scene = "Battel";
    }
    public void SetPauseGame()
    {
        OffEnable();
        PauseGameCanvas.enabled = true;
        UI = "Pause";
        Scene = "Battel";
    }
    public void SetPauseExitGame()
    {
        OffEnable();
        PauseExitCanvas.enabled = true;
        UI = "PauseExit";
        Scene = "Battel";
    }
    public void SetExitOrBackGame()
    {
        OffEnable();
        CanvasExitOrBackGame.enabled = true;
        UI = "ExitOrBackGame";
        Scene = "Battel";

    }
    public void SetWinMenu()
    {
        OffEnable();
        CanvasWinMenu.enabled = true;
        UI = "WinMenu";
        Scene = "Battel";
    }

}
