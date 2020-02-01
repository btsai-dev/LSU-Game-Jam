using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Generator : MonoBehaviour
{
    public float timeBetweenLoad = 0.10f;
    public Material onMat;
    public Material offMat;
    public Light worldLight;

    private AudioSource hum;
    private Collider generatorCollider;
    private Renderer render;
    private Material mat;
    private bool running;
    private int remaining;
    private bool inRange;
    float timer;
    private Light source;
    private Light[] lights;
    private Material[] materials;
    private AudioSource[] audios;
    // Start is called before the first frame update
    void Start()
    {
        worldLight = this.transform.Find("WorldLight").gameObject.GetComponent<Light>();
        worldLight.range = 0;
        source = this.transform.Find("GenLight").gameObject.GetComponent<Light>();
        source.range = 5;
        source.color = Color.red;
        audios = new AudioSource[6];
        audios[5] = this.transform.Find("Indicator 01").gameObject.GetComponent<AudioSource>();
        audios[4] = this.transform.Find("Indicator 02").gameObject.GetComponent<AudioSource>();
        audios[3] = this.transform.Find("Indicator 03").gameObject.GetComponent<AudioSource>();
        audios[2] = this.transform.Find("Indicator 04").gameObject.GetComponent<AudioSource>();
        audios[1] = this.transform.Find("Indicator 05").gameObject.GetComponent<AudioSource>();
        audios[0] = this.transform.Find("Indicator Main").gameObject.GetComponent<AudioSource>();
        
        lights = new Light[6];
        lights[5] = this.transform.Find("Indicator 01").gameObject.GetComponent<Light>();
        lights[4] = this.transform.Find("Indicator 02").gameObject.GetComponent<Light>();
        lights[3] = this.transform.Find("Indicator 03").gameObject.GetComponent<Light>();
        lights[2] = this.transform.Find("Indicator 04").gameObject.GetComponent<Light>();
        lights[1] = this.transform.Find("Indicator 05").gameObject.GetComponent<Light>();
        lights[0] = this.transform.Find("Indicator Main").gameObject.GetComponent<Light>();
        foreach(Light light in lights)
        {
            light.color = Color.red;
            light.range = 7;
            light.intensity = 2;
        }

        hum = GetComponent<AudioSource>();
        render = GetComponent<Renderer>();
        mat = render.material;
        running = false;
        remaining = 100;
        inRange = false;
        materials = new Material[6];
        materials[5] = this.transform.Find("Indicator 01").gameObject.GetComponent<Renderer>().material;
        materials[4] = this.transform.Find("Indicator 02").gameObject.GetComponent<Renderer>().material; ;
        materials[3] = this.transform.Find("Indicator 03").gameObject.GetComponent<Renderer>().material; ;
        materials[2] = this.transform.Find("Indicator 04").gameObject.GetComponent<Renderer>().material; ;
        materials[1] = this.transform.Find("Indicator 05").gameObject.GetComponent<Renderer>().material; ;
        materials[0] = this.transform.Find("Indicator Main").gameObject.GetComponent<Renderer>().material; ;
        
        materials[5].SetColor("_Color", Color.red);
        materials[4].SetColor("_Color", Color.red);
        materials[3].SetColor("_Color", Color.red);
        materials[2].SetColor("_Color", Color.red);
        materials[1].SetColor("_Color", Color.red);
        materials[0].SetColor("_Color", Color.red);

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
                    // Debug.Log("PLAYING WRENCH CRANK!");
                    if (timer >= timeBetweenLoad)
                    {
                        timer = 0f;
                        remaining -= 1;
                        switch (remaining)
                        {
                            case 1: 
                                audios[0].Play();
                                lights[0].color = Color.green;
                                break;
                            case 19:
                                audios[1].Play();
                                lights[1].color = Color.green;
                                break;
                            case 39:
                                audios[2].Play();
                                lights[2].color = Color.green;
                                break;
                            case 59:
                                audios[3].Play();
                                lights[3].color = Color.green;
                                break;
                            case 79:
                                audios[4].Play();
                                lights[4].color = Color.green;
                                break;
                            case 99:
                                audios[5].Play();
                                lights[5].color = Color.green;
                                break;
                        }
                    }
                }
            }
            if (remaining <= 0)
            {
                execOn();
                if(remaining == 0)
                    audios[0].Play();
                materials[0].SetColor("_Color", Color.green);
                materials[1].SetColor("_Color", Color.green);
                materials[2].SetColor("_Color", Color.green);
                materials[3].SetColor("_Color", Color.green);
                materials[4].SetColor("_Color", Color.green);
                materials[5].SetColor("_Color", Color.green);
            }
            else if (remaining <= 19)
            {
                materials[1].SetColor("_Color", Color.green);
            }
            else if (remaining <= 39)
            {
                materials[2].SetColor("_Color", Color.green);
            }
            else if (remaining <= 59)
            {
                materials[3].SetColor("_Color", Color.green);
            }
            else if (remaining <= 79)
            {
                materials[4].SetColor("_Color", Color.green);
            }
            else if (remaining <= 99)
            {
                materials[5].SetColor("_Color", Color.green);
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
        worldLight.range = 100;
        source.range = 13;
        source.color = Color.green;
        hum.Play();
        running = true;
    }
}
