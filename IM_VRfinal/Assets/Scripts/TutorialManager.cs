using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class TutorialManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject Holder1, Holder2;
    public GameObject Effect1, Effect2;
    public Vector3 Pos1, Pos2;
    public DialogueManager DM;
    private bool done1, done2;
    void Start()
    {
        Pos1 = Holder1.transform.position;
        Pos2 = Holder2.transform.position;
        Effect1.SetActive(true);
        Effect2.SetActive(true);

        done1 = false;
        done2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!done1 && Vector3.Distance(Player.transform.position, Pos1) < 5.0f)
        {
            DM.QDialogue.Enqueue("Dialogue Test");
            DM.QDialogue.Enqueue("This is Tutorial");
            DM.QDialogue.Enqueue("1234 1234");

            DM.CallRoutine("Please Enjoy!!");
            Effect1.SetActive(false);
            done1 = true;
        }

        if (!done2 && Vector3.Distance(Player.transform.position, Pos2) < 5.0f)
        {
            DM.QDialogue.Enqueue("wow you've looked around the whole map");
            DM.QDialogue.Enqueue("thanks for playing");
            DM.QDialogue.Enqueue("if you're interested in more,\nplease visit our museum");

            DM.CallRoutine("Bye!!!");
            Effect2.SetActive(false);
            done2 = true;
        }


    }
}
