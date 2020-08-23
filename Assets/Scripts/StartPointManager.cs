using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPointManager : MonoInstance<StartPointManager>
{
	[SerializeField]List<Transform> m_startingPoints = new List<Transform>();
	private int m_startPoint;

	void Start()
	{
		m_startPoint = 0;
	}

	public Transform StartPoint
	{
		get { return m_startingPoints[m_startPoint]; }
	}
}
