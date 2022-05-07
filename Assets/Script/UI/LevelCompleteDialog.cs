using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteDialog : MonoBehaviour
{
    public Transform [] star= new Transform[3];
    public UnityEngine.UI.Text txtLv;
    public void OnSetData(int _lv, int _rate)
    {
        for (int i = 0; i < 3; i++)
        {
            star[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < _rate; i++)
        {
            star[i].gameObject.SetActive(true);
        }
        txtLv.text = "Level " + (_lv+1);

        gameObject.SetActive(true);
    }
}
