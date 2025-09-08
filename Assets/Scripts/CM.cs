using Unity.Cinemachine;
using UnityEngine;

public class CM : MonoBehaviour
{
    public CinemachineCamera Camera;

    public GameObject Player;

    void Start()
    {
        Player = GameObject.Find("Player");

        Camera = this.GetComponent<CinemachineCamera>();

        if (Camera != null)
            Camera.Target.TrackingTarget = Player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
