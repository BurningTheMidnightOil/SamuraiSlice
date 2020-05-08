using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtonListener : MonoBehaviour
{
    public void BackToMainMenu(){
        PlayerState.Instance.enemyIdx = 0;
        SceneManager.LoadScene(0);
    }
}
