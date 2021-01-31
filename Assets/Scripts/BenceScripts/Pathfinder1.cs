using UnityEngine;
using System.Collections;

public class Pathfinder1 : MonoBehaviour
{
	public Transform[] TargetPoints;
	public float[] WaitTimes;
	public float[] Speed;
	public bool[] FaceToTarget;

	private Transform currentTarget;
	private int currenttargetindex;
	private float assignedWaitTime;

	void Start ()
	{
		assignedWaitTime = WaitTimes [0];
		currentTarget = TargetPoints [0];
		currenttargetindex = 0;
	}

	void FixedUpdate ()
	{
		if (FaceToTarget [currenttargetindex] == true) {
			if (currentTarget.transform.position != this.gameObject.transform.position) {
				this.gameObject.transform.position = Vector3.MoveTowards (transform.position, currentTarget.transform.position, Speed[currenttargetindex] * Time.deltaTime);
			} else {
				assignedWaitTime -= Time.deltaTime;
				if (assignedWaitTime <= 0.0f) {
					if (TargetPoints [TargetPoints.Length - 1] == currentTarget) {
						transform.LookAt (TargetPoints [0].transform);
						currentTarget = TargetPoints [0];
						assignedWaitTime = WaitTimes [0];
						currenttargetindex = 0;
					} else {
						transform.LookAt (TargetPoints [currenttargetindex + 1].transform);
						currentTarget = TargetPoints [currenttargetindex + 1];
						assignedWaitTime = WaitTimes [currenttargetindex + 1];
						currenttargetindex = currenttargetindex + 1;
					}
				}
			}
		} else {
			if (currentTarget.transform.position != this.gameObject.transform.position) {
				this.gameObject.transform.position = Vector3.MoveTowards (transform.position, currentTarget.transform.position, Speed[currenttargetindex] * Time.deltaTime);
			} else {
				assignedWaitTime -= Time.deltaTime;
				if (assignedWaitTime <= 0.0f) {
					if (TargetPoints [TargetPoints.Length - 1] == currentTarget) {
						currentTarget = TargetPoints [0];
						assignedWaitTime = WaitTimes [0];
						currenttargetindex = 0;
					} else {
						currentTarget = TargetPoints [currenttargetindex + 1];
						assignedWaitTime = WaitTimes [currenttargetindex + 1];
						currenttargetindex = currenttargetindex + 1;
					}
				}
			}
		} 
	}
}
