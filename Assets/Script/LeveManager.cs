using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class LeveManager : MonoBehaviour
{
    public static LeveManager instance;

    public int levelUnLock;
    public int levelNow;

    public int LevelUnLock
    {
        set =>  PlayerPrefs.SetInt("LevelUnLock", value);
        get => PlayerPrefs.GetInt("LevelUnLock");
    }
    public int LevelNow
    {
        set => PlayerPrefs.SetInt("LevelNow", value);
        get => PlayerPrefs.GetInt("LevelNow");
    }

    public void NextLevel(int _levelNow)
    {
        if (LevelUnLock <= _levelNow)
        {
            LevelUnLock += 1;
        }

        LevelNow = _levelNow + 1;
    }
    public void SelectLevel(int _level)
    {
        LevelNow = _level;
    }

    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        levelNow = LevelNow;
        levelUnLock = LevelUnLock;
    }
}
