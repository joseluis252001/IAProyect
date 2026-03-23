using System;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    [SerializeField] float speed;
    private Vector3 target;

    private Camera cam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
            target = hit.point;
            }
               Debug.Log(hit.point);
        }
         transform.position = Vector3.MoveTowards(transform.position,target,speed * Time.fixedDeltaTime);
    }
}
