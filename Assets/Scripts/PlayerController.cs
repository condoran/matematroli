using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject projectile;

    [SerializeField] float shootCooldown = 1f;
    [SerializeField] float rotationSpeed = 2.5f;
    [SerializeField] private float moveSpeed = 1.5f;

    public GameObject text;
    private float rotateX;
    private float dirZ;
    private bool triggerSpace;
    private InteractObject interactable;
    private GameObject shootPoint;
    private float cooldown;

    // Start is called before the first frame update
    void Start()
    {
        triggerSpace = false;
        shootPoint = GameObject.Find("Shoot Point");
        cooldown = 0;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (triggerSpace)
            {
                interactable.Interact();
            }
            else if (cooldown <= 0)
            {
                Instantiate(projectile, shootPoint.transform.position, shootPoint.transform.rotation);
                cooldown = shootCooldown;
            }
        }

        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        rotateX = Input.GetAxis("Horizontal") * rotationSpeed;
        dirZ = Input.GetAxis("Vertical") * moveSpeed;
        transform.Translate(dirZ * Time.deltaTime * Vector3.forward);
        transform.Rotate(0, rotateX, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tree"))
        {
            text.SetActive(true);
            triggerSpace = true;
            interactable = other.GetComponent<InteractObject>();
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Tree"))
        {
            text.SetActive(false);
            triggerSpace = false;
            interactable = null;
        }
    }
}
