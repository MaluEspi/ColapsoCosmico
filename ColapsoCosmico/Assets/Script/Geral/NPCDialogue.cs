using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCDialogue : MonoBehaviour
{
    [Header("Dialogue UI Components")]
    public GameObject dialoguePanel; 
    public Image npcImage; 
    public TextMeshProUGUI dialogueText; 
    public GameObject endImage; 
    [Header("Dialogue Settings")]
    public Sprite npcSprite; 
    [TextArea(2, 5)]
    public List<string> npcDialogueLines; 

    private int currentLineIndex = 0; 
    private bool isDialogueActive = false; 
    private bool isMouseOverNPC = false; 
    private bool isEndImageShown = false; 

    void Start()
    {
        dialoguePanel.SetActive(false); 

        if (endImage != null)
        {
            endImage.SetActive(false);
        }
    }

    void Update()
    {
        if (isMouseOverNPC && Input.GetKeyDown(KeyCode.E) && !isDialogueActive)
        {
            StartDialogue();
        }

        if (isDialogueActive && Input.GetKeyDown(KeyCode.Space))
        {
            if (isEndImageShown)
            {
                EndDialogue();
            }
            else
            {
                NextDialogueLine();
            }
        }
    }

    void StartDialogue()
    {
        isDialogueActive = true;
        dialoguePanel.SetActive(true);
        npcImage.sprite = npcSprite;
        currentLineIndex = 0;
        dialogueText.text = npcDialogueLines[currentLineIndex];
    }

    void NextDialogueLine()
    {
        currentLineIndex++;

        if (currentLineIndex < npcDialogueLines.Count)
        {
            dialogueText.text = npcDialogueLines[currentLineIndex];
        }
        else if (endImage != null) 
        {
            ShowEndImage();
        }
        else
        {
            EndDialogue(); 
        }
    }

    void ShowEndImage()
    {
        dialogueText.gameObject.SetActive(false); 
        endImage.SetActive(true); 
        isEndImageShown = true;
    }

    void EndDialogue()
    {
        isDialogueActive = false;
        dialoguePanel.SetActive(false);

        if (endImage != null)
        {
            endImage.SetActive(false); 
        }

        dialogueText.gameObject.SetActive(true); 
        isEndImageShown = false;
    }

    private void OnMouseEnter()
    {
        isMouseOverNPC = true;
    }

    private void OnMouseExit()
    {
        isMouseOverNPC = false;
    }
}
