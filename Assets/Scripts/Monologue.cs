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
    public void CallMonologue(string mono, float time)
    {
        StartCoroutine(PopUpMonologue(mono, new WaitForSeconds(time)));
    }
    IEnumerator PopUpMonologue(string monologue,WaitForSeconds time)
    {
        GameObject box = Instantiate(monologuePanel,this.transform);
        box.GetComponentInChildren<TMP_Text>().text = monologue;
        yield return time;
        Destroy(box);
    }
}
