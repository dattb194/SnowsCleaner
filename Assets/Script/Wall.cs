using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public List<GameObject> objs;

    private void OnEnable()
    {
        StartCoroutine(WaitLoadModel());
    }
    IEnumerator WaitLoadModel()
    {
        yield return new WaitForSeconds(.1f);

        if(Random.Range(0,100)<50)
            transform.GetChild((int)Random.Range(0, transform.childCount-1)).gameObject.SetActive(true);
    }
}
