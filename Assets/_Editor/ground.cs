using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[ExecuteInEditMode]
public class ground : MonoBehaviour
{
    public Transform root_grass;

    public GameObject grass;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(.1f);
        SpawnGrass();
    }
    private void SpawnGrass()
    {
        
            GameObject g = Instantiate(grass, root_grass);
            g.transform.position = transform.position;
            g.name = "grass";
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "wall")
        {
            Destroy(gameObject);
        }
    }
}
