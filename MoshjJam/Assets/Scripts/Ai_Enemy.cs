using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_Enemy : PawnScript
{

    public GameObject player; 
    public Vector3 VtoPlayer;
    public GameObject gun; 

    void Spawn(Vector3 spawnPoint) //Spawns AI at coordinator 
    {
        

    }

    // Start is called before the first frame update
    void Start()
    {
        //this.Spawn(x, y, z);
        movementSpeed = 2;

        base.Start();
    }

    

    // Update is called once per frame
    void Update()
    { 

        Vector3 P_Location = player.transform.position; 

        VtoPlayer = P_Location - this.transform.position; //This points to the player 

        VtoPlayer.Normalize(); //Normalizes vector to be relative to 1 

        transform.Translate(VtoPlayer * movementSpeed * Time.deltaTime); //move twoard player

        if (coolDown > 0)
        {
            coolDown -= 1;
        }
        else
        {
            Shoot(VtoPlayer);
            coolDown = 150; 
            //coolDown = gun.firerate; 
        }
        
        


    }
}
