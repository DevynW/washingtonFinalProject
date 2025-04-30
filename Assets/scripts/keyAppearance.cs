using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class keyAppearance : MonoBehaviour
{
    public UnityEvent keyRetrieved;
    GameObject[] gates;
    float x;
    float y;
    float z;
    [SerializeField] float xmin, xmax, ymin, ymax, zmin, zmax;

    // Start is called before the first frame update
    void Start()
    {
        gates = GameObject.FindGameObjectsWithTag("gate");
        GameObject backGate = GameObject.FindGameObjectWithTag("backGate");
        keyRetrieved.AddListener(backGate.GetComponent<gateInteraction>().OnKeyRetrieval);

        foreach (GameObject gate in gates)
        {
            keyRetrieved.AddListener(gate.GetComponent<gateInteraction>().OnKeyRetrieval);
        }
        x = Random.Range(xmin, xmax);
        y = Random.Range(ymin, ymax);
        z = Random.Range(zmin, zmax);
        gameObject.transform.position = new Vector3 (x, y, z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            keyRetrieved.Invoke();
        }
        if (other.gameObject.CompareTag("wall") || other.gameObject.CompareTag("gate"))
        {
            x = Random.Range(xmin, xmax);
            y = Random.Range(ymin, ymax);
            z = Random.Range(zmin, zmax);
            gameObject.transform.position = new Vector3(x, y, z);
        }
    }
}
