using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[ExecuteInEditMode]
public class FixLayoutgroup : MonoBehaviour
{

    public GridLayoutGroup grid;

    public float spaceX, spaceY, sizeX, sizeY;
   
    // Update is called once per frame
    void Update()
    {
        grid.spacing = new Vector2(spaceX*Screen.width,spaceY*Screen.height);

        grid.cellSize = new Vector2(sizeX* Screen.width, sizeX* Screen.width);
    }
}
