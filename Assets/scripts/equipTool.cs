using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class equipTool : MonoBehaviour
{
    [SerializeField] GameObject onBack;
    [SerializeField] GameObject inHand;
    
    // Start is called before the first frame update
    void Start()
    {
        onBack.SetActive(GameManager.isFighting);
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.isArmed = true;
            Debug.Log(GameManager.isArmed);
            Debug.Log(GameManager.isFighting);
            Destroy(gameObject);
        }
        
       
    }
}
