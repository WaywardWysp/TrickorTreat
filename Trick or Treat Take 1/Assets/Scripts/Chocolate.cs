using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chocolate : MonoBehaviour
{

    AudioSource audioSource;

    private PlayerController Player;
    private NonPlayerController NPC;


    // Start is called before the first frame update
    void Start()
    {
        GameObject PlayerControllerObject = GameObject.FindWithTag("Player");
        if (PlayerControllerObject != null)

        {

            Player = PlayerControllerObject.GetComponent<PlayerController>(); //and this line of code finds the rubyController and then stores it in a variable

            print("Found the PlayerController Script!");

        }

        if (Player == null)

        {

            print("Cannot find PlayerController Script!");

        }

        GameObject NonPlayerControllerObject = GameObject.FindWithTag("NPC");
        if (NonPlayerControllerObject != null)

        {

            NPC = NonPlayerControllerObject.GetComponent<NonPlayerController>(); //and this line of code finds the rubyController and then stores it in a variable

            print("Found the NonPlayerController Script!");

        }

        if (NPC == null)

        {

            print("Cannot find NonPlayerController Script!");

        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            player.gameOverText.SetActive(true);
            player.gameOver = true;
            player.speed = 0;
        }

    }

}
