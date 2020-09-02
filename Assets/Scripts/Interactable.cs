using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
	[SerializeField]bool m_good;
	[SerializeField]bool m_enableObject;
	[SerializeField]bool m_dagger;
	[SerializeField]List<GameObject> m_objectsToEnable = new List<GameObject>(); 

	public void Interact()
	{
		if (m_dagger == true)
		{
			HUDManager.Instance.SetClickActive(true);
			ShootController.Instance.CanShoot = true;
			Destroy(this.gameObject); //fade effect
			return;
		}

		if (m_good == true)
		{
			if (m_enableObject)
			{
				for (int i = 0; i < m_objectsToEnable.Count; i++)
				{
					m_objectsToEnable[i].SetActive(true);
				}
			}
			Destroy(this.gameObject); //fade effect
		}
		else 
		{
			BGMManager.Instance.Pause();
			HUDManager.Instance.UICamera.SetActive(true);
			FirstPersonAIO.Instance.gameObject.SetActive(false);
			HUDManager.Instance.PlayAnim("BadEnding");
			Destroy(this.gameObject); //fade effect
			//Bad ending.
		}
	}
}
