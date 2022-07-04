using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLevel2 : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClip;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        AudioClip clipMus = RandomClip();
        audioSource.clip = clipMus;
        audioSource.Play();
    }

    private AudioClip RandomClip()
    {
        return audioClip[Random.Range(0, audioClip.Length)];
    }
}
