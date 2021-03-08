using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnScript : MonoBehaviour
{
    // Variables

    public float coolDown;
    public float movementSpeed;
    public Vector3 spawnLocation;
    private bool isAlive;
    public int health;

    public GunScript equippedGun;
    public GameObject gunParent;

    private Vector3 gunRelLocation = new Vector3(0.55f, 0.2f, 0.62f);

    // Methods 
    public virtual void Shoot(Vector3 shootDir) 
    {
        if (equippedGun != null) 
        {
            equippedGun.Shoot(shootDir);
        }
        else 
        {
            Debug.Log("Does not have gun");
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

    public void EquipGun(GunScript newGun) 
    {
        if (equippedGun != null)
        {
            equippedGun.transform.parent = null; // Drop previous gun
        }
        newGun.transform.parent = gunParent.transform; // Get new gun
        newGun.transform.localPosition = gunRelLocation;
        equippedGun = newGun;

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


    
}
