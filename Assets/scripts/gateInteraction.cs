using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gateInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
     
            
        
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
            if (Input.GetKey(KeyCode.Tab))
            {
                animator.Play("openGate");
                pAnimator.Play("throughGate");
            }
            
        }
    }

    public void OnKeyRetrieval()
    {
        GameManager.charHasKey = true;
        Debug.Log("Char has Key");
    }
}
