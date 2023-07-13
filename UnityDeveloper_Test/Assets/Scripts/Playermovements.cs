using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovements : MonoBehaviour
{

    public Rigidbody PlayerRb;
    private Animator playeranim;


    public float verticalinput;
    public float horizontalinput;
    private float jump = 4f;
    private float moveSpeed;

    public Vector3 normal = Vector3.up;

    Vector3 moveDirection;

    Rotateenv rotateenv;
    void Start()
    {

        PlayerRb = GetComponent<Rigidbody>();
        rotateenv = GetComponent<Rotateenv>();
        playeranim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        verticalinput = Input.GetAxisRaw("Vertical");
        horizontalinput = Input.GetAxisRaw("Horizontal");

        transform.Translate(Vector3.forward * verticalinput * Time.deltaTime * 5);
        transform.Rotate(Vector3.up * horizontalinput * 100 * Time.deltaTime);

        if (verticalinput != 0 || horizontalinput != 0)
        {
            playeranim.SetBool("Run_trig", true);
        }
        else
        {
            playeranim.SetBool("Run_trig", false);
        }



        if (Input.GetKeyDown(KeyCode.Space))
        {
            playeranim.SetTrigger("Jump_trig");
            PlayerRb.AddForce(transform.up * jump, ForceMode.Impulse);
        }

    }
}
