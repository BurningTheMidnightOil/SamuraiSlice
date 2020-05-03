using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashTalkBox : MonoBehaviour
{
    [SerializeField] Text textBox;
    [SerializeField] string samuraiName;
    [SerializeField] GameObject trashTalkTeleport;

    string[] provocations;
    string[] defeat;
    string[] victory;

    void Awake(){
        provocations = new string[] {
            "Omae wa mou shindeiru",
            "I hope your poetry is better than your sword, as you will need it.",
            "I thought you were stronger",
            "Time to end a legend",
            "Try to not miss the exit button! :P",
            "I will only use only 20 % of my power",
            "OOHHHHHHHHHHHHHHHH!",
            "Big deal…",
            "Get off my way, mosquito",
            "…",
            "NOTICE ME SENPAI",
            "I noticed your armor is weary",
            "Eat steel!",
            "I hope you made a testament",
            "It’s easier to use a guillotine, you know?",
            "INSERT CREATIVE TAUNT HERE: P",
            "A shinai fits you better",
            "Get back to work!Peasant",
            "You can’t touch this",
            "They sent only this ? Pathetic…",
            "You are going to have a bad time",
            "A new deliver of fertilizer arrived",
            "You need a permission to carry that",
            "Here is your delivery of death with extra pain"
        };

        defeat = new string[] {
            "Someone got duck tape?",
            "Medic!",
            "I underestimated you…",
            "Ughhh!",
            "Fought Bad, My resolution was weak, Poem Class would not Skip",
            "That was not how I intended to lose weight",
            "SENPAI NOTICED ME!",
            "Devs! NERF THIS!",
            "Crap, I forgot to make a dying speach!",
            "I can see my legs! Wait a moment…",
            "TÁ ZUADO!Oh wait… I got it wrong",
        };

        victory = new string[] { 
            "I feel sorry for the cleaning crew",
            "You need to train 1000 years before fighting me",
            "Don’t worry, You can’t disappoint me",
            "HUMILIATION!!!",
            "You mop the floor",
            "Another bites de dust…",
            "You trained all those years to die like this ? ...",
            "What a waste…",
            "This is what happens when you buy a sword with discount"
        };

        GameManager.Instance.call_OnProvocationTime_Events += ShowProvocation;
        GameManager.Instance.call_OnDelayedDeath_Events += ShowEndQuote;
    }

    void ShowProvocation(){
        StartCoroutine("ShowProvocationCoroutine");
    }

    IEnumerator ShowProvocationCoroutine(){
        textBox.text = provocations[Random.Range(0, provocations.Length)];
        yield return new WaitForSeconds(GameManager.Instance.GetProvocationTime());
        gameObject.SetActive(false);
    }

    void ShowEndQuote(string winner) {
        gameObject.SetActive(true);
        if(winner == samuraiName){
            ShowVictory();
        } else {
            ShowDefeat();
        }
    }

    void ShowDefeat(){
        textBox.text = defeat[Random.Range(0, defeat.Length)];
        Teleport();
    }

    void ShowVictory(){
        textBox.text = victory[Random.Range(0, victory.Length)];
        Teleport();
    }

    void Teleport(){
        gameObject.GetComponent<RectTransform>().localPosition = trashTalkTeleport.GetComponent<RectTransform>().localPosition;
    }
}
