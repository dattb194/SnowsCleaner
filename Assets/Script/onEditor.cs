using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class onEditor : MonoBehaviour
{
    public GameObject canvas;

    public bool isEditing = false;

    public int levelSet;

    public bool restartLevel;

    public bool setlever;

    void Edit()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<ButtonOnMenuDialog>()._name.text =""+ (i + 1 + levelSet);
            transform.GetChild(i).GetComponent<ButtonOnMenuDialog>().level = i + levelSet;
        }
        isEditing = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isEditing)
        {
            Edit();
        }

        if (restartLevel)
        {
            PlayerPrefs.DeleteAll();
            restartLevel = false;
        }
        if (setlever)
        {
            PlayerPrefs.SetInt("LevelNow", levelSet);
            setlever = false;
        }
    }
}
