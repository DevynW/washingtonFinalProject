using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class gateInteraction : MonoBehaviour
{
    PlayableDirector timeline;

    // Start is called before the first frame update
    void Start()
    {
     
          timeline = GetComponent<PlayableDirector>();    
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Animator animator = gameObject.GetComponent<Animator>();
        Animator pAnimator = other.GetComponent<Animator>();
        if (other.gameObject.CompareTag("Player") && !gameObject.CompareTag("backGate") || 
            other.gameObject.CompareTag("Player") && gameObject.CompareTag("backGate") && GameManager.charHasKey == true)
        {
            //canvas statement
                animator.Play("gateUp");
                //pAnimator.Play("throughGate");
            
        }

        if(gameObject.CompareTag("backGate") && GameManager.charHasKey == true)
        {
            timeline.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Animator animator = gameObject.GetComponent<Animator>() ;
        animator.Play("gateDown");
    }

    public void OnKeyRetrieval()
    {
        GameManager.charHasKey = true;
        Debug.Log(name + "Char has Key");
        GameManager.isArmed = false;
        GameManager.isFighting = false;
    }
}
