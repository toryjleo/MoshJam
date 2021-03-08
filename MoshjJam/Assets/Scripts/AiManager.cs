using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiManager : MonoBehaviour
{
    public GameObject player;
    public GameObject Ai_Prefab;
    private List<Ai_Enemy> AiPool;
    public int SpawnRate;
    public int FirstWave; // number of AI starting to spawn 
    public Vector3 PlayerV;
    private Vector3 SpawnPoint; 


    // Start is called before the first frame update
    void Start()
    {
        AiPool = new List<Ai_Enemy>();

        for(int i =0; i < FirstWave; i++)
        {   
            //This creates a list of game objects and adds them to the scene,
            //Then the Ai Componenets are extracted and put into a List called AiPool 
            GameObject newAI = Instantiate(Ai_Prefab, SpawnPoint, Quaternion.identity);
            AiPool.Add(newAI.GetComponent<Ai_Enemy>());
        }
        

        foreach (Ai_Enemy Ai in AiPool)
        {
            Ai.Start(); 
            Ai.Spawn();
            

                
        }

    }

    // Update is called once per frame
    void Update()
    {
        PlayerV = player.transform.position;

        foreach (Ai_Enemy Ai in AiPool)
        {
            if (Ai.IsAlive() == false)
            {
                Ai.gameObject.SetActive(false);
                Debug.Log("AI DEATH");
            }
            Ai.GivePlayerLocation(PlayerV);
            
 

        }
    }
}
