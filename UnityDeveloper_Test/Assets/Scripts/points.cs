using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class points : MonoBehaviour
{

    private string pointTag = "point";
    private int totalPoints = 0;

    [SerializeField]
    public Playermovements pm;

    void Start()
    {
        totalPoints = GameObject.FindGameObjectsWithTag(pointTag).Length;
    }


    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(pointTag))
        {
            Destroy(other.gameObject);
            --totalPoints;
            if (totalPoints <= 0)
            {
                pm.Gameover();
            }
        }
    }
}
