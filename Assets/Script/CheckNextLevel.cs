using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckNextLevel : MonoBehaviour
{
    //public GameObject LevelNext;

    //public int index;

    public bool levelEnd = false;

    private void Start()
    {
        StartCoroutine(CheckGrass());
    }
    IEnumerator CheckGrass()
    {
        yield return new WaitForSeconds(1f);
        while (!levelEnd)
        {
            if (!FindObjectOfType<Grass>())
            {
                levelEnd = true;
            }
            yield return null;
        }
        for (int i = 0; i < transform.GetChild(1).childCount; i++)
        {
            GameObject _fl = Instantiate(GPController.instance.flower, transform.GetChild(1).GetChild(i));
            _fl.transform.localPosition = Vector3.zero;
            //Destroy(_fl,2);
        }


        yield return new WaitForSeconds(3f);
        ForceNextLevel();
    }

    public void ForceNextLevel()
    {
        //GPController.instance.OnNextLevel(index);
        GPController.instance.OnLevelEnded();
    }
}
