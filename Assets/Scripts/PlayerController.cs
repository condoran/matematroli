using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 2.5f;
    [SerializeField] private float moveSpeed = 1.5f;

    public GameObject text;
    private float rotateX;
    private float dirZ;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rotateX = Input.GetAxis("Horizontal") * rotationSpeed;
        dirZ = Input.GetAxis("Vertical") * moveSpeed;
        transform.Translate(Vector3.forward * dirZ * Time.deltaTime);
        transform.Rotate(0, rotateX, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tree"))
        {
            text.SetActive(true);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Tree"))
        {
            text.SetActive(false);
        }
    }
}
