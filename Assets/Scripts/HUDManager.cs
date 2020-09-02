using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDManager : MonoInstance<HUDManager>
{
	[SerializeField]GameObject m_E;
	[SerializeField]GameObject m_click;
	
	[SerializeField]Animator m_animController;
	[SerializeField]public GameObject UICamera;

	private bool m_bIsInMainMenu;

	void Update()
	{
		if ( m_bIsInMainMenu )
		{
			if ( Input.GetMouseButtonUp(0))
			{
				OnMainMenuClick();
			}
		}
	}
	void Start()
	{
		m_animController = transform.GetComponent<Animator>();
	}
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

	public void OnMainMenuClick()
	{
		UICamera.SetActive(false);
		PlayAnim("MainMenuFadeIn");
		GameController.Instance.StartStage();
		BGMManager.Instance.Play();
		m_bIsInMainMenu = false;
	}

	public void PlayAnim(string p_string)
	{
		m_animController.Play(p_string);
	}

	public void OnPlayGoodEnding()
	{
		UICamera.SetActive(true);
		FirstPersonAIO.Instance.gameObject.SetActive(false);
	}
	
	public void IsInMainMenu()
	{
		m_bIsInMainMenu = true;
	}
}
