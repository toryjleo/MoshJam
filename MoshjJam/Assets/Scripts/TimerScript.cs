using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    private const float MAX_TIME = 5.0f;
    public float curTime;

    private bool timeIsUp;

    private TMP_Text m_TextComponent;

    // Methods
    public void Init()
    {
        curTime = MAX_TIME;
        timeIsUp = false;
    }

    public bool TimeIsUp() 
    {
        return timeIsUp;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_TextComponent = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (curTime <= 0)
        {
            timeIsUp = true;
            // End the game
        }
        else 
        {
            curTime -= Time.deltaTime;
            m_TextComponent.text = curTime.ToString();
        }
    }
}
