using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MessengerBeforeGameQuit : MonoBehaviour
{
    const string shownText = "本当にゲームを終了しますか?";
    public static void NotifyBeforeGameQuit() 
    {
        ObjectPauser.Pause();
        YesOrNoDialog.ShowDialog(shownText, QuitGame, Canceled);
    }
    public static void QuitGame() 
    {
        if (Application.isEditor) EditorApplication.isPlaying = false;
        else Application.Quit();
    }
    public static void Canceled() 
    {
        YesOrNoDialog.HideDialog();
        ObjectPauser.Resume();
    }
}
