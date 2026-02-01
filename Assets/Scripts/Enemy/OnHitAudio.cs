using UnityEngine;

public class OnHitAudio : MonoBehaviour
{
    private AudioSource _audioSource;
    public AudioClip clip;
    

    private void Start()
    {
        _audioSource = GetComponentInParent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("CreamProjectile") || other.transform.CompareTag("FruitableProjectile"))
        {
            _audioSource.clip = clip;
            if (!_audioSource.isPlaying)
            {
                _audioSource.Play();
            }
            Destroy(other.gameObject);
        }
    }
}
