using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class IntroDialog : MonoBehaviour
{
    public TextMeshProUGUI dialogText; // Referência ao componente de texto na tela.
    public List<string> phrases; // Lista de frases a serem exibidas.
    public float typingSpeed = 0.05f; // Velocidade de digitação (tempo entre cada caractere).

    private int currentPhraseIndex = 0; // Índice da frase atual.
    private Coroutine typingCoroutine; // Referência à corrotina de digitação em execução.
    FadeInOut fade;

    void Start()
    {
        if (phrases.Count > 0)
        {
            ShowPhrase(); // Exibe a primeira frase.
        }
        else
        {
            Debug.LogWarning("A lista de frases está vazia.");
        }
        fade = FindObjectOfType<FadeInOut>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) // Detecta o pressionar da tecla Enter.
        {
            if (typingCoroutine != null) // Verifica se a corrotina de digitação ainda está em execução.
            {
                StopCoroutine(typingCoroutine); // Para a corrotina de digitação.
                dialogText.text = phrases[currentPhraseIndex]; // Exibe a frase completa.
                typingCoroutine = null; // Reseta a corrotina.
            }
            else
            {
                NextPhrase(); // Passa para a próxima frase.
            }
        }
    }

    void ShowPhrase()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine); // Garante que nenhuma outra corrotina esteja em execução.
        }
        typingCoroutine = StartCoroutine(TypePhrase(phrases[currentPhraseIndex])); // Inicia a digitação da frase atual.
    }

    IEnumerator TypePhrase(string phrase)
    {
        dialogText.text = ""; // Limpa o texto antes de começar.
        foreach (char letter in phrase.ToCharArray())
        {
            dialogText.text += letter; // Adiciona uma letra por vez.
            yield return new WaitForSeconds(typingSpeed); // Aguarda antes de exibir a próxima letra.
        }
        typingCoroutine = null; // Marca a corrotina como concluída.
    }

    void NextPhrase()
    {
        currentPhraseIndex++;
        if (currentPhraseIndex < phrases.Count)
        {
            ShowPhrase(); // Exibe a próxima frase.
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
        SceneManager.LoadScene("Jogo"); // Carrega a próxima cena.
    }
}
