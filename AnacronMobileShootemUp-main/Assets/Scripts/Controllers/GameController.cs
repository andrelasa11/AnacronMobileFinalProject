using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    //private
    private int playerScore;

    private void Awake()
    {
        Instance = this;
    }

    public void OnDie(GameObject deadObject, int score = 0)
    {
        playerScore += score;
        Debug.LogFormat("GameController: {0} has died! Adding score {1}, total: {2}", deadObject.name, score, playerScore);
    }
}
