using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Samurai : MonoBehaviour
{
    [SerializeField] string name;

    [SerializeField] GameObject topImage;
    [SerializeField] GameObject bottomImage;
    void Start()
    {
        GameManager.Instance.call_OnEndClash_Events += ReactToEndClash;
    }

    void ReactToEndClash(string winner){
        if(winner == name){
            Win();
        } else {
            Die();
        }
    }

    void Win(){

    }

    void Die(){
        topImage.GetComponent<Image>().color = Color.red;
        bottomImage.GetComponent<Image>().color = Color.red;

        topImage.GetComponent<RectTransform>().localPosition += new Vector3(38, 0, 0); 
    }
}
