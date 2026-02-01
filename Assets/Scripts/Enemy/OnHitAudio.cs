using UnityEngine;

public class OnHitAudio : MonoBehaviour
{
    private AudioSource _audioSource;
    public AudioClip clip;
    

    private void Start()
    {
        _audioSource = GetComponentInParent<AudioSource>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Cream"))
        {
            _audioSource.PlayOneShot(clip);
        }
    }
}
