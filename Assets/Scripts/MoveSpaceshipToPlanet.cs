using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpaceshipToPlanet : MonoBehaviour
{
    public Transform spaceship;
    
    [SerializeField] private float speed;

    private Transform planet;
    private bool isMooving;

    private Vector3 targetPoint;

    private Quaternion targetRotation;
    // Start is called before the first frame update
    void Start()
    {
        isMooving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMooving)
        {
            
            float step =  speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, planet.position, step);

            // Check if the position of the cube and sphere are approximately equal.
            if (Vector3.Distance(transform.position, planet.position) < 18f)
            {
                isMooving = false;
                Debug.Log(Vector3.Distance(transform.position, planet.position));
            }
        }
    }

    public void MoveSpaceshipTo(Transform planet)
    {
        this.planet = planet;
        isMooving = true;
    }
}
