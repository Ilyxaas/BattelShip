using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource AudioSource;
    //
    //   Для настроек звука.
    //
    public Slider Voise_Value_Slider;
    public Text Voise_Value_Text;
    //
    //  Для настроек графики
    //
    public Slider  FPS_Value_Slider;
    public Text  FPS_Value_Text;


    //ограничение FPS
    public bool Lock_FPS;

    //отключен ли звук
    public bool Sound_Enabled;


    //громкость звука если не выключен
    public float Sound_Value;

    //ограничение FPS если не заблокирован
    public float FPS_Limit;
    
    void Start()
    {
        Application.targetFrameRate = 45;
        Lock_FPS = true; //    ограничения на фпс нет

        Sound_Enabled = true;//  звуки включены
        AudioSource.mute = !Sound_Enabled;       


        Sound_Value = 1f;
        AudioSource.volume = Sound_Value;
        Voise_Value_Text.text = (Sound_Value * 10 / 10).ToString();

        FPS_Limit = FPS_Value_Slider.value;
        FPS_Value_Text.text = FPS_Limit.ToString();
        Set_Lock_fps();
    }
    public void Set_Lock_fps()
    {
        if (Lock_FPS == false)
        {
            Application.targetFrameRate = -1;
            Lock_FPS = true;
        }
        else
        {
            Application.targetFrameRate = (int)FPS_Limit;
            
            Lock_FPS = false;
        }
    }
    public void Set_Sound_Enabled()
    {
        if (Sound_Enabled == false)
            Sound_Enabled = true;
        else
            Sound_Enabled = false;

        AudioSource.mute = !Sound_Enabled;
    }
    public void Set_Voise_Value()
    {
        Sound_Value = (11 - Voise_Value_Slider.value) / 10;
        AudioSource.volume = Sound_Value;
        Voise_Value_Text.text = Sound_Value.ToString();

    }
    public void Set_FPS_Value()
    {
        FPS_Limit = FPS_Value_Slider.value;
        Set_Lock_fps();
       
        FPS_Value_Text.text = FPS_Limit.ToString();

    }
    
}
