using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject bullet;

    public GameObject bulletSpawnPoint;

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
        bulletSpawnPoint = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
