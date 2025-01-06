using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemperatureTaskController : MonoBehaviour
{
    public Objects[] slots;
    public Image[] slotsImage;
    public int[] slotAmount;

    public Text itemText;
    public Text itemCount;
    public Text noItemText;

    public GameObject valveCount;
    public GameObject cabinetTemp;
    public GameObject lightTemp;

    private int removedItensCount = 0;

    public GameObject tempBar;
    public Image healthBar;
    public float health;
    public float maxHealth;

    public float attackCost;
    public float chargeRate;
    public Vector3 respawn;

    private Coroutine recharge;

    public GameObject finishedTask;
    private bool objetoColetado;
    // Start is called before the first frame update
    void Start()
    {
        itemText.text = null;
        noItemText.text = "";
        slotAmount = new int[slots.Length];
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        if (Physics.Raycast(ray, out hit, 10f))
        {
            if (hit.collider.CompareTag("Object"))
            {
                itemText.text = "Pressione (E) para coletar o objeto " + hit.transform.GetComponent<ObjectType>().objectType.name;
                noItemText.text = "";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    CollectItem(hit);
                }
            }
            else if (hit.collider.CompareTag("Camaras"))
            {
                if (objetoColetado == true)
                {
                    itemText.text = "Pressione (E) para colocar os objetos"; 
                }
                else if ( objetoColetado == false)
                {
                    itemText.text = "Nenhum objeto foi coletado.";
                }
                noItemText.text = "";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    RemoveItemFromInventory(hit);
                }
               
            }
            else
            {
                itemText.text = null;
            }
        }

        // Atualiza o texto de contagem de itens
        UpdateItemCountText();
    }

    void CollectItem(RaycastHit hit)
    {
        itemCount.text = "";
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] == null || slots[i].name == hit.transform.GetComponent<ObjectType>().objectType.name)
            {
                if (slots[i] == null)
                {
                    slots[i] = hit.transform.GetComponent<ObjectType>().objectType;
                    slotsImage[i].sprite = slots[i].itemSprite;
                }
                slotAmount[i]++;
                objetoColetado = true;
                Destroy(hit.transform.gameObject);
                break;
            }
        }
    }

    void RemoveItemFromInventory(RaycastHit hit)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] != null && slotAmount[i] > 0)
            {
                slotAmount[i]--;
                removedItensCount++;
                if (slotAmount[i] == 0)
                {
                    // Se a quantidade for zero, limpa o slot
                    slots[i] = null;
                }

                if (removedItensCount >= 4)
                {
                    valveCount.SetActive(false); // desativa a imagem
                    lightTemp.SetActive(false); // desliga as luzes das salas
                    cabinetTemp.SetActive(true); // muda o sprite da camara
                    tempBar.SetActive(false); // desativa a barra de vida

                    finishedTask.SetActive(true);
                    
                }
                break; // Sai do loop após remover um item
            }
        }

    }
    void UpdateItemCountText()
    {
        itemCount.text = ""; // Limpa o texto anterior
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] != null)
            {
                valveCount.SetActive(true);
                itemCount.text += slots[i].name + ": " + slotAmount[i] + "/2 "; // Adiciona a contagem de cada item
            }

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Temp"))
        {
            tempBar.SetActive(true);
            health -= attackCost;
            if (health < 0)
            {
                health = 0;
                
            }
            if(health == 0)
            {
                Respawn();
            }
            healthBar.fillAmount = health / maxHealth;
        }
        if (recharge != null)
        {
            StopCoroutine(recharge);
        }
        recharge = StartCoroutine(RechargeHealth());

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Temp"))
        {
            tempBar.SetActive(false);
        }

    }

    private IEnumerator RechargeHealth()
    {
        yield return new WaitForSeconds(1f);

        while (health < maxHealth)
        {
            health += chargeRate / 10f;
            if (health > maxHealth)
            {
                health = maxHealth;
            }
            healthBar.fillAmount = health / maxHealth;
            yield return new WaitForSeconds(.1f);

        }
    }
    private void Respawn()
    {
        transform.position = respawn; // Reinicia a posição do jogador
        health = maxHealth; // Restaura a vida

    }
}

