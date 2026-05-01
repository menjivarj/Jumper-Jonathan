using Unity.VectorGraphics;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goToGame()
    {
        SceneManager.LoadScene("gameplay");
    }

    public void goToMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }
}
