using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnScript : MonoBehaviour
{
    // Variables
    public GameObject bullet;

    public GameObject bulletSpawnPoint;
    public float coolDown;
    public float movementSpeed;
    public Vector3 spawnLocation;
    public bool isAlive;

    // Methods 
    public virtual void Shoot(Vector3 shootDir) 
    {
        Transform bulletTransform = Instantiate(bullet.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
        BulletScript bulletScript = bulletTransform.gameObject.GetComponent<BulletScript>();
        if (bulletScript != null)
        {
            bulletScript.SetDirection(shootDir);

        }
        else
        {
            Debug.Log("BITCH");
        }

    }

    // Start is called before the first frame update
    //This is the Last 
    public virtual void Start()
    {
        isAlive = true;
        coolDown = 3;

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("HIT");

        GameObject.Destroy(other.gameObject);
        //play effect at some point 
        // reduce health 
        GameObject.Destroy(this.gameObject);

    }



}
