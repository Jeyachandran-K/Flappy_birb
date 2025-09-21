using UnityEngine;
using UnityEngine.InputSystem;

public class Birb : MonoBehaviour
{
    public static Birb Instance { get; private set; }

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
                }
                }break;

             case State.gaming:
                if (Keyboard.current.spaceKey.isPressed)
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
}
