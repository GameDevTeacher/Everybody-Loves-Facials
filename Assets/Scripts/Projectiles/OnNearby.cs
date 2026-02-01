using UnityEngine;

public class OnNearby : MonoBehaviour
{
    private AudioSource _audioSource;
    public AudioClip clip;

    private void Start()
    {
        _audioSource = GetComponentInParent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            _audioSource.PlayOneShot(clip);
        }
    }
}
