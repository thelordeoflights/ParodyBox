using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotateenv : MonoBehaviour
{
    public enum Axis { x, y, z, zneg };
    public Axis currentAxis;

    // Start is called before the first frame update
    void Start()
    {
        currentAxis = Axis.z;
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentAxis = Axis.x;
            Physics.gravity = new Vector3(9.8f, 0, 0);
            Vector3 newRotation = new Vector3(0, 0, 90);
            transform.eulerAngles = newRotation;

        }

        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            currentAxis = Axis.y;
            Physics.gravity = new Vector3(0, 0, -9.8f);
            Vector3 newRotation = new Vector3(90, 0, 0);
            transform.eulerAngles = newRotation;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentAxis = Axis.z;
            Physics.gravity = new Vector3(0, -9.8f, 0);
            Vector3 newRotation = new Vector3(0, 90, 0);
            transform.eulerAngles = newRotation;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentAxis = Axis.zneg;
            Physics.gravity = new Vector3(0, 9.8f, 0);
            Vector3 newRotation = new Vector3(0, -90, 180);
            transform.eulerAngles = newRotation;
        }
    }
}
