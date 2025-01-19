using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{


    //Collect all the controllers
    //private PlayerController playerController;
   // private NonPlayerController nonplayerController;
   //This is in case I need it - Turned off for now

    //Trick or Treater Door Stuff
    Animator animator;
    AudioSource Bell;
    ParticleSystem Doorbell;


    //Are there trick or Treators?
    bool ToT = false;

    public GameObject OpenDoorText;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Bell = GetComponent<AudioSource>();
        Doorbell = GetComponent <ParticleSystem>();

        //TrickOrTreat and the NPC are not talking so... rework for now
        Doorbell.Play(true);

        Bell.Play();

        OpenDoorText.SetActive(true);


    }

    // Update is called once per frame
    void Update()
    {
        if (!ToT) 
        { 
            return;
        }
    }

        
    void OnTriggerEnter2D(Collider2D other)
    {
   
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {

            animator.SetTrigger("Open");

            Bell.Stop();
            OpenDoorText.SetActive(false);
            Doorbell.Stop();


        }
    }

   // public void OpenDoor()
    //{
        
    //}

    public void CloseDoor()
    {
        animator.SetTrigger("Close");
    }
}
