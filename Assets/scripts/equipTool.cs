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
        //onBack = GameObject.FindGameObjectWithTag("holstered");

        if (onBack != null )
        Debug.Log(name + "holstered found");

        onBack.SetActive(GameManager.isArmed);

        //inHand = GameObject.FindGameObjectWithTag("weapon");
        inHand = GameObject.FindObjectOfType<weaponScript>(true).gameObject;

        if (inHand != null )
        Debug.Log(name + ": weapon found");
        else
           Debug.Log(name + ": weapon not found");
        inHand.SetActive(GameManager.isFighting);
        
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.isArmed == true && GameManager.isFighting == false)
        { 
            onBack.SetActive(true);
            inHand.SetActive(GameManager.isFighting);
        }

       if (GameManager.isArmed == true && GameManager.isFighting == true && onBack != false)
        {
            onBack.SetActive(false);//ask why openknife can't find this
            inHand.SetActive(GameManager.isFighting);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.isArmed = true;
            Debug.Log(name + ": armed:");
            Debug.Log(GameManager.isArmed);
            Debug.Log(name + ": fighting:");
            Debug.Log(GameManager.isFighting);
            Destroy(gameObject);
        }
        
       
    }
}
