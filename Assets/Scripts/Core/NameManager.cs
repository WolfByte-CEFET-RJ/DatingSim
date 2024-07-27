using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameManager : MonoBehaviour
{
    public Button confirmButton;

    private string playerName;

    private void OnEnable()
    {
        // Adiciona listener ao botão
        confirmButton.onClick.AddListener(ConfirmName);
    }
    private void GetText(string name)
    {
        // Registra o nome digitado
        Debug.Log("Typed name: " + name);
        playerName = name;
    }

    private void ConfirmName()
    {
        if (String.IsNullOrEmpty(playerName))
        {
            Debug.Log("No name input.");
        }
        else
        {
            // Salva o nome do jogador
            GameManager.Instance.playerName = playerName;
            Debug.Log("Chosen name: " + playerName);

            // Registra nome e gênero do jogador no arquivo de save
            SaveManager.Instance.SavePlayerInfo();

            // Carrega a próxima cena
            // PrefabUtility.SaveAsPrefabAsset(player,"Assets/player.prefab")
            GameManager.Instance.LoadNextScene("SampleScene");
        }
    }
}
