using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PropertyMeter : MonoBehaviour
{
    public bool isPressed;
    public Image eMeter;
    

    private void Update()
    {
        MyInput();
    }
    private void MyInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
            isPressed = true;
        if (Input.GetKeyUp(KeyCode.E))
            isPressed = false;
    }

    private void UIFill()
    {
        if (isPressed == true)
        {
            eMeter.fillAmount = 0.1f;
        }
        if (isPressed == false)
        {
            eMeter.fillAmount = -0.1f;
        }
    }

    
    public void OnUpdateSelected(BaseEventData data)
    {
      if (isPressed)
        {
            UIFill();

        }
    }
}
