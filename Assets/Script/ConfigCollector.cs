using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ConfigCollector : MonoBehaviour
{
    public static ConfigCollector instance;

    public PlayerConfig playerConfig;

    private void Awake()
    {
        instance = this;
    }
}
