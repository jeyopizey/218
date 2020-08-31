using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoInstance<GameController>
{
	[SerializeField]GameObject m_player;
	[SerializeField]int m_currentStage;
	[SerializeField]Transform m_playerCamera;
	[SerializeField]private List<float> m_cameraHeight = new List<float>();
    
	public void StartStage()
	{
		m_playerCamera.position = new Vector3(m_playerCamera.position.x, m_cameraHeight[m_currentStage], m_playerCamera.position.z);
		SceneManager.LoadScene("Stage"+ (GameController.Instance.CurrentStage + 1) );
		m_player.transform.position = StartPointManager.Instance.StartPoint.position;
	}

	public void Respawn()
	{
		m_player.transform.position = CheckpointManager.Instance.CurrentCheckpoint.position;
	}

	public int CurrentStage
	{
		get { return m_currentStage; }
		set { m_currentStage = value; }
	}
}
