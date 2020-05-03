using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextButton : MonoBehaviour
{
    public void NextScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
