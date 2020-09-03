using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoInstance<ShootController>
{
    [SerializeField]Transform m_spawnPoint;
	[SerializeField]GameObject m_bullet;
	[SerializeField]Camera m_camera;
	[SerializeField]AudioClip m_teleAudio;
	[SerializeField]AudioClip m_shootAudio;
	[SerializeField]AudioClip m_goalAudio;
	[SerializeField]AudioClip m_fallAudio;
	AudioSource m_audioSource;

	private bool m_canShoot = false;

	void Start()
	{
		m_audioSource = transform.GetComponent<AudioSource>();
	}
	void Update()
	{
		RaycastHit hit;
		if(Physics.Raycast (m_camera.transform.position, m_camera.transform.forward, out hit, 7.5f))
		{
			if (hit.transform.tag == "Interactable")
			{
				HUDManager.Instance.SetInteractableActive(true);
				if(Input.GetKeyUp(KeyCode.E))
				{
					HUDManager.Instance.SetInteractableActive(false);
					hit.transform.GetComponent<Interactable>().Interact();
        		}
			}
			else
			{
				HUDManager.Instance.SetInteractableActive(false);
			}
		}

		if ( GameController.Instance.CurrentStage < 2 ) { return; }

		if ( m_canShoot )
		{
			if(Physics.Raycast (m_camera.transform.position, m_camera.transform.forward, out hit, 500))
			{
				if ( Input.GetMouseButtonUp(0))
				{
					HUDManager.Instance.HideClick();
					GameObject dagger = Instantiate(m_bullet, m_spawnPoint.position, Quaternion.identity);
            		dagger.transform.GetComponent<Dagger>().SetUp((hit.point - m_spawnPoint.position).normalized);
					m_canShoot = false;
					m_audioSource.PlayOneShot(m_shootAudio);
				}
			}
		}
	}
	public bool CanShoot
	{
		get { return m_canShoot; }
		set { m_canShoot = value; }
	}
	public void PlayTeleAudio()
	{
		m_audioSource.PlayOneShot(m_teleAudio);
	}
	public void PlayGoalAudio()
	{
		m_audioSource.PlayOneShot(m_goalAudio);
	}
	public void PlayFallAudio()
	{
		m_audioSource.PlayOneShot(m_fallAudio);
	}
}
