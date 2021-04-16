using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseManager : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler, IPointerDownHandler
{
    public GameObject AudioManager;
    public GameObject ActiveText;

    public Material Pasific;

    public Material Active;

    public void OnPointerExit(PointerEventData eventData)
    {
        //print("+");
        transform.localScale = new Vector3(1f, 1f, 1f);

        ActiveText.GetComponent<Text>().material = Pasific;
        
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        //print("+");
        transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
        ActiveText.GetComponent<Text>().material = Active;
        AudioManager.GetComponent<SoundControler>().Play("Select");
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        AudioManager.GetComponent<SoundControler>().Play("Click");
    }
}
