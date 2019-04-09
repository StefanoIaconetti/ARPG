using UnityEngine;

//This script helps the camera follow a certain gameobject, currently this is being used for the main menu background
public class CameraFollow : MonoBehaviour
{
	//The target is the gameobject given for the camera to follow
	public Transform target;

	//The speed is how fast the camera follows the object
	public float slideSpeed = 0.125f;

	//This update is a little later than regular update
	void LateUpdate(){
		//This is multiplied by the specified slideSpeed and the time.deltatime
		float checkSet = slideSpeed * Time.deltaTime;

		//This allows the Z axis to not change during movement
		Vector3 actualTarget = new Vector3 (transform.position.x, transform.position.y, target.position.z); 

		//Moves the camera towards the target
		transform.position = Vector3.MoveTowards (actualTarget, target.position, checkSet);
	}
}
