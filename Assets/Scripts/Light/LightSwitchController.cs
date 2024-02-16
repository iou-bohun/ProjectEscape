using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchController : MonoBehaviour
{
    public Transform player;

    private void Start()
    {
        player = GameManager.Instance.player.GetComponent<Transform>();
    }


    void OnMouseOver()
    {
        {
            if (player)
            {
                float dist = Vector3.Distance(player.position, transform.position);
                if (dist < 5)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        AudioManager.instance.PlayOneShot(FMODEvents.instance.lightSwitchOnOff, this.transform.position);
                        switch (gameObject.name)
                        {
                            case "LivingRoomSwitch1":
                                LightManager.instance.CallLivingRoomLight();
                                break;
                            case "LivingRoomSwitch2":
                                LightManager.instance.CallLivingRoomLight2();
                                break;
                            case "BedRoomSwitch":
                                LightManager.instance.CallBedRoomLight();
                                break;
                            case "BathRoomSwitch":
                                LightManager.instance.CallBathRoomLight();
                                break;
                        }
                    }
                }
            }

        }
    }
}
