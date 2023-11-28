using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class user : MonoBehaviour
{
    // For user movement 
    private CharacterController userCharacter;
    public Vector3 userDirection;
    public float userSpeed;
    private Transform cameraTransform;

    // For shooting
    public Transform bulletStart;
    public GameObject bulletPrefab;
    public float bulletForce;

    void Start()
    {
        userCharacter = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        // For user movement
        Vector2 userControl = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        float cameraRotation = cameraTransform.eulerAngles.y;
        Vector3 cameraRotationVector = Quaternion.Euler(new Vector3(0, 90, 0)) * cameraTransform.forward;
        userDirection = (cameraRotationVector * Input.GetAxis("Horizontal") + cameraTransform.forward * Input.GetAxis("Vertical")).normalized;
        userDirection.y = 0f;
        userCharacter.Move(userDirection * Time.deltaTime * userSpeed);

        // For shooting
        float triggerOculusValue = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);

        if (Input.GetButtonDown("Fire1") || triggerOculusValue >= 1f)
        {
            GameObject newBullet = Instantiate(bulletPrefab, bulletStart.transform.position, bulletStart.rotation);
            Rigidbody bulletforce = newBullet.GetComponent<Rigidbody>();
            bulletforce.AddForce(-bulletStart.forward  * bulletForce, ForceMode.Impulse);
            Destroy(newBullet, 10f);
        }
    }

    
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision was with an object that should destroy the bullet
        if (collision.gameObject.CompareTag("ObjetoQueDestruyeBala"))
        {
            // Destroy the bullet
            Destroy(collision.gameObject);
            Destroy(gameObject); // Destroy the bullet
        }
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            // Destroy the bullet
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
