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
	[SerializeField]private List<float> m_playerSpeed = new List<float>();
	[SerializeField]private float m_walkSpeed = 9f;
	
    private Transform m_respawnPos;
	void Start()
	{
		if (m_currentStage == 2)
		{
			ShootController.Instance.CanShoot = true;
		}
		CheckpointManager.Instance.CurrentCheckpoint = StartPointManager.Instance.StartPoint;
	}

	public void StartStage()
	{
		CheckpointManager.Instance.CurrentCheckpoint = StartPointManager.Instance.StartPoint;
		m_playerCamera.localPosition = new Vector3(0, m_cameraHeight[m_currentStage], 0);
		m_walkSpeed = m_playerSpeed[m_currentStage];
		SceneManager.LoadScene("Stage"+ (GameController.Instance.CurrentStage + 1) );
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

	public float WalkSpeed
	{
		get { return m_walkSpeed; }
	}
}
