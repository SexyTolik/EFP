using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleColDetect : MonoBehaviour
{
    Image proigrish; // не забыть переработать скрипт
    private void OnTriggerEnter(Collider other)
    {
        proigrish = GameObject.Find("proigrish").GetComponent<Image>();
        proigrish.enabled = true;
        Time.timeScale = 0f;
    }
    
}
