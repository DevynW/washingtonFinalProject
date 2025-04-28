using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gateInteraction : MonoBehaviour
{
    bool isBackGate = false;
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
        if (other.gameObject.CompareTag("Player") && !gameObject.CompareTag("backGate") || 
            other.gameObject.CompareTag("Player") && gameObject.CompareTag("backGate") && GameManager.charHasKey == true)
        {
            animator.Play("openGate");
        }
    }
}
