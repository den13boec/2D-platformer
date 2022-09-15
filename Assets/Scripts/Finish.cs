using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource _finishSound;

    [SerializeField] private AudioClip finishSoundEffect;
    private void Start()
    {
        _finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != "Player") return;
        //_finishSound.Play();
        SoundManager.Instance.PlaySound(finishSoundEffect);
        
        // Give player 0 velocity, take away movement and set animation to idle
        collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        collision.gameObject.GetComponent<PlayerMovement>().enabled = false;
        collision.gameObject.GetComponent<Animator>().SetInteger("state", 0);
        
        // Secure player's score
        ScoreManager.Instance.SecureLevelScore();
        ScoreManager.Instance.UpdateMaxGameScore();
        
        // Wait 2 seconds then execute function
        Invoke(nameof(CompleteLevel),2f);
    }

    private void CompleteLevel()
    {
        // Load next level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
