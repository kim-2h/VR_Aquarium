using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class TutorialManager : MonoBehaviour
{
    public GameObject Player, PlayerReal;
    public GameObject Holder1, Holder2, dest1, dest2;
    public GameObject Floor1, Floor2;
    public GameObject Effect1, Effect2;
    public Vector3 Pos1, Pos2, Pos3, Pos4, Dest1, Dest2;
    public DialogueManager DM;
    private bool done1, done2;
    public bool CoolDown = false;
    void Start()
    {
        Pos1 = Holder1.transform.position;
        Pos2 = Holder2.transform.position;
        Pos3 = Floor1.transform.position;
        Pos4 = Floor2.transform.position;
        Dest1 = dest1.transform.position;
        Dest2 = dest2.transform.position;

        Effect1.SetActive(true);
        Effect2.SetActive(true);

        done1 = false;
        done2 = false;
    }

    void Update()
    {
        
        if (!done1 && Vector3.Distance(Player.transform.position, Pos1) < 3.0f)
        {
            DM.QDialogue.Enqueue("Welcome there!\nFeel free to explore!");
            DM.QDialogue.Enqueue("Press the buttons to discover fascinating information about each marine animal.");
            DM.QDialogue.Enqueue("Each time you interact with a species,");
            DM.QDialogue.Enqueue("you'll earn a model of the animal to display proudly on your personal achievement board!");
            DM.QDialogue.Enqueue("To place your model on the achievement board, simply click and hold the model to pick it up,");
            DM.QDialogue.Enqueue("drag it to your desired spot on the board, and release to set it in place!");
            DM.QDialogue.Enqueue("You can move around the aquarium freely,"+
            "or teleport to specific locations"); 
            DM.QDialogue.Enqueue("by pointing at the colorful portals on the ground and selecting them to teleport!");

            DM.CallRoutine("Please Enjoy!!");
            Effect1.SetActive(false);
            AudioManager.Instance.PlaySFX(1);
            done1 = true;
        }

        if (!done2 && Vector3.Distance(Player.transform.position, Pos2) < 3.0f)
        {
            DM.QDialogue.Enqueue("wow you've looked around the whole map");
            DM.QDialogue.Enqueue("thanks for playing");
            DM.QDialogue.Enqueue("if you're interested in more,\nplease visit our museum");

            DM.CallRoutine("Bye!!!");
            Effect2.SetActive(false);
            AudioManager.Instance.PlaySFX(1);
            done2 = true;
        }

        if (!CoolDown && Vector3.Distance(Player.transform.position, Pos3) < 3.0f) //1층->2층
        {
            StartCoroutine(Cooldown(5.0f));
            PlayerReal.transform.position = Dest2;
            AudioManager.Instance.PlaySFX(1);
        }

        if (!CoolDown && Vector3.Distance(Player.transform.position, Pos4) < 3.0f) //2층->1층
        {
            StartCoroutine(Cooldown(5.0f));
            PlayerReal.transform.position = Dest1;
            AudioManager.Instance.PlaySFX(1);
        }


    }

    IEnumerator Cooldown(float time)
    {
        CoolDown = true;
        yield return new WaitForSeconds(time);
        CoolDown = false;
    }

}
