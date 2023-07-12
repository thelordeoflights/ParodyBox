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
            switch (rotateenv.currentAxis)
            {
                case Rotateenv.Axis.x:
                    PlayerRb.AddForce(Vector3.left * jump, ForceMode.Impulse);
                    break;
                case Rotateenv.Axis.y:
                    PlayerRb.AddForce(Vector3.forward * jump, ForceMode.Impulse);
                    break;
                case Rotateenv.Axis.z:
                    PlayerRb.AddForce(Vector3.up * jump, ForceMode.Impulse);
                    break;
                case Rotateenv.Axis.zneg:
                    PlayerRb.AddForce(Vector3.down * jump, ForceMode.Impulse);
                    break;

                default:
                    PlayerRb.AddForce(Vector3.left * jump, ForceMode.Impulse);
                    break;
            }
        }

    }
}
