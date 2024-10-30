using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUI : MonoBehaviour
{
    public Text textUI;
    public InputField userNameUI;

    private void Start()
    {
        SetTextUI();
    }
    public void StartButton()
    {
        if (DataManager.Instance != null)
            DataManager.Instance.userName = userNameUI.text;
        SceneManager.LoadScene(1);
    }

    public void QuitButton()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit;
#endif
    }

    public void SetTextUI()
    {
        if(DataManager.Instance!=null)
            textUI.text = $"Best Score : {DataManager.Instance.bestUserName} : {DataManager.Instance.bestScore}";
    }
}
