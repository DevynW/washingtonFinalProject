using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class equipTool : MonoBehaviour
{
    GameObject onBack;
    GameObject inHand;
    
    // Start is called before the first frame update
    void Start()
    {
        onBack = GameObject.FindGameObjectWithTag("holstered");

        if (onBack != null )
        Debug.Log("holstered found");

        onBack.SetActive(!GameManager.isFighting);

        inHand = GameObject.FindGameObjectWithTag("weapon");

        if (inHand != null )
        Debug.Log("holstered found");

        inHand.SetActive(GameManager.isFighting);
    }

    // Update is called once per frame
    void Update()
    {
       if (GameManager.isArmed && !GameManager.isFighting)
        { 
            onBack.SetActive(true);
            inHand.SetActive(GameManager.isFighting);
        }

       if (GameManager.isArmed && GameManager.isFighting)
        {
            onBack.SetActive(!GameManager.isFighting);
            inHand.SetActive(GameManager.isFighting);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.isArmed = true;
            Debug.Log("armed:");
            Debug.Log(GameManager.isArmed);
            Debug.Log("fighting:");
            Debug.Log(GameManager.isFighting);
            Destroy(gameObject);
        }
        
       
    }
}
