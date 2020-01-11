using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] string sceneStartName;
    [SerializeField] string sceneCoreName;
    [SerializeField] string sceneOverName;

    private void Start()
    {
        if(SceneManager.GetActiveScene().name== sceneCoreName)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }else Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    public void LoadFirstScene()
    {
        SceneManager.LoadScene(sceneStartName);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(sceneCoreName);
    }

    public void LoadEndScene()
    {
        SceneManager.LoadScene(sceneOverName);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
