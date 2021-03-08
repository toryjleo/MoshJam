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
    private bool isAlive;
    public int health;

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

    public void TakeDamage(int damage) 
    {
        health -= damage;
        if (health <= 0) 
        {
            isAlive = false;
        }
    }

    public bool IsAlive() 
    {
        return isAlive;
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
