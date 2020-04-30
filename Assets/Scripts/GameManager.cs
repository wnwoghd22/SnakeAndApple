using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void GoToTitle() => SceneManager.LoadScene("Title");
    public void GoToGameScene() => SceneManager.LoadScene("Game");
    public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
