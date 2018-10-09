using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {

    [SerializeField] float sceneLoadDelay = 3f;

	public void LoadStartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void LoadLeve01()
    {
        SceneManager.LoadScene("Level01");
    }

    public void LoadGameOver()
    {

        StartCoroutine(WaitAndLoad());
        
    }

    private IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(sceneLoadDelay);
        SceneManager.LoadScene("GameOver");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
