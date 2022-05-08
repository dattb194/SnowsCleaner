using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    public float maxSize = 0.1332408f;

    
    private IEnumerator Start()
    {
        yield return null;
        transform.localScale = Vector3.zero;

        //transform.GetChild((int)Random.Range(0, transform.childCount - 1)).gameObject.SetActive(true);

        //float _rd = Random.Range(maxSize/2,maxSize);
        //while (transform.localScale.x < _rd)
        //{
        //    transform.localScale += new Vector3(.002f, .002f, .002f);
        //    yield return null;
        //}
    }
}
