using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonOnMenuDialog : MonoBehaviour
{
    
    public GameObject _lock;
    public GameObject _select;
    public Text _name;

    [SerializeField]
    public int level;

    public enum StateCard { locked, unLock, selecting, unSelect}

    public StateCard stateCard = StateCard.locked;



    private void OnEnable()
    {
        if (LeveManager.instance.LevelUnLock < level)
            Lock();
        else
        {
            Unlock();
            if (LeveManager.instance.LevelNow == level)
            {
                Select();
            }
            else
                UnSelect();
        }
    }
    private void Start()
    {
        GPController.instance.onSelectLevelFromList += OnPlayerSelectLevel;
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }
    public void Unlock()
    {
        stateCard = StateCard.unLock;

        _lock.SetActive(false);
        _select.SetActive(false);
        _name.gameObject.SetActive(true);
        GetComponent<Button>().interactable = true;
    }
    public void Lock()
    {
        stateCard = StateCard.locked;

        _lock.SetActive(true);
        _select.SetActive(false);
        _name.gameObject.SetActive(false);
        GetComponent<Button>().interactable = false;
    }
    public void Select()
    {
        stateCard = StateCard.selecting;

        _lock.SetActive(false);
        _select.SetActive(true);
        _name.gameObject.SetActive(true);
        GetComponent<Button>().interactable = false;
    }
    public void UnSelect()
    {
        stateCard = StateCard.unSelect;

        _lock.SetActive(false);
        _select.SetActive(false);
        _name.gameObject.SetActive(true);
        GetComponent<Button>().interactable = true;
    }

    public void OnPlayerSelectLevel(int result)
    {
        if (result != level)
            UnSelect();
    }

    public void OnButtonClick()
    {
        Select();
        LeveManager.instance.SelectLevel(level);
        GPController.instance.OnSelectLevel(level);
        GPController.instance.onSelectLevelFromList?.Invoke(level);

        CanvasController.instance.HideMenuLevel();
    }

}
