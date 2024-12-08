using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
   [SerializeField] private string nomeDoLevelDeJogo;
   [SerializeField] private GameObject painelMenuInicial;
   [SerializeField] private GameObject paineiConfiguracoes;

  public void Jogar()
    {
        SceneManager.LoadScene(nomeDoLevelDeJogo);
    }

    public void AbrirConfiguracoes()
    {
        painelMenuInicial.SetActive(false);
        paineiConfiguracoes.SetActive(true);
    }

    public void FecharConfiguracoes()
    {
        paineiConfiguracoes.SetActive(false);
        painelMenuInicial.SetActive(true);
    }

    public void SairJogo()
    {
        Debug.Log("Sair do jogo");
        Application.Quit();

    }
}
