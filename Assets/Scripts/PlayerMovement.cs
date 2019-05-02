using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Animator animator;
    private Rigidbody2D rigidbody;

    [Header("Variables:")]
    public float MOVEMENT_BASE_SPEED = 1.0f;
    [Space]
    [Header("Inputs:")]
    public Vector2 movementDirection;
    public float movementSpeed;
    [Space]
    [Header("Checks:")]
    public bool frozen = false;

    // Start is called before the first frame update
    void Start() {

        animator = gameObject.GetComponent<Animator>();
        rigidbody = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update() {

        ProcessInputs();
        Move();
        Animate();
        
    }

    void ProcessInputs()
    {
        if(!frozen)
        {
            movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
            movementDirection.Normalize();
        } else
        {
            movementDirection = Vector2.down;
            movementSpeed = 0;
        }
        
    }

    void Move()
    {
        rigidbody.velocity = movementDirection * movementSpeed * MOVEMENT_BASE_SPEED;
    }

    void Animate()
    {
        if(movementDirection != Vector2.zero)
        {
            animator.SetFloat("Horizontal", movementDirection.x);
            animator.SetFloat("Vertical", movementDirection.y);
        }
        animator.SetFloat("Speed", movementSpeed);


    }
}
