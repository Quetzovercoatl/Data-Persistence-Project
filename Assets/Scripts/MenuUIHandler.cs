using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField TextInput;

    // Start is called before the first frame update
    void Start()
    {
        TextInput.text = DataManager.Instance.PlayerName;
    }

    // Update is called once per frame
    void Update()
    {
        DataManager.Instance.PlayerName = TextInput.text;

    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        DataManager.Instance.SaveBestScore();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }
}
