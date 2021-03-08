using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_Enemy : PawnScript
{

    private Vector3 VtoPlayer;
    public GameObject gun; 

    public void Spawn() //Spawns AI at coordinator 
    {
        float spawnY = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        float spawnX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

        Vector3 spawnPoint = new Vector3(spawnX, 0, spawnY);
        transform.position = spawnPoint;

    }

    public void GivePlayerLocation(Vector3 P_Location)
    {
        VtoPlayer = P_Location - this.transform.position; //This points to the player 
        VtoPlayer.Normalize(); //Normalizes vector to be relative to 1 
    }



    // Start is called before the first frame update
    void Start()
    {    
        movementSpeed = 2;
        base.Start();

    }

    

    // Update is called once per frame
    void Update()
    {
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
