using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    // References
    private Animator _anim;
    private Rigidbody2D _rb;
    [SerializeField] private AudioClip deathSoundEffect;
    private void Start()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if collided object is trap
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        SoundManager.Instance.PlaySound(deathSoundEffect);
        //deathSoundEffect.Play();
        
        // Set trigger to death and change rigidbody type to static,
        // So no physics applied to it and it cant move around
        _rb.bodyType = RigidbodyType2D.Static;
        _anim.SetTrigger("death");
        GetComponent<PlayerMovement>().enabled = false;
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GetComponent<PlayerMovement>().enabled = true;
    }
}
