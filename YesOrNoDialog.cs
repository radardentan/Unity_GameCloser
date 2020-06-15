using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class YesOrNoDialog : MonoBehaviour
{
    static Canvas canvas;
    static Text text;

    public static Action submittedAction = null;
    public static Action canceledAction = null;


    void Awake()
    {
        canvas = transform.root.gameObject.GetComponentInChildren<Canvas>();
        canvas.enabled = false;
        text = canvas.GetComponentInChildren<Text>();
    
    }
    void OnEnable()
    {
        if (gameObject.name == "No") EventSystem.current.firstSelectedGameObject = gameObject;

    }
    void OnDisable()
    {
        EventSystem.current.firstSelectedGameObject = null;
    }

    public static void ShowDialog(string notification, Action submitted, Action canceled)
    {

        submittedAction = submitted;
        canceledAction = canceled;
        
        canvas.enabled = true;
        SetNotification(notification);
    }
    public static void HideDialog() 
    {
        submittedAction = null;
        canceledAction = null;
        canvas.enabled = false;
    }
    public static void SetNotification(string notification) 
    {
        text.text = notification;
    }

    public void Selected() 
    {
        EventSystem.current.SetSelectedGameObject(gameObject);
    }
    public void NotSelected() 
    {
        EventSystem.current.SetSelectedGameObject(null);
    }
    public void Submitted() 
    {
        if (submittedAction == null) return;
        submittedAction();
    }
    public void Canceled() 
    {
        if (canceledAction == null) return;
        canceledAction();
    }
}