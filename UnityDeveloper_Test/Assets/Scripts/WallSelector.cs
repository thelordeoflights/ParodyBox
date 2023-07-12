using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSelector : MonoBehaviour
{

    LayerMask wallMask;

    private HologramHandler hologramHandler;

    // Start is called before the first frame update
    void Start()
    {
        wallMask = LayerMask.NameToLayer("wall");
        hologramHandler = GetComponent<HologramHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        var rayPoint = getSelectorPosition();
        bool setActive = true;

        // Debug.Log(rayPoint);

        if (rayPoint == Vector3.zero)
        {
            setActive = false;
        }

        setHologramConfig(setActive, rayPoint);
    }

    void setHologramConfig(bool active, Vector3 position)
    {
        hologramHandler.setActive(active);
        hologramHandler.setPosition(position);
    }

    public Vector3 getSelectorPosition()
    {
        // Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 100f, Color.yellow);
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit raycastHit, Mathf.Infinity))
        {
            if (raycastHit.transform.gameObject.layer == wallMask)
            {
                // Debug.Log("WALL LAGA HAIN");
                return raycastHit.point;
            }
            else
            {
                return Vector3.zero;

            }
        }
        else
        {
            return Vector3.zero;
        }
    }

}
