﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilManager : MonoBehaviour
{
    [SerializeField]Material m_material;
	private float m_colorIntensity;
	private float m_intensity;
	private float m_elapsedTime = 0.0f;
	private float m_waitTime = 4.0f;

	void Start()
	{
		InvokeRepeating("PencilSequence", 5.0f, 10.0f);
	}

	void PencilSequence()
	{
		Debug.Log("PencilSequence");
		m_colorIntensity = Random.Range(0.3f, 0.95f);
		StartCoroutine(DoPencilSequence());
	}

	IEnumerator DoPencilSequence()
	{
		while (m_elapsedTime < m_waitTime)
		{
			m_intensity = Mathf.Lerp(m_intensity, m_colorIntensity, (m_elapsedTime / m_waitTime));
			m_material.SetFloat("_ColorIntensity", m_intensity);
			
			m_elapsedTime += Time.deltaTime;

			
			// Yield here
			yield return null;
		}
		m_elapsedTime = 0;
	}
}