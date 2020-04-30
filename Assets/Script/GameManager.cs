using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] float timeToReact = 3f;
    [SerializeField] float randomLowerTime = 2f;
    [SerializeField] float randomUpperTime = 4f;

    public delegate void OnStartDuel();
    public event OnStartDuel call_OnStartDuel_Events;
    public delegate void OnStartClash();
    public event OnStartClash call_OnStartClash_Events;

    public delegate void OnUpdateTime(float time);
    public event OnUpdateTime call_OnUpdateTime_Events;

    public delegate void OnEndClash();
    public event OnEndClash call_OnEndClash_Events;

    bool started = false;
    float timer;

    static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();

                if (_instance == null)
                {
                    _instance = new GameObject().AddComponent<GameManager>();
                }
            }

            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start(){
        StartCoroutine("PassOneSecond");
    }
    public void StopTimerOnClick()
    {
        Debug.Log("Time stopped");
        StopCoroutine("PassOneSecond");
        if (call_OnEndClash_Events != null)
        {
            call_OnEndClash_Events();
        }
    }

    IEnumerator PassOneSecond(){
        while(true){
            Debug.Log("One second has passed");
            if(started){
                timer += 1;
                if(call_OnUpdateTime_Events != null){
                    call_OnUpdateTime_Events(timer);
                }
                yield return new WaitForSeconds(0.01f);
            } else {
                float preparationTime = Random.Range(randomLowerTime, randomUpperTime);
                Debug.Log(preparationTime);
                yield return new WaitForSeconds(preparationTime);
                started = true;
                if (call_OnStartClash_Events != null)
                {
                    call_OnStartClash_Events();
                }
            }
        }
    }
}
