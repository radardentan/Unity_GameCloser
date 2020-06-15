using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToTitleScene
{
    public static void BackToTitle() 
    {
        SceneTransitor.SceneTransition("Title");
    }
}