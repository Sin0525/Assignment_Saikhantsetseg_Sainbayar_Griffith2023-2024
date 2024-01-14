using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class BasicCharacterController : MonoBehaviour
{
    //movement variables
    public float moveForce;
    public float maxSpeed;
    private Rigidbody playerRigidbody;
    public float jumpForce;
    public GameObject groundcheck;
    //rotation variables
    public GameObject child;
    public float rotateSpeed;
    public float rotationSensitivity;
    //animation variables
    public Animator playerAnimator;
  
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        //move code starts
        if (Mathf.Abs(playerRigidbody.velocity.magnitude) < maxSpeed) //checks if the rigidbody is moving slower than maxSpeed
        {
            playerRigidbody.AddForce( x:(Input.GetAxis("Horizontal") * moveForce), y:0, z: (Input.GetAxis("Vertical") * moveForce)); //applies force in the forward (verical, z) and sideways (horizontal, y) axes
        }
        //move code ends

        //jump code starts
        if (Input.GetButtonDown("Jump") && groundcheck.GetComponent<Exercise2GroundCheck>().amIOnTheGround == true)
        {
            playerRigidbody.AddForce(x: 0, y: jumpForce, z: 0);
        }
        //jump code ends
        //rotation code starts
        Vector3 moveDirection = new Vector3(playerRigidbody.velocity.x, y:0, playerRigidbody.velocity.z);
        if (moveDirection.magnitude > rotationSensitivity)
        {
            //Debug.Log("rotating to" + moveDirection);
            child.transform.rotation = Quaternion.Slerp( a: child.transform.rotation, b: Quaternion.LookRotation(moveDirection), t: Time.deltaTime * rotateSpeed);
        }
        //rotation code ends

        //animation code begins
        playerAnimator.SetFloat(name:"speed", moveDirection.magnitude);
        playerAnimator.SetFloat(name: "verticalSpeed", playerRigidbody.velocity.y);
        playerAnimator.SetBool("amIGrounded", groundcheck.GetComponent<Exercise2GroundCheck>().amIOnTheGround);
    }
}
