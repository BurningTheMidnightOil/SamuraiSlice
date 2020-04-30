using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtonListener : MonoBehaviour
{
    public void BackToMainMenu(){
        SceneManager.LoadScene(0);
    }
}
