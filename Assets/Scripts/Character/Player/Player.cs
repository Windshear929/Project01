using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    Controls inputActions;
    PhysicsCheck physicsCheck;

    Vector2 inputDirection;
    Vector2 faceDirection;
    Vector2 lastInputValue;
    Vector2 currentInputValue;

    [SerializeField] float moveSpeed = 10;
    [SerializeField] float jumpStr = 18;

    bool isMove;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        physicsCheck = GetComponent<PhysicsCheck>();
        inputActions = new Controls();
    }

    void OnEnable()
    {
        inputActions.Gameplay.Jump.performed += Jump;
        inputActions.Enable();
    }

    void OnDisable()
    {
        inputActions.Gameplay.Jump.performed -= Jump;
        inputActions.Disable();
    }

    void Start()
    {
        lastInputValue = new Vector2(1, 0);
    }

    void Update()
    {
        inputDirection.x = inputActions.Gameplay.Move.ReadValue<float>();

        animator.SetBool("isGround", physicsCheck.isGround);
        animator.SetFloat("velocityY", rb.velocity.y);

        AboutFace();
        TrunAround();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        animator.SetBool("isMove", isMove);
        if (inputDirection.x != 0)
        {
            rb.velocity = new Vector2(inputDirection.x * moveSpeed, rb.velocity.y);
            isMove = true;
        }
        if (inputDirection.x == 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            isMove = false;
        }
    }

    void AboutFace()
    {
        faceDirection = inputDirection.normalized;
        if (faceDirection.x > 0)
        {
            transform.localScale = new Vector2(faceDirection.x , 1);
        }
        
        if (faceDirection.x < 0)
        {
            transform.localScale = new Vector2(faceDirection.x , 1);
        }
    }

    void TrunAround()
    {
        currentInputValue = inputDirection;
        
        if (currentInputValue.x != 0)
        {
            if (lastInputValue.x != currentInputValue.x && lastInputValue.x != 0)
            {
                animator.SetTrigger("turn");
                lastInputValue.x = currentInputValue.x;
            }
        }
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (physicsCheck.isGround)
        {
            rb.AddForce(Vector2.up * jumpStr, ForceMode2D.Impulse);
        }
    }
}
