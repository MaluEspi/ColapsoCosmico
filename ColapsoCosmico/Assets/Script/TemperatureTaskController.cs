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

            if (hit.collider.tag == "Object")
            {
                //  Debug.Log("Raycast funcionando");
                itemText.text = "Press (E) to collect the  object " + hit.transform.GetComponent<ObjectType>().objectType.name;
                if (Input.GetKeyDown(KeyCode.E))
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
            }
            else if (hit.collider.tag != "Object")
            {
                itemText.text = null;
            }
            if (hit.collider.tag == "Camaras")
            {
                itemText.text = "Press (E) to put the  object " + hit.transform.GetComponent<ObjectType>().objectType.name;
                if (Input.GetKeyDown(KeyCode.E))
                {

                }
                }
            }
        // Atualiza o texto de contagem de itens
        UpdateItemCountText();
    }

    void UpdateItemCountText()
    {
        itemCount.text = ""; // Limpa o texto anterior
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] != null)
            {
                valveCount.SetActive(true);
                itemCount.text += slots[i].name + ":" + slotAmount[i]  + "/2 "; // Adiciona a contagem de cada item
            }
        }

    }
}
