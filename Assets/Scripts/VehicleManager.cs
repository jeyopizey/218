using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class VehicleManager : MonoBehaviour
{
    // Start is called before the first frame update
	
    float m_elapsedTime = 0;
	[SerializeField]float m_speed;

    [SerializeField] PathCreator m_pathCreator = null;
	[SerializeField]private float m_vehicleLength = 40f;

    private const float DISTANCE_START = 20f;

    [SerializeField] List<GameObject> m_vehicles = new List<GameObject>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < m_vehicles.Count; i++)
		{
			GameObject vehicle = m_vehicles[i];
			m_elapsedTime += Time.deltaTime * m_speed;

            float t = DISTANCE_START + m_elapsedTime - m_vehicleLength * i;
			vehicle.transform.position = m_pathCreator.path.GetPointAtDistance(t);
            vehicle.transform.rotation = m_pathCreator.path.GetRotationAtDistance(t) * Quaternion.Euler(0, 0, 0);
		}
    }
}
