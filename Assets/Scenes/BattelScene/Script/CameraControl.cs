using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject World;
    public Camera[] cameras;    
    public GameObject GameControler;
    InputManager Manager;
    ButtonManager ButtonManager;
    //
    //
    //
    private Camera ActiveCamera;
    // Start is called before the first frame update









    void Start()
    {
        Manager = GameControler.GetComponent<InputManager>();
        ButtonManager = GameControler.GetComponent<ButtonManager>();

        for (int i = 0; i < cameras.Length; i++) //выключаем все камеры
        {
            
            cameras[i].enabled = false;
            cameras[i].tag = "Untagged";
            if (cameras[i].name == "Menu Camera")
                ActiveCamera = cameras[i];

        }
        ActiveCamera.enabled = true;
        ActiveCamera.tag = "MainCamera";
    }

    public void SetShipCamera()
    {
        for (int i = 0; i < cameras.Length; i++) //выключаем все камеры
        {

            cameras[i].enabled = false;
            cameras[i].tag = "Untagged";
            if (cameras[i].name == "MyViewAbove Camera")
                ActiveCamera = cameras[i];

        }
        ActiveCamera.enabled = true;
        ActiveCamera.tag = "MainCamera";

    }
    public void SetMenuCamera()
    {
        for (int i = 0; i < cameras.Length; i++) //выключаем все камеры
        {

            cameras[i].enabled = false;
            cameras[i].tag = "Untagged";
            if (cameras[i].name == "Menu Camera")
                ActiveCamera = cameras[i];

        }
        ActiveCamera.enabled = true;
        ActiveCamera.tag = "MainCamera";

    }

    public void SetCamera(string CameraName)
    {
        for (int i = 0; i < cameras.Length; i++) //выключаем все камеры
        {

            cameras[i].enabled = false;
            cameras[i].tag = "Untagged";
            if (cameras[i].name == CameraName)
                ActiveCamera = cameras[i];

        }
        ActiveCamera.enabled = true;
        ActiveCamera.tag = "MainCamera";

    }
    void Update()
    {
        if (ButtonManager.Scene == "Battel")
        {
            if (Input.GetKeyDown(Manager.Key_BotCorner_Camera))
            {
                for (int i = 0; i < cameras.Length; i++) //выключаем все камеры
                {
                    cameras[i].tag = "Untagged";
                    cameras[i].enabled = false;
                    if (cameras[i].name == "BotCorner Camera")
                        ActiveCamera = cameras[i];
                }
                ActiveCamera.enabled = true;
                ActiveCamera.tag = "MainCamera";
            }
            if (Input.GetKeyDown(Manager.Key_Globalc_Camere))
            {
                for (int i = 0; i < cameras.Length; i++) //выключаем все камеры
                {
                    cameras[i].tag = "Untagged";
                    cameras[i].enabled = false;
                    if (cameras[i].name == "General Camera")
                        ActiveCamera = cameras[i];
                }
                ActiveCamera.enabled = true;
                ActiveCamera.tag = "MainCamera";
            }
            if (Input.GetKeyDown(Manager.key_MyCorner_Camera))
            {
                for (int i = 0; i < cameras.Length; i++) //выключаем все камеры
                {
                    cameras[i].tag = "Untagged";
                    cameras[i].enabled = false;
                    if (cameras[i].name == "MyCorner Camera")
                        ActiveCamera = cameras[i];
                }
                ActiveCamera.enabled = true;
                ActiveCamera.tag = "MainCamera";
            }
            if (Input.GetKeyDown(Manager.Key_BotViewAbove_Camera))
            {
                for (int i = 0; i < cameras.Length; i++) //выключаем все камеры
                {
                    cameras[i].tag = "Untagged";
                    cameras[i].enabled = false;
                    if (cameras[i].name == "BotViewAbove Camera")
                        ActiveCamera = cameras[i];
                }
                ActiveCamera.enabled = true;
                ActiveCamera.tag = "MainCamera";
            }
            if (Input.GetKeyDown(Manager.Key_MyViewAbove_Camera))
            {
                for (int i = 0; i < cameras.Length; i++) //выключаем все камеры
                {
                    cameras[i].tag = "Untagged";
                    cameras[i].enabled = false;
                    if (cameras[i].name == "MyViewAbove Camera")
                        ActiveCamera = cameras[i];
                }
                ActiveCamera.enabled = true;
                ActiveCamera.tag = "MainCamera";
            }
        }
        else
        {
            if (ButtonManager.Scene == "SetShip")
            {
                if (Input.GetKeyDown(Manager.key_MyCorner_Camera))
                {
                    for (int i = 0; i < cameras.Length; i++) //выключаем все камеры
                    {
                        cameras[i].tag = "Untagged";
                        cameras[i].enabled = false;
                        if (cameras[i].name == "MyCorner Camera")
                            ActiveCamera = cameras[i];
                    }
                    ActiveCamera.enabled = true;
                    ActiveCamera.tag = "MainCamera";
                }


                if (Input.GetKeyDown(Manager.Key_MyViewAbove_Camera))
                {
                    for (int i = 0; i < cameras.Length; i++) //выключаем все камеры
                    {
                        cameras[i].tag = "Untagged";
                        cameras[i].enabled = false;
                        if (cameras[i].name == "MyViewAbove Camera")
                            ActiveCamera = cameras[i];
                    }
                    ActiveCamera.enabled = true;


                }
            }
        }

    }
}
