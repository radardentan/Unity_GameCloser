using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitor
{
    //(todo)オーバーロードを用意しよう

    //シーン名指定で、既存のサブシーン全てを破棄してシーンを読み込む
    public static void SceneTransition (string sceneName) 
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            var scene = SceneManager.GetSceneAt(i);
            if (scene.isSubScene) SceneManager.UnloadSceneAsync(scene);
        }
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
    }
}
