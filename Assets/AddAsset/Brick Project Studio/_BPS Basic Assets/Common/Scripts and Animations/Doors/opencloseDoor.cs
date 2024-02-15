﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SojaExiles

{
	public class opencloseDoor : MonoBehaviour
	{

		public Animator openandclose;
		public bool open;
		private Transform Player;

        void Start()
		{
			open = false;
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
						if (open == false)
						{
							if (Input.GetMouseButtonDown(0))
							{
								if(SceneManager.GetActiveScene().name == "6stEventScene") GameManager.Instance.cancelLoof=true;
								StartCoroutine(opening());
							}
						}
						else
						{
							if (open == true)
							{
								if (Input.GetMouseButtonDown(0))
								{
									StartCoroutine(closing());
								}
							}

						}

					}
				}

			}

		}

		IEnumerator opening()
		{
			print("you are opening the door");
			openandclose.Play("Opening");
			AudioManager.instance.PlayOneShot(FMODEvents.instance.doorOpened, this.transform.position);
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			print("you are closing the door");
			openandclose.Play("Closing");
			AudioManager.instance.PlayOneShot(FMODEvents.instance.doorClosed, this.transform.position);
			open = false;
			yield return new WaitForSeconds(.5f);
		}


	}
}