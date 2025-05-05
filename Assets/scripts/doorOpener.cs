using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorOpener : MonoBehaviour
{
    [SerializeField] GameObject door;
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
        Animator animator = door.GetComponent<Animator>();
        if (other.gameObject.CompareTag("Player"))
        {
            //canvas statement
            animator.Play("doorOpener");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Animator animator = door.GetComponent<Animator>();
        if (other.gameObject.CompareTag("Player"))
        {
            //canvas statement
            animator.Play("doorCloser");
            SceneManager.LoadScene("interiorScene");
        }
    }
}
