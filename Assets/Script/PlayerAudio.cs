using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public static PlayerAudio instance;

    public AudioSource audioMove;
    public AudioSource audioIdle;
    public AudioSource cutIce;

    public AudioSource playingBg;
    private void Awake()
    {
        instance = this;
    }
    public void OnMoving()
    {
        audioMove.Play();
        //audioIdle.Stop();
    }
    public void OnIdle()
    {
        audioMove.Stop();
        //audioIdle.Play();
    }
    public void OnCantMove()
    {
        audioMove.Stop();
        //audioIdle.Stop();
        playingBg.Stop();
    }
    public void OnPlayingBgPlay()
    {
        if(!playingBg.isPlaying)
            playingBg.Play();
    }
    public void OnCutIce()
    {
        GameObject _a = Instantiate(cutIce.gameObject);
        _a.GetComponent<AudioSource>().Play();
        Destroy(_a, .5f);
    }
}
