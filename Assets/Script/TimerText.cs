using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerText : MonoBehaviour
{
    [SerializeField] Text timerText;
    void Start()
    {
        timerText.text = "";
        GameManager.Instance.call_OnUpdateTime_Events += UpdateTimer;
        GameManager.Instance.call_OnEndClash_Events += ChangeColor;
    }

    
    void UpdateTimer(float time){
        //timerText.text = time.ToString("#.00");
        timerText.text = (time).ToString();
    }

    void ChangeColor(){
        timerText.color = Color.black;
    }
}
