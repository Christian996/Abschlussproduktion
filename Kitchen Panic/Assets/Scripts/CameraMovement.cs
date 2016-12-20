using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class CameraMovement : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler 
{
    // HIntergrundgrafik des Joysticks
    private Image bgImg;
    // Grafik für den Joystick selbst
    private Image joystckImg;

    private void Awake()
    {
        bgImg = GetComponent<Image>();
        joystckImg = GetComponentInChildren<Image>();
    }
    // Included from IDragHandler
    public virtual void OnDrag(PointerEventData ped)
    {
        Debug.Log("Drag");
    }

    // Included from IPointerDownHandler
    public virtual void OnPointerDown(PointerEventData ped)
    {
        Debug.Log("Down");
    }

    // Included from IPointerUpHandler
    public virtual void OnPointerUp(PointerEventData ped)
    {
        Debug.Log("Up");
    }
}
