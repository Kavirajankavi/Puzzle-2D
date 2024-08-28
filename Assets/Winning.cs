using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Winning : MonoBehaviour
{
    public int pointToWin;
    public int currentPoint;
    public GameObject puzzles;
    // Start is called before the first frame update
    void Start()
    {
        pointToWin = puzzles.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentPoint >= pointToWin) 
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void AddPoints() 
    {
        currentPoint++;
    }

    public void RemovePoints() 
    {
        if (currentPoint > 0)
        {
            currentPoint--;
        }
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
