using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMusic : MonoBehaviour
{
    public AudioClip[] sounds;

    public AudioSource source;

    private bool mute;
   
    void Start()
    {
        AudioClip clip = sounds[UnityEngine.Random.Range(0, sounds.Length)];
        source.PlayOneShot(clip);
    }

   
   

    public void stop()
    {
        mute = !mute;
        source.mute = mute;
    }
}
