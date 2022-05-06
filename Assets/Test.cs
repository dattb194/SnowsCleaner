using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Test : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnEnable()
    {
        //transform.GetChild(0).gameObject.SetActive(true);

        //if (transform.GetChild(0).GetComponent<MeshFilter>())
        //    DestroyImmediate(transform.GetChild(0).GetComponent<MeshFilter>());

        //if (transform.GetChild(0).GetComponent<Renderer>())
        //    DestroyImmediate(transform.GetChild(0).GetComponent<Renderer>());
        //if (transform.GetChild(0).GetComponent<Collider>())
        //    DestroyImmediate(transform.GetChild(0).GetComponent<Collider>());
        //if (transform.GetChild(0).GetComponent<Rigidbody>())
        //    DestroyImmediate(transform.GetChild(0).GetComponent<Rigidbody>());
        //if (transform.GetChild(0).GetComponent<CheckWall>())
        //    DestroyImmediate(transform.GetChild(0).GetComponent<CheckWall>());

        //if (transform.GetChild(0).GetComponent<MeshFilter>() == null)
        {
            transform.GetChild(0).gameObject.AddComponent<MeshFilter>();
            transform.GetChild(0).GetComponent<MeshFilter>().mesh = player.GetComponent<MeshFilter>().mesh;

            transform.GetChild(0).gameObject.AddComponent<MeshRenderer>();
            transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = player.GetComponent<MeshRenderer>().material;
        }

    }
}
