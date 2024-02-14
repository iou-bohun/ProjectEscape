using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Monologue : MonoBehaviour
{
    public static Monologue i;
    [SerializeField] GameObject monologuePanel;
    private void Awake()
    {
        i = this;
    }
    public void ET(Talk[] talk)
    {
        StartCoroutine(CallMonologue(talk));
    }
    IEnumerator CallMonologue(Talk[] talk)
    {
        for (int i = 0; i < talk.Length; i++)
        {
            StartCoroutine(PopUpMonologue(talk[i].mono, new WaitForSeconds(talk[i].stayTime)));
            yield return new WaitForSeconds(talk[i].waitTime);
        }
    }
    IEnumerator PopUpMonologue(string monologue,WaitForSeconds time)
    {
        GameObject box = Instantiate(monologuePanel,this.transform);
        box.GetComponentInChildren<TMP_Text>().text = monologue;
        yield return time;
        Destroy(box);
    }
}
