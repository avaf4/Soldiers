using TMPro;
using UnityEngine;

public class End : MonoBehaviour
{
    public TMP_Text Winner;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Score1 == 100)
        {
            Winner.text = "Player 1 Wins!";
        }
        if (GameManager.Score2 == 100) {
            Winner.text = "Player 2 Wins!";
        }
    }
    }
