using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D _playerRigidBody;
    public float _playerVelocity;
    private Vector2 _playerDirection;
    private Animator _playerAnimator;
    private static PlayerController instance;

    // Start is called before the first frame update
    void Start()
    {
        _playerRigidBody = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (vertical < 0)
        {
            _playerDirection = Vector2.down;
            _playerAnimator.SetInteger("Movimento", 1); // Andando para baixo
        }
        else if (vertical > 0)
        {
            _playerDirection = Vector2.up;
            _playerAnimator.SetInteger("Movimento", 2); // Andando para cima
        }
        else if (horizontal < 0)
        {
            _playerDirection = Vector2.left;
            _playerAnimator.SetInteger("Movimento", 3); // Andando para esquerda
        }
        else if (horizontal > 0)
        {
            _playerDirection = Vector2.right;
            _playerAnimator.SetInteger("Movimento", 4); // Andando para direita
        }
        else
        {
            _playerDirection = Vector2.zero;
            _playerAnimator.SetInteger("Movimento", 0); // Idle
        }
    }

    void FixedUpdate()
    {
        _playerRigidBody.MovePosition(_playerRigidBody.position + _playerDirection * _playerVelocity * Time.fixedDeltaTime);
    }

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
