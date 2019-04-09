using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform target;

	public float smoothSpeed = 0.125f;



	void LateUpdate(){
		float offSet = smoothSpeed * Time.deltaTime;
		Vector3 actualTarget = new Vector3 (transform.position.x, transform.position.y, target.position.z); 
		transform.position = Vector3.MoveTowards (actualTarget, target.position, offSet);
	}
}
