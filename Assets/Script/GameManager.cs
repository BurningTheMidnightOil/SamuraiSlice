using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] int timeToReact = 30;
    [SerializeField] float randomLowerTime = 2f;
    [SerializeField] float randomUpperTime = 4f;
    [SerializeField] GameObject enemyGameObject;

    [SerializeField] List<EnemyInfo> enemies;

    int enemyIdx = 0;

    string winnerOfClash;
    bool started = false;
    bool counting = false;
    int timer;

    public delegate void OnStartDuel();
    public event OnStartDuel call_OnStartDuel_Events;
    public delegate void OnStartClash();
    public event OnStartClash call_OnStartClash_Events;

    public delegate void OnUpdateTime(float time);
    public event OnUpdateTime call_OnUpdateTime_Events;

    public delegate void OnEndClash(string winner);
    public event OnEndClash call_OnEndClash_Events;

    public delegate void OnEndSequence(string winner);
    public event OnEndSequence call_OnEndSequence_Events;

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
        if (call_OnStartDuel_Events != null)
        {
            call_OnStartDuel_Events();
        }
        StartCoroutine("MainLoop");
    }
    public void PlayerClick()
    {
        if(started){
            EndClash("player");
        } else if(counting) {
            EndClash("enemy");
        }
    }

    void EndClash(string winner){
        if(winnerOfClash == null){
            winnerOfClash = winner;
            StopCoroutine("MainLoop");
            StartCoroutine("EndSequence");
            if (call_OnEndClash_Events != null)
            {
                call_OnEndClash_Events(winner);
            }
        }
    }

    IEnumerator MainLoop(){

        //Set enemy
        NextEnemy();

        //Stop spamming logic
        yield return new WaitForSeconds(3f);
        counting = true;

        while(true){
            if(started){
                if(timer >= timeToReact){
                    EndClash("enemy");
                    yield return null;
                } else {
                    timer += 1;
                    if(call_OnUpdateTime_Events != null){
                        call_OnUpdateTime_Events(timer);
                    }
                    yield return new WaitForSeconds(0.01f);
                }
            } else {
                float preparationTime = Random.Range(randomLowerTime, randomUpperTime);
                yield return new WaitForSeconds(preparationTime);
                started = true;
                if (call_OnStartClash_Events != null)
                {
                    call_OnStartClash_Events();
                }
            }
        }
    }

    IEnumerator EndSequence(){
        yield return new WaitForSeconds(1f);
        call_OnEndSequence_Events(winnerOfClash);
    }

    void NextEnemy(){
        Samurai enemy = enemyGameObject.GetComponent<Samurai>();        
        Color enemyColor = new Color(enemies[enemyIdx].r, enemies[enemyIdx].g, enemies[enemyIdx].b);
        enemy.SetColor(enemyColor);    
        timeToReact = enemies[enemyIdx].timeToReact;
        enemyIdx++;
    }
}
