using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorCorrupted : MonoBehaviour
{
    public Transform Player;

    private void Start()
    {
        Player = GameManager.Instance.player.GetComponent<Transform>();
    }

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
                        AudioManager.instance.PlayOneShot(FMODEvents.instance.elevatorButton, this.transform.position);
                        StartCoroutine(opening());
                    }
                }
            }

        }

    }

    IEnumerator opening()
    {
        print("Elevator Called");
        yield return new WaitForSeconds(.5f);
        AudioManager.instance.PlayOneShot(FMODEvents.instance.corruptedVoice, this.transform.position);
    }
}
