using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [Header("InGamePanel")]
    public GameObject InGamePanel;
    public TMP_Text MoneyText;
    public TMP_Text ChildCountText;
    public Button StartButton;
    void Start()
    {
        StartButton.onClick.AddListener(StartGame);
    }

    private void OnDisable()
    {
        StartButton.onClick.RemoveListener(StartGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartGame()
    {
        GameManager.Instance.GameState = GameState.PLAY;
        GameManager.Instance.PlayerController.StartStatus();
        StartButton.gameObject.SetActive(false);
    }
}
