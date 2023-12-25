using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private GameObject bgmAudio;

    private AudioSource bgmAudioSource;

    // Start is called before the first frame update
    private void Start()
    {
        bgmAudioSource = bgmAudio.GetComponent<AudioSource>();

        PlayBgm();
    }

    private void PlayBgm()
    {
        bgmAudioSource.Play();   
    }
}
