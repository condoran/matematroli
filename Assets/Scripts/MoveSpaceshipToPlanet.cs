using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpaceshipToPlanet : MonoBehaviour
{
    public Transform spaceship;
    public GameObject[] particleSystems;
    
    [SerializeField] private float speed;

    private Transform planet;
    private bool isMooving;

    private float distanceC;
    private float distanceA;
    private float distanceB;
    private float angleA;

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
            spaceship.rotation = Quaternion.Slerp(spaceship.rotation, targetRotation, Time.deltaTime * 5f);
            float step =  speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, planet.position, step);
            

            // Check if the position of the cube and sphere are approximately equal.
            if (Vector3.Distance(transform.position, planet.position) < 18f)
            {
                isMooving = false;
                Debug.Log(Vector3.Distance(transform.position, planet.position));
                foreach (GameObject system in particleSystems)
                {
                    system.GetComponent<ParticleSystem>().Stop();
                }
            }
        }
    }

    public void MoveSpaceshipTo(Transform planet)
    {
        this.planet = planet;
        isMooving = true;
        distanceA = planet.position.y - spaceship.position.y;
        distanceB = planet.position.z - spaceship.position.z;
        angleA = Mathf.Atan2(distanceA, distanceB) * Mathf.Rad2Deg;
        targetRotation = Quaternion.Euler(-angleA, 0, 0);
        foreach (GameObject system in particleSystems)
        {
            system.GetComponent<ParticleSystem>().Play();
        }
    }
}
