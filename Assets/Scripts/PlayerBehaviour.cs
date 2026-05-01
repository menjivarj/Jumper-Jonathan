using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{

    private Rigidbody2D rb;
    private AudioSource audioSource;
    private Animator animator;
    public AudioClip jumpSound;
    public bool aHeld;
    public bool dHeld;
    public bool wHeld;
    public bool onGround;
    public float jumpSpeed;
    public float moveSpeed;
    public float playerBound;
    public TMP_Text scoreText;
    public float maxHeight = 2;
    public GameObject bar;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.aKey.wasPressedThisFrame) 
        {
            aHeld = true;
            animator.Play("JumperRun");
        }
        else if (Keyboard.current.aKey.wasReleasedThisFrame)
        {
            aHeld = false;
        }
        if (aHeld && transform.position.x > -playerBound)
        {
            transform.position -= new Vector3(Time.deltaTime * moveSpeed, 0, 0);
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            dHeld = true;
            animator.Play("JumperRun");
        }
        else if (Keyboard.current.dKey.wasReleasedThisFrame)
        {
            dHeld = false;
        }
        if (dHeld && transform.position.x < playerBound)
        {
            transform.position += new Vector3(Time.deltaTime * moveSpeed, 0, 0);
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            wHeld = true;
        }
        else if (Keyboard.current.wKey.wasReleasedThisFrame)
        {
            wHeld = false;
        }
        if (onGround && wHeld)
        {
            rb.linearVelocityY = jumpSpeed;
            audioSource.PlayOneShot(jumpSound);
        }

        if (maxHeight < transform.position.y)
        {
            maxHeight = transform.position.y;
            scoreText.SetText("Score: " + (int) (maxHeight * 100));
        }

        if (bar.transform.position.y < transform.position.y - 6.7f)
        {
            bar.transform.position = new Vector3(0, transform.position.y - 6.7f, 0);
        }

        if (Camera.main.transform.position.y < transform.position.y - 1)
        {
            Camera.main.transform.position = new Vector3(0, transform.position.y - 1, -10);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && collision.transform.position.y < transform.position.y)
        {
            onGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = false;
        }
    }


}
