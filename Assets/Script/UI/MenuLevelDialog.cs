using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuLevelDialog : MonoBehaviour
{
    public List<GameObject> pages;

    public Button btnNext;
    public Button btnPre;

    public int pageNow = 0;
    private void OnEnable()
    {
        OnChangePageNow();
    }
    public void OnButtonClick(bool isNext)
    {
        pageNow += isNext ? 1 : -1;
        OnChangePageNow();

    }
    void OnChangePageNow()
    {
        foreach (var item in pages)
        {
            item.SetActive(false);
        }
        pages[pageNow].SetActive(true);

        btnNext.interactable = pageNow < 4;
        btnPre.interactable = pageNow > 0;
    }
}
