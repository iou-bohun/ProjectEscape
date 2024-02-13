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
    public IEnumerator PopUpMonologue(string Monologue,float time)
    {
        GameObject box = Instantiate(monologuePanel,this.transform);
        box.GetComponentInChildren<TMP_Text>().text = Monologue;
        yield return new WaitForSeconds(time);
        Destroy(box);
    }
}
