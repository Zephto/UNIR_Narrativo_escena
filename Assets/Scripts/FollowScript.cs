using UnityEngine;

public class FollowScript : MonoBehaviour
{
    public Transform targetObj;



	private void Update()
	{
		this.transform.position = Vector3.MoveTowards(transform.position, targetObj.position, 10*Time.deltaTime);
	}
}
