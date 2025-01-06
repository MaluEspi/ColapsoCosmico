using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemperatureTaskManager : MonoBehaviour
{
    public GameObject tempBar;
    public Image healthBar;
    public float health;
    public float maxHealth;

    public float attackCost;
    public float chargeRate;
    public Vector3 respawn;

    private Coroutine recharge;

    private void OnTriggerStay(Collider other)
    {
        if( other.CompareTag("Temp"))
        {
            tempBar.SetActive(true);
            health -= attackCost;
            if (health == 0 )
            {
                Debug.Log("Respawn");
                health = 0;
                Respawn();
            }
            healthBar.fillAmount = health / maxHealth;
        }
        if(recharge != null)
        {
            StopCoroutine(recharge);
        }
        recharge = StartCoroutine(RechargeHealth());
       
    }
   
    private IEnumerator RechargeHealth()
    {
        yield return new WaitForSeconds(1f);

        while(health < maxHealth)
        {
            health += chargeRate / 10f;
            if(health > maxHealth)
            {
                health = maxHealth;
            }
            healthBar.fillAmount = health / maxHealth;
            yield return new WaitForSeconds(.1f);

        }
    }
    private void Respawn()
    {
        Debug.Log("respawn");
        transform.position = respawn; // Reinicia a posição do jogador
        health = maxHealth; // Restaura a vida
        
    }
}
