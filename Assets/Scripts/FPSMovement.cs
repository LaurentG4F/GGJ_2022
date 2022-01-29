using System;
using UnityEngine;

public class FPSMovement : MonoBehaviour
{
    public float speed = 10;
    public float jumpForce = 10;
    public float mouseSensitivity = 2;
    public Transform cam;
    public EventManager eventManager;
    
    private Rigidbody rb;
    private bool canJump = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void OnApplicationFocus(bool hasFocus)
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        var mouseMovement = new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
        var angles = cam.eulerAngles;
        angles += mouseMovement * mouseSensitivity;
        if (angles.x > 90 && angles.x < 180)
        {
            angles.x = 90;
        }
        if (angles.x > 180 && angles.x < 270)
        {
            angles.x = 270;
        }
        cam.eulerAngles = angles;
        
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void FixedUpdate()
    {
        {
            RaycastHit infos;
            bool touchedObject = Physics.SphereCast(cam.position, 0.05f, cam.forward, out infos, 5f);
            if (touchedObject)
            {
                var interactiveObject = infos.collider.GetComponent<InteractiveObject>();
                if (interactiveObject)
                {
                    eventManager.bottomText.text = interactiveObject.prompt;
                    if (Input.GetButtonDown("Use"))
                    {
                        interactiveObject.scriptToExecute.Invoke();
                    }
                }
                else
                {
                    eventManager.bottomText.text = "";
                }
            }
            else
            {
                eventManager.bottomText.text = "";
            }
        }
        
        {
            RaycastHit infos;
            bool touchedGound = Physics.SphereCast(transform.position, 0.05f, -transform.up, out infos, 0.1f);

            if (touchedGound)
            {
                canJump = true;
            }

            if (canJump && Input.GetButton("Jump"))
            {
                var v = rb.velocity;
                v.y = 0;
                rb.velocity = v;
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                canJump = false;
            }
        }

        {
            Vector3 movement = Vector3.zero;
            var forward = cam.forward;
            forward.y = 0;
            forward = forward.normalized;
            movement += forward * speed * Input.GetAxis("Vertical");
            movement += cam.right * speed * Input.GetAxis("Horizontal");
            movement.y = rb.velocity.y;
            rb.velocity = movement;
        }
        
    }

    // private void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.green;
    //     Gizmos.DrawLine(spawnPoint.position, spawnPoint.position + lastSpawnForce);
    // }
}
