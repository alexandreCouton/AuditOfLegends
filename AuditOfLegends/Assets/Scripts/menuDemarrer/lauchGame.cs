using UnityEngine;
using UnityEngine.SceneManagement;

public class lauchGame : MonoBehaviour
{

    [SerializeField] private string sceneName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void exit()
    {
        Application.Quit();
        Debug.Log("Exit");
    }

}
