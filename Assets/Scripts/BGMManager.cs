using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoInstance<BGMManager>
{
	AudioSource m_audioSource;

	void Start()
	{
		m_audioSource = transform.GetComponent<AudioSource>();
	}
    public void Pause()
	{
		m_audioSource.Pause();
	}

	public void UnPause()
	{
		m_audioSource.UnPause();
	}

	public void Play()
	{
		m_audioSource.Play();
	}
}
