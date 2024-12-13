using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dText;    
    private TextMeshProUGUI TargetText;
    public GameObject Panel;    
    public GameObject Profile;
    public bool IsDialoguePlaying { get; set; }
    public Queue<string> QDialogue = new Queue<string>();
    
    void Start()
    {
        // QDialogue.Enqueue("Dialogue Test");
        // QDialogue.Enqueue("This is Tutorial");
        // QDialogue.Enqueue("1234 1234");

        // CallRoutine("Please Enjoy!!");
    }

   public IEnumerator PlayDialogue(string dialogue)
    {
        if (QDialogue.Count == 0) QDialogue.Enqueue(dialogue);
        else if (QDialogue.Peek() != dialogue) QDialogue.Enqueue(dialogue);
        Debug.Log("now on peak: " + QDialogue.Peek());
        
        dialogue = QDialogue.Peek();
        TargetText = dText;
        TargetText.text = dialogue;
        dText.text = "";
        yield return new WaitForSeconds(0.1f);
        IsDialoguePlaying = true;
        Profile.SetActive(true);
        Panel.SetActive(true);
        //yield return new WaitForSeconds(1f);
        StartCoroutine(PanelEffect(0.5f));
        for (int i = 0; i < dialogue.Length; i++)
        {
            dText.text += dialogue[i];

            if (dialogue[i] == '.' || dialogue[i] == '?' || dialogue[i] == '!' || dialogue[i] == ' ')
            {
                yield return new WaitForSeconds(0.1f);
            }
            else
            {
                yield return new WaitForSeconds(0.05f);
            }
            
        }

        
        QDialogue.Dequeue();
        yield return new WaitForSeconds(1f);
        if (QDialogue.Count > 0)
        {
            StartCoroutine(PlayDialogue(QDialogue.Peek()));
        }


        //StopDialogue = false;
        
        IsDialoguePlaying = false;
        Panel.SetActive(false);
        Profile.SetActive(false);
    }

    public IEnumerator PanelEffect(float time)
    {
        GameObject panel = Panel;
        Vector3 initialScale = panel.transform.localScale;

      
        float scaleUpTime = time*0.5f;   
        float scaleDownTime = time*0.5f; 

        panel.transform.localScale = initialScale * 0.8f;

        float elapsedTime = 0f;
        while (elapsedTime < scaleUpTime)
        {
            panel.transform.localScale = Vector3.Lerp(initialScale * 0.8f, initialScale * 1.1f, elapsedTime / scaleUpTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        panel.transform.localScale = initialScale * 1.1f;

        elapsedTime = 0f;
        while (elapsedTime < scaleDownTime)
        {
            panel.transform.localScale = Vector3.Lerp(initialScale * 1.1f, initialScale, elapsedTime / scaleDownTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        panel.transform.localScale = initialScale;
    }


    public void CallRoutine(string dialogue)
    {
        StartCoroutine(PlayDialogue(dialogue));
    }
}
