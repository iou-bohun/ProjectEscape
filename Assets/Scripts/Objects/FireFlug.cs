using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{
	public class FireFlug : MonoBehaviour
	{

		public Animator openandclose;
		public bool open;
		public Transform Player;

        void Start()
		{
            Player = GameManager.Instance.transform;
            open = false;
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
								AudioManager.instance.PlayOneShot(FMODEvents.instance.cabinetOpened, this.transform.position);
								StartCoroutine(opening());
							}
						}
						else
						{
							if (open == true)
							{
								if (Input.GetMouseButtonDown(0))
								{
                                    AudioManager.instance.PlayOneShot(FMODEvents.instance.cabinetClosed, this.transform.position);
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
			openandclose.Play("FireflugOpening");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			print("you are closing the door");
			openandclose.Play("FireflugClosing");
			open = false;
			yield return new WaitForSeconds(.5f);
		}


	}
}