using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Birb : MonoBehaviour
{
    public static Birb Instance { get; private set; }

    public event Action OnGamingState;
    public event Action OnHittingPipe;
    public event Action OnCrossingPipe;
    public event Action OnGameOver;

    public enum State
    {
        waitingToStart,
        gaming,
        gameOver,
    }

    private State state = State.waitingToStart;

    [SerializeField] private float speedMultiplier;
    private Rigidbody2D birbRigidbody2D;
    private const float GRAVITY_SCALE = 1f;
    private bool isBirbAlive= true;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        birbRigidbody2D = GetComponent<Rigidbody2D>();
        birbRigidbody2D.gravityScale = 0f;
    }
    private void Update()
    {

        switch (state)
        {
            case State.waitingToStart:
                { if (Keyboard.current.spaceKey.isPressed)
                {
                    birbRigidbody2D.gravityScale = GRAVITY_SCALE;
                    state = State.gaming;
                        OnGamingState?.Invoke();
                }
                }break;

             case State.gaming:
                if (Keyboard.current.spaceKey.isPressed && isBirbAlive)
                {
                    birbRigidbody2D.AddForce(transform.up * Time.deltaTime * speedMultiplier);
                }
                break;

            case State.gameOver:
                break;

             default:
                break;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if(collision2D.gameObject.TryGetComponent<TopPipe>(out TopPipe topPipe) || collision2D.gameObject.TryGetComponent<BottomPipe>(out BottomPipe bottomPipe))
        {
            isBirbAlive = false;
            state = State.gameOver;
            OnGameOver?.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<MiddlePipe>(out MiddlePipe middlePipe)){
            OnCrossingPipe?.Invoke();
        }
    }
}
