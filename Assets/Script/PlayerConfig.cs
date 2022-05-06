using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerControl", menuName = "ScriptableObjects/Player config", order = 1)]

[System.Serializable]
public class PlayerConfig : ScriptableObject
{
    public float speed = .5f;

    public float speedLerp = 1;
}
