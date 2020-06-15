using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonSelector : MonoBehaviour
{
    public void Selected() 
    {
        EventSystem.current.SetSelectedGameObject(gameObject);
    }
    public void NotSelected() 
    {
        EventSystem.current.SetSelectedGameObject(null);
    }
}
