using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDialog : MonoBehaviour
{
    public UnityEngine.UI.Text txt;
    public void SetData(int _lv)
    {
        txt.text = "" + _lv;
        gameObject.SetActive(true);
        Invoke("Hide", 3);
    }
    void Hide()
    {
        txt.text = "";
        gameObject.SetActive(false);
        GPController.instance.m_player.SetCanMove(true);
        PlayerAudio.instance.OnPlayingBgPlay();
    }
}
