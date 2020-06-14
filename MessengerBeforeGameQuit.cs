using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MessengerBeforeGameQuit : MonoBehaviour
{
    static Canvas target;

     void Awake()
    {
        target = transform.root.gameObject.GetComponent<Canvas>();
        target.enabled = false;
    }


    public static void NotifyBeforeGameQuit() 
    {
        ObjectPauser.Pause();
        target.enabled = true;
    }
    public void QuitGame() 
    {
        if (Application.isEditor) EditorApplication.isPlaying = false;
        else Application.Quit();
    }
    public void Canceled() 
    {
        GetComponentInParent<Canvas>().enabled = false;
        ObjectPauser.Resume();
    }
}
