using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_Text TxtScore1, TxtScore2;
    static public int Score1;
    static public int Score2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // currentScore = Score;
        TxtScore1.text = "Player 1 Score: " + Score1;
        TxtScore2.text = "Player 2 Score: " + Score2;

        // end one score equals 100, transition to end screen
        if (Score1 == 100 || Score2 == 100)
        {
            SceneManager.LoadScene("End");
        }
    }
}
