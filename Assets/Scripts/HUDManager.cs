using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager : MonoInstance<HUDManager>
{
	[SerializeField]GameObject m_E;
	[SerializeField]GameObject m_click;

	public void SetInteractableActive(bool p_bool)
	{
		m_E.SetActive(p_bool);
	}
	public void SetClickActive(bool p_bool)
	{
		m_click.SetActive(p_bool);
	}
	
	public void HideClick()
	{
		if (m_click.activeSelf)
		{
			m_click.SetActive(false);
		}
	}
}
