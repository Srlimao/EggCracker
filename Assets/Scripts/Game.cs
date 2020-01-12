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
    [SerializeField] GameObject blockGroup;
    [SerializeField] int breakableBlocks;//debug
    [Range(0.1f,10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] Text scoreField;


    int playerScore = 0;


    private void Start()
    {
        if(SceneManager.GetActiveScene().name== sceneCoreName)
        {
            Cursor.lockState = CursorLockMode.Locked;
            CheckBlocks();
        }
        else Cursor.lockState = CursorLockMode.None;

        
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
        if(SceneManager.GetActiveScene().name == sceneCoreName)
        {
            CheckBlocks();
            CheckEndGame();
            Time.timeScale = gameSpeed;
            scoreField.text = playerScore + " points";
        }

        scoreField.text = playerScore + " points";

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

    private void CheckBlocks()
    {
        breakableBlocks = blockGroup.GetComponentsInChildren<ScriptBlock>().Length;
    }

    private void CheckEndGame()
    {
        if (breakableBlocks <= 0)
        {
            LoadEndScene();
        }
        
    }

    public void AddPoints(int points)
    {
        playerScore += points;
    }

}
