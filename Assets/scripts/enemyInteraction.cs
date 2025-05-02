using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemyInteraction : MonoBehaviour
{
    public bool isPlayer = false;
    public bool isEnemy = false;
    public bool isRat = false;
    public bool isRoach = false;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.CompareTag("Player"))
            isPlayer = true;
        if(gameObject.CompareTag("Rat") || gameObject.CompareTag("Roach"))
            isEnemy = true;
        if (gameObject.CompareTag("Rat"))
            isRat = true;
        if (gameObject.CompareTag("Roach"))
            isRoach = true;
    }
    /*
     * if enemy senses (outer collider) player & is rat, start sniffing around (play anim and look at)
     * if enemy senses olayer & is roach, look at and start walking (play anim and look at)
     * If enemy gets within striking range, player is armed and fighting (back disabled, hand enabled, fighting ctrl'd by user(anim))
     * If player gets within striking range, enemy will attack
     * 
     */
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>());
        if (isEnemy && GameManager.isFighting)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
        }
            
       
            
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isEnemy && other.gameObject.CompareTag("Player"))
        {
            GameManager.isFighting = true;
            Debug.Log("worldStar");
        }
    }
}
