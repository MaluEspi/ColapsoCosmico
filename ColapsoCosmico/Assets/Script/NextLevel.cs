using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    FadeInOut fade;
    public string nextSceneName;
    public float delayBeforeLoad = 1f;

    private void Start()
    {
        fade = FindObjectOfType<FadeInOut>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica se o objeto que colidiu é o player
        {
            StartCoroutine(LoadSceneAfterFade());
        }
    }

    private IEnumerator LoadSceneAfterFade()
    {
        fade.FadeIn(); // Inicia o fade in
        yield return new WaitForSeconds(delayBeforeLoad); // Aguarda o tempo definido
        SceneManager.LoadScene(nextSceneName); // Carrega a próxima cena
    }
}