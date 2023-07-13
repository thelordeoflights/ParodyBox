using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotateenv : MonoBehaviour
{
    public enum Axis { x, y, z, zneg, xneg, yneg };
    public enum Directions { UP, DOWN, LEFT, RIGHT };

    public GameObject castPoint;
    private Vector3 Gravityvector;
    public float g = 9.8f;

    private bool hasSelection = false;
    public RaycastHit currentSelection;

    LayerMask wallMask;
    public HologramHandler hologramHandler;



    void Start()
    {
        wallMask = LayerMask.NameToLayer("wall");
    }



    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return) && hasSelection)
        {


            setGravity();

        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            bool surfaceSelected = selectSurface(castPoint.transform.position, -castPoint.transform.right);
            if (surfaceSelected)
            {
                Gravityvector = -transform.right * g;
            }

        }

        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            bool surfaceSelected = selectSurface(castPoint.transform.position, castPoint.transform.right);
            if (surfaceSelected)
            {
                Gravityvector = transform.right * g;
            }

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            bool surfaceSelected = selectSurface(castPoint.transform.position, castPoint.transform.up);
            if (surfaceSelected)
            {
                Gravityvector = transform.up * g;
            }

        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            bool surfaceSelected = selectSurface(castPoint.transform.position, castPoint.transform.forward);
            if (surfaceSelected)
            {
                Gravityvector = transform.forward * g;
            }
        }
    }



    bool selectSurface(Vector3 position, Vector3 direction)
    {
        position.y += 1f;
        Ray castRay = new Ray(position, direction * 100f);
        Debug.DrawRay(position, direction * 100f, Color.yellow);
        if (Physics.Raycast(castRay, out RaycastHit hit, Mathf.Infinity))
        {

            if (hit.transform.gameObject.layer == wallMask)
            {
                Debug.Log(hit.transform.gameObject.name);
                hasSelection = true;
                currentSelection = hit;
                hologramHandler.setActive(true);
                hologramHandler.setPosition(hit.normal, hit.point);
                return true;
            }
            else
            {
                return false;

            }

        }
        else
        {
            return false;
        }

    }

    void setGravity()
    {

        Physics.gravity = Gravityvector;

        transform.up = currentSelection.normal;
        transform.position = currentSelection.transform.position;
        resetSelection();

    }
    void resetSelection()
    {
        hasSelection = false;
        hologramHandler.setActive(false);
    }

}
