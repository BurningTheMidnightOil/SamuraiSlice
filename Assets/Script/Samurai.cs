using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Samurai : MonoBehaviour
{
    [SerializeField] string samuraiName;

    [SerializeField] GameObject topImage;
    [SerializeField] GameObject bottomImage;

    [SerializeField] GameObject teleportObject;

    void Start()
    {
        GameManager.Instance.call_OnEndClash_Events += ReactToEndClash;
        GameManager.Instance.call_OnDelayedDeath_Events += DelayedDeath;
    }

    void ReactToEndClash(string winner){
        Teleport();
    }

    void Win(){
        Teleport();
    }

    void Die(){
        Teleport();
    }

    public void SetColor(Color color){
        topImage.GetComponent<Image>().color = color;
        bottomImage.GetComponent<Image>().color = color;
    }

    void Teleport(){
        gameObject.GetComponent<RectTransform>().localPosition = teleportObject.GetComponent<RectTransform>().localPosition;
    }

    void DelayedDeath(string winner){
        if (winner != samuraiName)
        {
            SetColor(Color.red);
            topImage.GetComponent<RectTransform>().localPosition += new Vector3(38, 0, 0);
        }
    }
}
