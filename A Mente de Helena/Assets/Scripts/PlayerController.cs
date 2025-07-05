using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D _playerRigidBody;
    public float _playerVelocity;
    private Vector2 _playerDirection;

    // Start is called before the first frame update
    void Start()
    {
        _playerRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _playerDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
    
    void FixedUpdate()
    {
        _playerRigidBody.MovePosition(_playerRigidBody.position + _playerDirection * _playerVelocity * Time.fixedDeltaTime);
    }
}
