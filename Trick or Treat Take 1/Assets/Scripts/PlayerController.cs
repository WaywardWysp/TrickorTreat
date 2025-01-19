using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Variables related to player character movement
    public InputAction MoveAction;
    Rigidbody2D rigidbody2d;
    Vector2 move;
    public float speed = 3.0f;

    // Variables related to animation
    Animator animator;
    Vector2 moveDirection = new Vector2(1, 0);

    // Variables related to the candy score system
    public int maxScore= 1;
    public int score;

    //Talk Interact
    public InputAction InteractAction;

    //Restart
    public InputAction RestartAction;

    public GameObject gameOverText;
    public GameObject gameWinText;
    public bool gameOver;

    AudioSource audioSource;

    void Start()
    {
        MoveAction.Enable();

        InteractAction.Enable();
        InteractAction.performed += Interact;

        RestartAction.Disable();
        RestartAction.performed += Restart;

        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();

        score = 0;

        gameOver = false;
    }

    void Update()
    {
        move = MoveAction.ReadValue<Vector2>();

        //All movement
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            moveDirection.Set(move.x, move.y);
            moveDirection.Normalize();

            audioSource.Play();
        }

        animator.SetFloat("Move X", moveDirection.x);
        animator.SetFloat("Move Y", moveDirection.y);
        animator.SetFloat("Speed", move.magnitude);

      


        //All end game choices

        if (score == maxScore)
        {
            gameWinText.SetActive(true);
            speed = 0;
            gameOver = true;
        }


        if (gameOver == true)
        {
            RestartAction.Enable();
         
        }

    }

    void FixedUpdate()
    {
        Vector2 position = (Vector2)rigidbody2d.position + move * speed * Time.deltaTime;
        rigidbody2d.MovePosition(position);
    }

    public void ChangeScore(int scoreAmount)
    {

        score = score + scoreAmount;
        maxScore = score;

    }


    void Interact(InputAction.CallbackContext context)
    {

    }

    void Restart(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Should reload current scene effectively restarting the game
    }
}
