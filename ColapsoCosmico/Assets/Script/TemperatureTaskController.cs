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
    public GameObject valveCount;

    // Start is called before the first frame update
    void Start()
    {
        itemText.text = null;
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
                itemText.text = "Press (E) to collect the object " + hit.transform.GetComponent<ObjectType>().objectType.name;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    CollectItem(hit);
                }
            }
            else if (hit.collider.CompareTag("Camaras"))
            {
               
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
                Destroy(hit.transform.gameObject);
                break;
            }
        }
    }

    void RemoveItemFromInventory(RaycastHit hit)
    {
        string objectName = hit.transform.GetComponent<ObjectType>().objectType.name;

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] != null  && slotAmount[i] > 0)
            {
                slotAmount[i]--;
                if (slotAmount[i] == 0)
                {
                    
                    // Se a quantidade for zero, limpa o slot
                    slots[i] = null;
                    slotsImage[i].sprite = null; // Limpa a imagem do slot
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
}

