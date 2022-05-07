using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[ExecuteInEditMode]
public class AddSprite : MonoBehaviour
{
    public Sprite sprButtonOnMenuDialog;
    public Sprite sprLock;
    public Sprite sprLockBg;


    public bool a;

    private void Update()
    {
        if (a)
        {
            foreach (Transform item in transform)
            {
                item.GetComponent<Image>().sprite = sprButtonOnMenuDialog;
                item.GetChild(0).GetChild(0).GetComponent<Image>().sprite = sprLock;
                item.GetChild(0).GetComponent<Image>().sprite = sprLockBg;
            }
            //for (int i = 0; i < transform.childCount; i++)
            //{
            //    transform.GetChild(0).GetComponent<Image>().sprite = sprButtonOnMenuDialog;
            //    transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>().sprite = sprLock;
            //    transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = sprLockBg;

            //    print(transform.GetChild(i).gameObject.name);
            //}
            a = false;
        }
    }

}
