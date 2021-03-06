using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    // Variables
    private const float END_SCREEN_TIME = 2.0f;

    public TimerScript timer;
    public EndScreenScript endScreen;
    public PlayerScript player;
    public GunScript gunToEquip; // Hacked code

    // Methods
    private IEnumerator WaitAndPrint(float waitTime) 
    {
        endScreen.GamePassed();
        endScreen.gameObject.SetActive(true);

        yield return new WaitForSeconds(waitTime);
        Debug.Log("Quitting");
        Application.Quit();

    }

    // Start is called before the first frame update
    void Start()
    {
        timer.Init();

        player.EquipGun(gunToEquip); // Hacked code
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space)) 
        {
            player.TakeDamage(1);
        }*/
        // Check if timer is out, if timer out, start coroutine to show text and then 
        if (timer.TimeIsUp()) 
        {
            endScreen.GamePassed();
            IEnumerator coroutine = WaitAndPrint(END_SCREEN_TIME);
            StartCoroutine(coroutine);
        }
        // Check if 0 lives
        if (player.IsAlive() == false) 
        {
            endScreen.GameFailed();
            IEnumerator coroutine = WaitAndPrint(END_SCREEN_TIME);
            StartCoroutine(coroutine);
        }
        
    }
}
