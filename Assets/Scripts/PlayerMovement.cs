using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Header in Unity
    [Header("Player powers")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    
    private Rigidbody2D _rBodyPlayer;
    private Animator _anim;
    private float _dirX;
    private SpriteRenderer _spritePlayer;
    private BoxCollider2D _collPlayer;
    [SerializeField] private LayerMask jumpableGround;

    [SerializeField] private AudioClip jumpSoundEffect;
    
    // States of player
    private enum MovementState
    {
        idle,
        running,
        jumping,
        falling
    };
    // Updated state of player
    private MovementState _stateOfPlayer;
    
    private void Start()
    {
        _rBodyPlayer = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _spritePlayer = GetComponent<SpriteRenderer>();
        _collPlayer = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        _dirX = Input.GetAxisRaw("Horizontal");
        _rBodyPlayer.velocity = new Vector2(_dirX * moveSpeed, _rBodyPlayer.velocity.y);
        switch (_dirX)
        {
            // Flip player when moving left-right
            case > 0.01f:
                // Right
                transform.localScale=Vector3.one;
                break;
            case < -0.01f:
                // Left
                transform.localScale = new Vector3(-1, 1, 1);
                break;
        }
        // Check if input is JUMP
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            _rBodyPlayer.velocity = new Vector2(_rBodyPlayer.velocity.x,jumpForce);
            //jumpSoundEffect.Play();
            SoundManager.Instance.PlaySound(jumpSoundEffect);
        }
        // Updating animation of the player
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        // First check Y velocity
        switch (_rBodyPlayer.velocity.y)
        {
            // Switching between player's animations
            case > 0.01f:
                _stateOfPlayer = MovementState.jumping;
                break;
            case < -0.01f:
                _stateOfPlayer = MovementState.falling;
                break;
            default:
                switch (_dirX)
                {
                    // Switching between player's animations
                    case > 0.01f:
                    case < -0.01f:
                        _stateOfPlayer = MovementState.running;
                        break;
                    default:
                        _stateOfPlayer = MovementState.idle;
                        break;
                }
                break;
        }
        // Upgrading state of player
        _anim.SetInteger("state", (int)_stateOfPlayer);
    }

    private bool IsGrounded()
    {
        // Check is player grounded. If yes then he can jump
        return Physics2D.BoxCast(_collPlayer.bounds.center, _collPlayer.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
