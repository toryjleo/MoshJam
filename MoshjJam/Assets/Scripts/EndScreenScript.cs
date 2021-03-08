using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreenScript : MonoBehaviour
{
    private const string failText = "Respawn Core Empty. Leaving Game";
    private const string winText = "Event Completed. Leaving.";

    public TMP_Text endGameText;


    // Method
    public void GameFailed() 
    {
        endGameText.text = failText;
    }

    public void GameWon()
    {
        endGameText.text = winText;
    }

    public void GamePassed() 
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
