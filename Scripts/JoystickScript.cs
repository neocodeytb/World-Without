using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private RectTransform joystickBackground;
    private RectTransform joystickHandle;
    private Vector2 inputVector;

    private void Start()
    {
        RawImage image = GetComponent<RawImage>();
        Color color = image.color;
        color.a = Mathf.Clamp01(0.5f);
        image.color = color;

        joystickBackground = GetComponent<RectTransform>();
        joystickHandle = transform.GetChild(0).GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBackground, eventData.position, eventData.pressEventCamera, out position);

        position.x = (position.x / joystickBackground.sizeDelta.x);
        position.y = (position.y / joystickBackground.sizeDelta.y);

        inputVector = new Vector2(position.x * 2, position.y * 2);
        inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

        joystickHandle.anchoredPosition = new Vector2(inputVector.x * (joystickBackground.sizeDelta.x / 2), inputVector.y * (joystickBackground.sizeDelta.y / 2));
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        joystickHandle.anchoredPosition = Vector2.zero;
    }

    public float Horizontal()
    {
        return inputVector.x;
    }

    public float Vertical()
    {
        return inputVector.y;
    }

    public Vector2 Diagonal()
    {
        float x = Horizontal();
        float y = Vertical();

        if (Mathf.Abs(x) > 0.5f && Mathf.Abs(y) > 0.5f)
        {
            return new Vector2(x, y).normalized;
        }
        else
        {
            return Vector2.zero;
        }
    }

    public Vector2 TopLeft()
    {
        if (Horizontal() < 0 && Vertical() > 0)
        {
            return new Vector2(-1, 1).normalized;
        }
        return Vector2.zero;
    }

    public Vector2 TopRight()
    {
        if (Horizontal() > 0 && Vertical() > 0)
        {
            return new Vector2(1, 1).normalized;
        }
        return Vector2.zero;
    }

    public Vector2 BottomLeft()
    {
        if (Horizontal() < 0 && Vertical() < 0)
        {
            return new Vector2(-1, -1).normalized;
        }
        return Vector2.zero;
    }

    public Vector2 BottomRight()
    {
        if (Horizontal() > 0 && Vertical() < 0)
        {
            return new Vector2(1, -1).normalized;
        }
        return Vector2.zero;
    }
}
