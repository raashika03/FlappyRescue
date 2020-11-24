using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ScoreAddedEvent : UnityEvent<int> { }
public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    public GameObject play;
    private void Awake()
    {
        Instance = this;
    }
    public ScoreAddedEvent onScoreAdded = new ScoreAddedEvent();
    public float globalSpeed = 1f;
    private int totalScore = 0;
    public void AddScore(int scoreToAdd)
    {
        totalScore += scoreToAdd;
        onScoreAdded.Invoke(totalScore);
    }
    public void GameOver()
    {
        globalSpeed = 0f;
        play.SetActive(true);
    }
}
