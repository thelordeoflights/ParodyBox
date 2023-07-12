using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HologramHandler : MonoBehaviour
{

    GameObject gb;

    // Start is called before the first frame update
    void Start()
    {
        gb = GameObject.FindGameObjectWithTag("hologram");
        gb.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setPosition(Vector3 position)
    {
        gb.transform.position = position;
    }

    public void setActive(bool val)
    {
        gb.SetActive(val);
    }

}
