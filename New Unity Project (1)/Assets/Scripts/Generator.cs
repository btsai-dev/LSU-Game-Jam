using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public float timeBetweenLoad = 0.10f;
    public Material onMat;
    public Material offMat;
    public Rigidbody playerBody;

    private Collider generatorCollider;
    private Renderer render;
    private Material mat;
    private bool running;
    private int remaining;
    private bool inRange;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();
        mat = render.material;
        running = false;
        remaining = 10;
        inRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && !running)
        {
            timer += Time.deltaTime;
            if (remaining > 0)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    Debug.Log("PLAYING WRENCH CRANK!");
                    if (timer >= timeBetweenLoad)
                    {
                        timer = 0f;
                        remaining -= 1;
                    }
                }
            }
            if (remaining <= 0)
            {
                execOn();
                Debug.Log("BEEP! GENERATOR ON!");
            }
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "Player")
            inRange = true;
    }
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.name == "Player")
            inRange = false;
    }

    void execOn()
    {
        Debug.Log(mat);
        running = true;
        mat.SetColor("_Color", Color.blue);
        Debug.Log("STARTING TO PLAY THE GENERATOR!");
        // Turn some color into green
    }
}
