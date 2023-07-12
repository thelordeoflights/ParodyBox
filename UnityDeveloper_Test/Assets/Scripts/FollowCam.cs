using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    
  public Transform target;
  public Vector3 offset;
    
  void Start()
  {

  }

  // Update is called once per frame
  void LateUpdate()
  {
    transform.position = target.position + offset;
    transform.rotation = target.rotation;
  }
}
