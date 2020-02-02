using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHider : MonoBehaviour
{
    private Transform playerTransform;
    private Transform cameraTransform;

    private Shader transparent;
    private Shader defalt;
    public List<Transform> hiddenObjects;
    // Start is called before the first frame update
    void Start()
    {
        transparent = Shader.Find("Unlit/Transparent Colored");
        defalt = Shader.Find("Standard");
        hiddenObjects = new List<Transform>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 direction = playerTransform.position - cameraTransform.position;
        float distance = direction.magnitude;
        RaycastHit[] hits = Physics.RaycastAll(cameraTransform.position, direction, distance);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].transform.gameObject.tag == "Player")
            {
                continue;
            }
            Transform trans = hits[i].transform;
            if (!hiddenObjects.Contains(trans))
            {
                hiddenObjects.Add(trans);
                //trans.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
                trans.GetComponent<Renderer>().material.shader = transparent;
            }
        }

        // Clean all objects
        for (int goneIndex = 0; goneIndex < hiddenObjects.Count; goneIndex++)
        {
            bool putBack = true;
            for (int hitIndex = 0; hitIndex < hits.Length; hitIndex++)
            {
                if (hiddenObjects[goneIndex].Equals(hits[hitIndex].transform))
                {
                    putBack = false;
                    break;
                }
            }

            if (putBack)
            {
                Transform obj = hiddenObjects[goneIndex];
                obj.GetComponent<Renderer>().material.shader = defalt;
                //obj.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1f);
                hiddenObjects.RemoveAt(goneIndex);
                goneIndex--;
            }
        }
    }
}
