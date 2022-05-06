using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FxCameraWithScreen : MonoBehaviour
{
    public float ratio = 7.9f / 1920;

    public float a; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        a = Screen.width;
        GetComponent<Camera>().fieldOfView = ratio * Screen.width;
    }
}
