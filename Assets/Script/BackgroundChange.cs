using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundChange : MonoBehaviour
{
    [SerializeField] Image background;
    void Start()
    {
        GameManager.Instance.call_OnStartClash_Events += ChangeColorToBlack;
        GameManager.Instance.call_OnEndClash_Events += ChangeColorToWhite;
    }

    void ChangeColorToBlack() {
        background.color = Color.black;
    }
   
    void ChangeColorToWhite(){
        background.color = Color.white;
    }
}
