using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instance;
    [SerializeField] private AudioSource soundFXObject;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // everything above this is all that's needed to make a script a singleton

    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.pitch *= Random.Range(0.95f, 1.02f);
        audioSource.Play();
        float cliplength = audioSource.clip.length;
        print(cliplength);
        Destroy(audioSource, cliplength);
    }
}
