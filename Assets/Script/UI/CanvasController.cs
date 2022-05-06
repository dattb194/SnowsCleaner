using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public static CanvasController instance;

    public LevelDialog levelUI;
    public MenuLevelDialog menuLevel;

    public UnityEngine.UI.Text txtLevelPlayingDisplay;


    public UnityEngine.UI.Text txtDebugScreen;


    private void Awake()
    {
        instance = this;
        txtDebugScreen.text = Screen.width + "/" + Screen.height;
    }

    public void ShowLevelDisplay(int _level)
    {
        levelUI.SetData(_level);
    }

    public void HideMenuLevel()
    {
        menuLevel.gameObject.SetActive(false);
    }

    public void SetTxtLevelPlayingDisplay(int _lv)
    {
        txtLevelPlayingDisplay.text = "LEVEL " + _lv;
    }
}
