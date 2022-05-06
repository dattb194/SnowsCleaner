using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using UnityEngine.Events;

public delegate void OnSelectLevelFromList(int _levelSelect);
public class GPController : MonoBehaviour
{
    public static GPController instance;

    public PlayerController m_player;

    public bool isPausingGame = false;

    public OnSelectLevelFromList onSelectLevelFromList;

    public Transform rootLevelSpawn;

    public GameObject flower;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            FindObjectOfType<CheckNextLevel>().ForceNextLevel();
        }
    }
    private void Awake()
    {
        instance = this;

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    private IEnumerator Start()
    {
        yield return null;
        CanvasController.instance.ShowLevelDisplay(LeveManager.instance.LevelNow + 1);
        yield return new WaitForSeconds(.5f);
        OnSelectLevel(LeveManager.instance.LevelNow);
    }

    public void OnSelectLevel(int _lv)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        LeveManager.instance.SelectLevel(_lv);

        OnSpawnLevel(_lv);

    }
    public void OnNextLevel(int _lvNow)
    {
        LeveManager.instance.NextLevel(_lvNow);

        OnSpawnLevel(_lvNow + 1);

    }
    public void ReloadLevel()
    {
        OnSelectLevel(LeveManager.instance.levelNow);
    }
    void OnSpawnLevel(int newLv)
    {
        m_player.SetCanMove(false);
        
        CanvasController.instance.SetTxtLevelPlayingDisplay(newLv+1);
        CanvasController.instance.ShowLevelDisplay(newLv+1);
        foreach (var item in rootLevelSpawn.GetComponentsInChildren<Transform>())
        {
            if (item != rootLevelSpawn)
                Destroy(item.gameObject);
        }
        GameObject _lv = Instantiate(transform.GetChild(newLv).gameObject, rootLevelSpawn);
        _lv.SetActive(true);
    }
}
