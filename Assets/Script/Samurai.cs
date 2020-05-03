using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Samurai : MonoBehaviour
{
    [SerializeField] string samuraiName;

    [SerializeField] GameObject topImage;
    [SerializeField] GameObject bottomImage;

    void Start()
    {
        GameManager.Instance.call_OnEndClash_Events += ReactToEndClash;
    }

    void ReactToEndClash(string winner){
        if(winner == samuraiName){
            Win();
        } else {
            Die();
        }
    }

    void Win(){

    }

    void Die(){
        SetColor(Color.red);
        topImage.GetComponent<RectTransform>().localPosition += new Vector3(38, 0, 0); 
    }

    public void SetColor(Color color){
        topImage.GetComponent<Image>().color = color;
        bottomImage.GetComponent<Image>().color = color;
    }
}
