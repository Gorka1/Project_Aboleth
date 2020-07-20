using System.Collections;
using System.Collections.Generic;
using Unity.Audio;
using UnityEngine;

public class RadioControl : MonoBehaviour
{
    public AudioClip[] audioArray;
    public List<AudioClip> audioList = new List<AudioClip>();
    private AudioSource source;
    private Transform radioDisk;

    void refillList()
    {
        foreach (AudioClip a in audioArray)
        {
            audioList.Add(a);
        }
    }

    AudioClip getNewSong()
    {
        if (audioList.Count == 0)
        {
            refillList();
        }
        int tempNum = Random.Range(0, audioList.Count);
        AudioClip temp = audioList[tempNum];
        audioList.RemoveAt(tempNum);
        return temp;
    }

    void Awake()
    {
        source = gameObject.GetComponent<AudioSource>();
        radioDisk = gameObject.transform.parent.GetChild(1);
        refillList();
        getNewSong();
    }

    private void Update()
    {
        if (source.isPlaying == false)
        {
            AudioClip temp = getNewSong();
            source.clip = temp;
            source.Play();
        }
        if (source.isPlaying)
        {
            radioDisk.RotateAround(transform.position, transform.up, Time.deltaTime * 90f);
        }
    }
}
