using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static bool isPressed;

    public void OnclickDown()
    {
        isPressed = true;
    }

    public void OnclickUp()
    {
        isPressed = false;
    }
    public void OnPointerDown()
    {
        isPressed = true;    
    }

    public void OnPointerUp()
    {
        isPressed = false;
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        OnPointerDown();
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        OnPointerUp();
    }
}
