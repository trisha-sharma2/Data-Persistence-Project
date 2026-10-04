using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_Text bestScoreText;

    void Start()
    {
        bestScoreText.text = GameManager.instance.BestLabel;
        
        bestScoreText.alignment = TextAlignmentOptions.Center;
    }

    public void StartNew()
    {
        GameManager.instance.playerName = nameInput.text;

        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #endif

        Application.Quit();
    }
}
