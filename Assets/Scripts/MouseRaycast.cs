using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRaycast : MonoBehaviour
{
    private MoveSpaceshipToPlanet script;
    private Camera camera;
    void Start()
    {
        camera = this.transform.GetComponent<Camera>();
        script = GameObject.Find("Spaceship").GetComponent<MoveSpaceshipToPlanet>();
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
            
            
            if (objectHit.CompareTag("Planet"))
            {
                if (Input.GetButton("Fire1"))
                {
                    script.MoveSpaceshipTo(objectHit);
                }
            }
        }
    }
}
