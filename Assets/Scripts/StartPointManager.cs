using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPointManager : MonoInstance<StartPointManager>
{
	[SerializeField]List<Transform> m_startingPoints = new List<Transform>();

	public Transform StartPoint
	{
		get { return m_startingPoints[GameController.Instance.CurrentStage]; }
	}
}
