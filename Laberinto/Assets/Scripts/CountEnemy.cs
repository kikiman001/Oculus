using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountEnemy : MonoBehaviour
{
    public Text textScore;
    public Text timeText;
    public static int countEnemy=0;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        countEnemy = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float elapsedTime = Time.time - startTime;
        timeText.text = "Tiempo: " + Mathf.Floor(elapsedTime).ToString() + "s";
        textScore.text = "Score:" + Mathf.Round(countEnemy);
    }
}
