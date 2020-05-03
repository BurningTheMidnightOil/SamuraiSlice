using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashTalkBox : MonoBehaviour
{
    [SerializeField] Text textBox;
    [SerializeField] string samuraiName;
    //List<string> provocations;
    //List<string> defeat;
    //List<string> victory;

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
        GameManager.Instance.call_OnEndClash_Events += ShowEndQuote;
    }
    void Start()
    {
        /* 
        provocations.Add("Omae wa mou shindeiru");
        provocations.Add("I hope your poetry is better than your sword, as you will need it.");
        provocations.Add("I thought you were stronger");
        provocations.Add("Time to end a legend");
        provocations.Add("Try to not miss the exit button! :P");
        provocations.Add("I will only use only 20 % of my power");
        provocations.Add("OOHHHHHHHHHHHHHHHH!");
        provocations.Add("Big deal…");
        provocations.Add("Get off my way, mosquito");
        provocations.Add("…");
        provocations.Add("NOTICE ME SENPAI");
        provocations.Add("I noticed your armor is weary");
        provocations.Add("Eat steel!");
        provocations.Add("I hope you made a testament");
        provocations.Add("It’s easier to use a guillotine, you know?");
        provocations.Add("INSERT CREATIVE TAUNT HERE: P");
        provocations.Add("A shinai fits you better");
        provocations.Add("Get back to work!Peasant");
        provocations.Add("You can’t touch this");
        provocations.Add("They sent only this ? Pathetic…");
        provocations.Add("You are going to have a bad time");
        provocations.Add("A new deliver of fertilizer arrived");
        provocations.Add("You need a permission to carry that");
        provocations.Add("Here is your delivery of death with extra pain");

        defeat.Add("Someone got duck tape?");
        defeat.Add("Medic!");
        defeat.Add("I underestimated you…");
        defeat.Add("Ughhh!");
        defeat.Add("Fought Bad, My resolution was weak, Poem Class would not Skip");
        defeat.Add("That was not how I intended to lose weight");
        defeat.Add("SENPAI NOTICED ME!");
        defeat.Add("Devs! NERF THIS!");
        defeat.Add("Crap, I forgot to make a dying speach!");
        defeat.Add("I can see my legs! Wait a moment…");
        defeat.Add("TÁ ZUADO!Oh wait… I got it wrong");

        victory.Add("I feel sorry for the cleaning crew");
        victory.Add("You need to train 1000 years before fighting me");
        victory.Add("Don’t worry, You can’t disappoint me");
        victory.Add("HUMILIATION!!!");
        victory.Add("You mop the floor");
        victory.Add("Another bites de dust…");
        victory.Add("You trained all those years to die like this ? ...");
        victory.Add("What a waste…");
        victory.Add("This is what happens when you buy a sword with discount");*/
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
    }

    void ShowVictory(){
        textBox.text = victory[Random.Range(0, victory.Length)];
    }
}
