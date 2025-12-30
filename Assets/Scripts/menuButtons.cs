using UnityEngine;
using UnityEngine.SceneManagement;

public class menuButtons : MonoBehaviour
{
    public void playGame()
    {
        Debug.Log("start!");
        SceneManager.LoadScene(1);//1 - основная сцене игры
    }
    public void exitGame()
    {
        Debug.Log("exit");


        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

        #else
        Application.Quit();
        #endif
    }
}
