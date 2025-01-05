using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class IntroDialog : MonoBehaviour
{
    public TextMeshProUGUI dialogText; // Refer�ncia ao componente de texto na tela.
    public List<string> phrases; // Lista de frases a serem exibidas.
    public float typingSpeed = 0.05f; // Velocidade de digita��o (tempo entre cada caractere).

    private int currentPhraseIndex = 0; // �ndice da frase atual.
    private Coroutine typingCoroutine; // Refer�ncia � corrotina de digita��o em execu��o.
    FadeInOut fade;

    void Start()
    {
        if (phrases.Count > 0)
        {
            ShowPhrase(); // Exibe a primeira frase.
        }
        else
        {
            Debug.LogWarning("A lista de frases est� vazia.");
        }
        fade = FindObjectOfType<FadeInOut>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) // Detecta o pressionar da tecla Enter.
        {
            if (typingCoroutine != null) // Verifica se a corrotina de digita��o ainda est� em execu��o.
            {
                StopCoroutine(typingCoroutine); // Para a corrotina de digita��o.
                dialogText.text = phrases[currentPhraseIndex]; // Exibe a frase completa.
                typingCoroutine = null; // Reseta a corrotina.
            }
            else
            {
                NextPhrase(); // Passa para a pr�xima frase.
            }
        }
    }

    void ShowPhrase()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine); // Garante que nenhuma outra corrotina esteja em execu��o.
        }
        typingCoroutine = StartCoroutine(TypePhrase(phrases[currentPhraseIndex])); // Inicia a digita��o da frase atual.
    }

    IEnumerator TypePhrase(string phrase)
    {
        dialogText.text = ""; // Limpa o texto antes de come�ar.
        foreach (char letter in phrase.ToCharArray())
        {
            dialogText.text += letter; // Adiciona uma letra por vez.
            yield return new WaitForSeconds(typingSpeed); // Aguarda antes de exibir a pr�xima letra.
        }
        typingCoroutine = null; // Marca a corrotina como conclu�da.
    }

    void NextPhrase()
    {
        currentPhraseIndex++;
        if (currentPhraseIndex < phrases.Count)
        {
            ShowPhrase(); // Exibe a pr�xima frase.
        }
        else
        {
            StartCoroutine(LoadNextSceneWithFade());
        }
    }

    IEnumerator LoadNextSceneWithFade()
    {
        fade.FadeIn();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Jogo"); // Carrega a pr�xima cena.
    }
}
