using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipRandomizer : MonoBehaviour
{
    public List<AudioClip> clips = new List<AudioClip>();

    public AudioClip activeClip;

    private AudioSource aS;
    // Start is called before the first frame update
    void Start()
    {
        aS = GetComponent<AudioSource>();
        activeClip = clips[Random.Range(0, clips.Count)];
        aS.clip = activeClip;
        aS.Play();
        aS.time = Random.Range(0, activeClip.length);
    }
}
