using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    private int totalScore = 0;
    [SerializeField] private GameObject text;

    public void Start()
    {
        totalScore = Game.Instance.nbKill;
        text.GetComponent<TextMeshProUGUI>().text = "Score : " + totalScore;

    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
}
