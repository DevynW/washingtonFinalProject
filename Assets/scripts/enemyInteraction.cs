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
    [SerializeField] float speed = 50f;
    float damageCaused = 0f;
    float enemyhealth = 100f;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        if (CompareTag("Player"))
        {
            isPlayer = true;
            damageCaused = 30f;
        }
        if (CompareTag("Rat") || CompareTag("Roach"))
            isEnemy = true;
        if (CompareTag("Rat"))
        {
            damageCaused = 30f;
            isRat = true;

        }
        if (CompareTag("Roach"))
        {
            damageCaused = 15f;
            isRoach = true;
        }
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
        distance = Vector3.Distance(gameObject.transform.position,GameObject.FindGameObjectWithTag("Player").transform.position);
        if (/*isEnemy && */GameManager.isFighting)
        {
            if(isRat && distance <= 3f)
                transform.Translate(Vector3.forward * speed * Time.deltaTime);

            if(isRoach && distance <= 2f)
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (enemyhealth <= 0f)
        {
            Debug.Log(name + "dying");
            Destroy(gameObject);
        }
            
       
            
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isEnemy && other.gameObject.CompareTag("Player") && GameManager.isArmed)
        {
            GameManager.isFighting = true;
            Debug.Log(name + "worldStar");
        }
    }

   
    private void OnCollisionEnter(Collision collision)
    {
        if (isEnemy && collision.gameObject.CompareTag("weapon"))
        {
            enemyhealth -= 30f;
            Debug.Log(name + enemyhealth);
        }
        if (isEnemy && collision.gameObject.CompareTag("Player"))
        {
            GameManager.playerHealth -= damageCaused;
            Debug.Log(name + GameManager.playerHealth);
        }
    }
}
