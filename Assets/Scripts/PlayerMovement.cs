using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D myRigidBody;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider;
    ScoreKeeper scoreKeeper;
    SceneLoader sceneLoader;
    public float runSpeed = 5f;
    public float jumpSpeed = 10f;
    bool isGrounded = false;
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    void Update()
    {
        Run();
        FlipSprite();
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Platform"))) isGrounded = true;
        else isGrounded = false;
        Win();
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    void OnJump(InputValue value)
    {
        if (!isGrounded) return;
        if (value.isPressed)
        {
            myRigidBody.velocity += new Vector2(0f, jumpSpeed);
            myAnimator.SetTrigger("isJump");
        }
    }
    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;
        if (isGrounded) myAnimator.SetFloat("xVelocity", Mathf.Abs(myRigidBody.velocity.x));

    }
    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
        }
    }
    void Win()
    {
        if (scoreKeeper.GetScore() >= 30)
        {
            sceneLoader.LoadEndGame();
        }
    }
}