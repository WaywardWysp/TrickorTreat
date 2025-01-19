using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerController : MonoBehaviour
{
    //Animator animator;

    public GameObject NPCDio;


    // Start is called before the first frame update
    void Start()
    {
  


        //animator = GetComponent<Animator>();

        //nimator.SetTrigger("ToDoor");
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        NPCDio.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        NPCDio.SetActive(false);
    }


    // public void Leave()
    //{
    //    animator.SetTrigger("FromDoor");
    // }
}
