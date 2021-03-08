using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnScript : MonoBehaviour
{
    // Variables
    public GameObject bullet;

    public GameObject bulletSpawnPoint;
    public float waitTime;

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
    void Start()
    {
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
