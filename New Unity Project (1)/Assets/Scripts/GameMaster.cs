using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public int generators;
    public int repaired;
    void Start()
    {
        generators = GameObject.FindGameObjectsWithTag("Generator").Length;
        repaired = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
