using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosPlayer : MonoBehaviour
{
    private IEnumerator Start()
    {
        yield return null;
        GPController.instance.m_player.transform.position = transform.position;
        GPController.instance.m_player.transform.GetChild(0).localEulerAngles = new Vector3(0, 180, 0);
    }
    private void OnEnable()
    {
        GetComponent<Renderer>().enabled = false;
    }
}
