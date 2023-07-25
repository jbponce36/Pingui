using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravityScale = 15.0f;
    public static float globalGravity = -9.81f;
    private Vector3 gravity;
    private Vector3 movement;
    public float jumpAmountUp = 30f;
    public float jumpAmountDown = 15f;
    public float jumpAmountX = 20f;
    public float jumpAmountCollided = 20f;
    public float movementSpeed = 3.85f;
    private Rigidbody rb;
    public bool isOnGround = false;
    public float floor = 0f;
    public float tile = 0f;
    public LayerMask obstaclesLayermask;
    public bool isJumpingUp = false;
    public bool isJumpingLeft = false;
    public bool isJumpingRight = false;
    public bool isJumpingDown = false;
    public bool enemyCollided = false;
    public bool isDead = false;
    public Animator anim;
    public ParticleSystem explosion;
    public MeshRenderer rend;
 
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        rend = transform.GetChild(0).GetComponent<MeshRenderer>();
        gravity = globalGravity * gravityScale * Vector3.up;
    }

    void Update()
    {        
        if (isDead)
            return;

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && isOnGround)
        {
            if (canJumpTo(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z + 1)))
            {
                isJumpingUp = true;
                SoundManager.PlayJumpSound();
                return;
            }
        } 
        else if (Input.GetKeyDown(KeyCode.DownArrow) && isOnGround)
        {
            if (canJumpTo(new Vector3(transform.position.x, transform.position.y - 1, transform.position.z - 1)))
            {
                isJumpingDown = true;
                SoundManager.PlayJumpSound();
                return;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && isOnGround) 
        {
            if (canJumpTo(new Vector3(transform.position.x - 1, transform.position.y, transform.position.z)))
            {
                isJumpingLeft = true;
                SoundManager.PlayJumpSound();
                return;
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && isOnGround) 
        {
            if (canJumpTo(new Vector3(transform.position.x + 1, transform.position.y, transform.position.z)))
            {
                isJumpingRight = true;
                SoundManager.PlayJumpSound();
                return;
            }
        }
    }

    void FixedUpdate()
    {
        //Adds gravity
        rb.AddForce(gravity, ForceMode.Acceleration);
        gravity = globalGravity * gravityScale * Vector3.up;

        if (isJumpingUp && isOnGround)
        {
            isOnGround = false;
            floor++;
            movement = Vector3.forward;
            rb.AddForce( new Vector3(0, jumpAmountUp, 0), ForceMode.Impulse);
            anim.SetTrigger("jump");
            isJumpingUp = false;
        }
        else if (isJumpingDown && isOnGround)
        {
            isOnGround = false;
            floor--;
            movement = Vector3.back;
            rb.AddForce( new Vector3(0, jumpAmountDown, 0), ForceMode.Impulse);
            anim.SetTrigger("jump");
            isJumpingDown = false;
        }
        else if (isJumpingLeft && isOnGround) 
        {
            isOnGround = false;
            tile--;
            movement = Vector3.left;
            rb.AddForce( new Vector3(0, jumpAmountX, 0), ForceMode.Impulse);
            anim.SetTrigger("jump");
            isJumpingLeft = false;
        }
        else if (isJumpingRight && isOnGround) 
        {
            isOnGround = false;
            tile++;
            movement = Vector3.right;
            rb.AddForce( new Vector3(0, jumpAmountX, 0), ForceMode.Impulse);
            anim.SetTrigger("jump");
            isJumpingRight = false;
        }

        if (!isOnGround && !enemyCollided) 
        {
            transform.LookAt(transform.position + movement);
            if ((movement == Vector3.forward && transform.position.z < floor) ||
                (movement == Vector3.back && transform.position.z > floor) ||
                (movement == Vector3.left && transform.position.x > tile) ||
                (movement == Vector3.right && transform.position.x < tile))
            {
                rb.MovePosition(transform.position + movement * Time.deltaTime * movementSpeed);
            }
        }
    }

    bool canJumpTo(Vector3 position)
    {
        bool canJump = true;

        Collider[] hitColliders = Physics.OverlapSphere(position, 0.5f, obstaclesLayermask);
        if (hitColliders.Length >= 1)
        {
            if (hitColliders[0].gameObject.CompareTag("Chest") && PlayerStats.HasKeys())
            {
                canJump = true;
            }
            else 
            {
                canJump = false;
                SoundManager.PlayCantJumpSound();
            }
        }

        return canJump;
    }

    void OnCollisionEnter(Collision collision) 
    {
		if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            rb.velocity = Vector3.zero;

            if (!enemyCollided && (transform.position.x != tile || transform.position.z != floor))
            {
                //Correct the position
                rb.position = new Vector3(tile, transform.position.y, floor);
            }
        }
	}

    public void Explode()
    {
        anim.SetTrigger("Disappear");

        explosion.transform.position = transform.position;
        explosion.Play();

        SoundManager.PlayExplosionSound();
    }

    public void CollideWithEnemy()
    {
        if (!enemyCollided)
        {
            enemyCollided = true;
            isDead = true;
            
            //Stop movement and then add a little jump upwards
            rb.velocity = Vector3.zero;
            rb.AddForce( new Vector3(0, jumpAmountCollided, 0), ForceMode.Impulse);

            Explode();
        }
    }

    public bool PlayerIsDead()
    {
        //If the player is not visible because it is at the top of the screen, it means it jumped and it shouldn't be dead
        if (!rend.isVisible && (transform.position.y > Camera.main.transform.position.y - 2))
        {
            isDead = false;
            return isDead;
        }

        //If the player is out of the other camera bounds or it collided with an enemy then it is dead
        if (!rend.isVisible || enemyCollided)
        {
            isDead = true;

            Explode();
        }

        return isDead;
    }
}
