using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] PLayerStats myStats;
    [SerializeField] TMP_Text titleText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(myStats.health == 0)
        {
            SceneManager.LoadScene("endScene");
            titleText.text = "You LOSE!";
        }
    }

    // Buttons for Game

    public void mainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }

    public void startGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void endGame()
    {
        Application.Quit();
    }
}
