using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Using singleton patern
    // access from outside scripts, but modify only inside this one
    public static SoundManager Instance { get; private set; }
    private AudioSource _source;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
        // Keep this object even when we go to new scene or reseting this one 
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        // Destroy duplicate gameobject
        else if (Instance != null && Instance!=this) Destroy(this.gameObject);
    }

    public void PlaySound(AudioClip sound)
    {
        _source.PlayOneShot(sound);
    }
}
