using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public GameObject scoreTextPrefab;
    public GameObject play;
    public Transform scoreTextParent;
    public Sprite[] numbers;  
    public Vector3 standbyPos = new Vector3(-15, 15); 
    public int maxDigits = 5; 
    private GameObject[] scoreTextPool;
    private int[] digits;
    void Start()
    {
        scoreTextPool = new GameObject[maxDigits];
        for (int i = 0; i < maxDigits; i++)
        {
            GameObject clone = Instantiate(scoreTextPrefab, scoreTextParent);
            Image img = clone.GetComponent<Image>();
            img.sprite = numbers[i];
            clone.name = i.ToString();
            scoreTextPool[i] = clone;
        }
        GameManager.Instance.onScoreAdded.AddListener(UpdateScore);
        UpdateScore(0);
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void UpdateScore(int score)
    {
        int[] digits = GetDigits(score);
        for (int i = 0; i < digits.Length; i++)
        {
            int value = digits[i];
            GameObject textElement = scoreTextPool[i];
            Image img = textElement.GetComponent<Image>();
            img.sprite = numbers[value];
            textElement.SetActive(true);
        }
        for (int i = digits.Length; i < scoreTextPool.Length; i++)
        {

            scoreTextPool[i].SetActive(false);
        }
    }
    int[] GetDigits(int number)
    {
        List<int> digits = new List<int>();
        while (number >= 10)
        {
            digits.Add(number % 10);
            number /= 10;
        }
        digits.Add(number);
        digits.Reverse();
        return digits.ToArray();
    }
}
