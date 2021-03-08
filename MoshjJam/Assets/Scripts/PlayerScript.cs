using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : PawnScript
{
    // Variables
    public float movementSpeed = 1;
    public GameObject camera;

    public GameObject playerObject;

    public GameObject bullet;

    public GameObject bulletSpawnPoint;
    public float waitTime;

    private Vector3 mouseLastPos = Vector3.zero;

    // Methods



    void Shoot() 
    {
        Transform bulletTransform = Instantiate(bullet.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
        BulletScript bulletScript = bulletTransform.gameObject.GetComponent<BulletScript>();
        if (bulletScript != null)
        {
            Vector3 shootDir = mouseLastPos - bulletSpawnPoint.transform.position;
            shootDir.y = 0;
            shootDir.Normalize();
            bulletScript.SetDirection(shootDir);

        }
        else
        {
            Debug.Log("BITCH");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Player facing mouse
        Plane playerplane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitDist = 0.0f;

        if (playerplane.Raycast(ray, out hitDist)) 
        {
            Vector3 targetPoint = ray.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            playerObject.transform.rotation = Quaternion.Slerp(playerObject.transform.rotation, targetRotation, 7f * Time.deltaTime);
            mouseLastPos = targetPoint;
        }
        
        
        // Player Movement 
        if (Input.GetKey(KeyCode.W)) 
        {
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
        }

        // Shooting
        if (Input.GetMouseButtonDown(0)) 
        {
            Shoot();
        }
    }

}
