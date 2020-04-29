using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{   
    [SerializeField] Text timerText;
    [SerializeField] float initialTime = 3f;
    [SerializeField] float randomLowerTime = 2f;
    [SerializeField] float randomUpperTime = 4f;
    bool started = false;
    float timer; 
    void Start(){
        timer = initialTime;
        StartCoroutine("PassOneSecond");
    }
    public void StopTimerOnClick()
    {
        Debug.Log("Time stopped");
        StopCoroutine("PassOneSecond");
    }

    IEnumerator PassOneSecond(){
        while(true){
            Debug.Log("One second has passed");
            timer -= 0.01f;
            timerText.text = timer.ToString("#.00");
            if(started){
                yield return new WaitForSeconds(0.01f);
            } else {
                started = true;
                float preparationTime = Random.Range(randomLowerTime, randomUpperTime);
                Debug.Log(preparationTime);
                yield return new WaitForSeconds(preparationTime);
            }
        }
    }
}
