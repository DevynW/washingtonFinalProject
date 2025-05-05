using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class gateInteraction : MonoBehaviour
{
    PlayableDirector timeline;
    GameObject timelineHolder;

    // Start is called before the first frame update
    void Start()
    {
        timelineHolder = GameObject.FindGameObjectWithTag("EOGTimeline");
        timeline = timelineHolder.GetComponent<PlayableDirector>();    
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Animator animator = gameObject.GetComponent<Animator>();
        Animator pAnimator = other.GetComponent<Animator>();
        if (other.gameObject.CompareTag("Player") && !gameObject.CompareTag("backGate"))
        {
            //canvas statement
                animator.Play("gateUp");
                pAnimator.Play("crawl");
            
        }

        if(other.CompareTag("Player") && gameObject.CompareTag("backGate") && GameManager.charHasKey == true)
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
