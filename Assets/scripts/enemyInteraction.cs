using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyInteraction : MonoBehaviour
{
    public bool isPlayer = false;
    public bool isEnemy = false;
    public bool isRat = false;
    public bool isRoach = false;
    public bool isArmed = false;
    public bool isFighting = false;
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
        
    }
}
