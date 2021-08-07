using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : ASingleton<MenuManager>
{
    JSONData _jsonData;
    [SerializeField] GameObject InGameCanvas;
    [SerializeField] Text InGamePointText;
    [SerializeField] GameObject EndGameCanvas;
    [SerializeField] Text EndGameCurrentLevelText;
    [SerializeField] Text EndGameMaxLevelText;
    void Awake()
    {
      StartSingleton(this);
      _jsonData = GetComponent<JSONData>();
    }
    void Update()
    {
        if (PlayerManager.playerState != PlayerManager.PlayerState.EndMOD)
        {
            InGamePointText.text = GameManager.level.ToString();
            EndGameCanvas.SetActive(false);
            return;
        }
        EndGameCanvas.SetActive(true);
        SetTexts();
    }
    void SetTexts()
    {
        EndGameCurrentLevelText.text = GameManager.level.ToString();
        EndGameMaxLevelText.text = _jsonData.JSONRead().ToString();
    }
    
}
