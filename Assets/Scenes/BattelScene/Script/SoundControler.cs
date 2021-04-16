using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControler : MonoBehaviour
{
    public GameObject Voice;
    public GameObject VoiceEffect;
    public GameObject VoiceFone;

    public AudioClip Fone;
    public AudioClip Click;
    public AudioClip Select;
    public AudioClip Win;
    public AudioClip Defeat;
    public AudioClip MenuFone;

    AudioSource AudioClipEffect => VoiceEffect.GetComponent<AudioSource>();
    AudioSource AudioClip => Voice.GetComponent<AudioSource>();
    AudioSource AudioFone => VoiceFone.GetComponent<AudioSource>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void Play(string type)
    {
        if (type == "Click")
        {
            AudioClip.clip = Click;
            AudioClip.Play();
        }
        if (type == "Select")
        {
            AudioClip.clip = Select;
            AudioClip.Play();
        }
        if (type == "Win")
        {
           AudioClipEffect.clip = Win;
           AudioClipEffect.Play();

        }
        if (type == "Defeat")
        {
            AudioClipEffect.clip = Defeat;
            AudioClipEffect.Play();
        }
        if (type == "Fon")
        {
            AudioFone.clip = Fone;
            AudioFone.Play();
        }
        if (type == "MenuFon")
        {
            AudioFone.clip = MenuFone;
            AudioFone.Play();

        }


    }
}
