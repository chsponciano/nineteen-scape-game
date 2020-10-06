using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public const float playerLimit = 3f;
    public const float playerFrameMovement = 0.1f;

    public float speed;
    public float horizontalSpeed;
    public float jumpHeight;
    public float gravity;
    public float rayRadius;
    public LayerMask layer;
    public Animator anime;

    private CharacterController controller;
    private float jumpVelocity;
    private bool isMovingLeft;
    private bool isMovingRight;
    private bool isDead = false;
    private GameController gameController;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        gameController = FindObjectOfType<GameController>();
    }

    void Update()
    {
        Vector3 direction = Vector3.forward * speed;   
        
        if(controller.isGrounded) 
        {
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                jumpVelocity = jumpHeight;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < playerLimit && !isMovingRight)
            {
                isMovingRight = true;
                StartCoroutine(RightMove());
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > -playerLimit && !isMovingLeft)
            {
                isMovingLeft = true;
                StartCoroutine(LeftMove());
            }
        }
        else
        {
            jumpVelocity -= gravity;
        }

        OnCollision();
        direction.y = jumpVelocity;
        controller.Move(direction * Time.deltaTime);
    }

    IEnumerator LeftMove()
    {
        for(float i = 0; i < 10; i += playerFrameMovement)
        {
            controller.Move(Vector3.left * Time.deltaTime * horizontalSpeed);
            yield return null;
        }

        isMovingLeft = false;
    }

    IEnumerator RightMove()
    {
        for(float i = 0; i < 10; i += playerFrameMovement)
        {
            controller.Move(Vector3.right * Time.deltaTime * horizontalSpeed);
            yield return null;
        }

        isMovingRight = false;
    }

    void OnCollision()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayRadius, layer) && !isDead)
        {
            anime.SetTrigger("die");
            speed = 0;
            jumpHeight = 0;
            horizontalSpeed = 0;
            Invoke("AnimeGameOver", 3f);
            isDead = true;
        }
    }

    void AnimeGameOver()
    {
        gameController.CallGameOver();
    }
}
