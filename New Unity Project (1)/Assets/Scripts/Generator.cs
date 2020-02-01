using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public float timeBetweenLoad = 0.50f;
    private int remaining = 10;
    private bool repairing;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        repairing = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if(remaining > 0)
        {
            if (repairing == true)
            {
                if(Input.GetKey(KeyCode.E) && timer >= timeBetweenLoad)
                { 
                    timer = 0f;
                    repairing = true;
                    remaining -= 1;
                }
            }
        }
        if(remaining <= 0)
        {
            Debug.Log("GENERATOR DESTROYED!");
        }
    }
}
