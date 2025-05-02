using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool charHasKey = false;
    public static bool isArmed = false;
    public static bool isFighting = false;
    public static float playerHealth = 100f;
    [SerializeField] float desiredInterval = 3f;
    float timeElapsed;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        timeElapsed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (playerHealth < 100)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= desiredInterval) 
            {
                playerHealth += 3;
                timeElapsed = 0;
            }
        }
        if (playerHealth <= 0)
        {
            Destroy(player);
        }
    }
}
