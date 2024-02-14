using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LightController : MonoBehaviour
{
    public List<LightObject> lights;
    public Transform Player;

    void OnMouseOver()
    {
        {
            if (Player)
            {
                float dist = Vector3.Distance(Player.position, transform.position);
                if (dist < 5)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        Debug.Log(gameObject.name);
                        if(gameObject.name == "Lamp1")
                        SelectLight(0);
                        SelectLight(1);
                    }
                }
            }

        }

    }
    public void SelectLight(int index)
    {
        lights[index].OnOffLight();
    }
}
