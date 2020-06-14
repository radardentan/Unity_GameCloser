using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ForcedAppShutDown 
{
    //ゲームの強制終了(E+S+C同時押し)
    public static void ForceQuitApplication()
    {
        if (Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.C))
        {
            if (Application.isEditor) EditorApplication.isPlaying = false;
            else Application.Quit();
        }
    }
}
