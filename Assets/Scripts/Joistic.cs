using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joistic : MonoBehaviour
{

    public GameObject joystic;
    public GameObject joysticBG;
    public Vector2 joysticVec;
    private Vector2 joysticTouchPos;
    private Vector2 joysticOriginalPos;
    private float joystickRadius;

    // Start is called before the first frame update
    void Start()
    {
        joysticOriginalPos = joysticBG.transform.position;
        joystickRadius = joysticBG.GetComponent<RectTransform>().sizeDelta.y / 4;

    }

    public void PointerDown()
    {
        joystic.transform.position = Input.mousePosition;
        joysticBG.transform.position = Input.mousePosition;
        joysticTouchPos = Input.mousePosition;


    }

    public void Drag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector2 dragPos = pointerEventData.position;
        joysticVec = (dragPos - joysticTouchPos).normalized;

        float joyistickDist = Vector2.Distance(dragPos, joysticTouchPos);

        if (joyistickDist < joystickRadius)
        {
            joystic.transform.position = joyistickDist * joysticVec + joysticTouchPos;
            var l = joystic.transform.position;
        }
        else
        {
            joystic.transform.position = joystickRadius * joysticVec + joysticTouchPos;
        }

    }

    public void PointerUp()
    {
        joysticVec = Vector2.zero;
        joystic.transform.position = joysticOriginalPos;
        joysticBG.transform.position = joysticOriginalPos;
    }

}
