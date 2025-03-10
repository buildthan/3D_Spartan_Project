using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerConditions : MonoBehaviour
{
    public Image HealthUI;

    public float curHealth;
    public float maxHealth;
    public float startHealth;
    public float passiveHealth;

    public void Start()
    {
        curHealth = startHealth;
    }

    public void FixedUpdate()
    {
        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }

        if(curHealth < 0)
        {
            curHealth = 0;
        }

        if( curHealth <= maxHealth) //패시브 체력 회복량
        {
            curHealth += passiveHealth * Time.deltaTime;
        }


        HealthUI.fillAmount = curHealth / maxHealth;

    }

}
