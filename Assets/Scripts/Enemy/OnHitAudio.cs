using System;
using Enemy;
using UnityEngine;

public class OnHitAudio : MonoBehaviour
{
    private AudioSource _audioSource;
    public AudioClip clip;
    

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other)
    {
        /*if (other.("Cream"))
        {
            _audioSource.PlayOneShot(clip);
        }*/
    }
}
