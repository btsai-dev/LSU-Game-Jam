using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody playerRigidBody;
    private Vector3 camLook;

    private float camDistance;
    private Vector3 moveVelocity;
    private Vector3 moveInput;
    private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        //camLook = new Vector3(0, 12, 0);
        camLook = new Vector3(0, 10, -8);
        playerRigidBody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void FixedUpdate()
    {
 if (Time.timeScale > 0)
        {
            moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            moveVelocity = moveInput * moveSpeed;

            Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
            Plane groundContact = new Plane(Vector3.up, Vector3.zero);
            float rayLength;

            if (groundContact.Raycast(cameraRay, out rayLength))
            {
                Vector3 pointToLook = cameraRay.GetPoint(rayLength);

                transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
            }
        }

        playerRigidBody.velocity = moveVelocity;
    }

    void LateUpdate()
    {
        camDistance = Vector2.Distance(mainCamera.transform.position, playerRigidBody.transform.position);
        
        mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, playerRigidBody.transform.position + camLook, moveSpeed * camDistance * Time.deltaTime);
    }
}
