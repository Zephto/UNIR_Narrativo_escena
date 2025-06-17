using UnityEngine;

public class Trigger : MonoBehaviour
{
	public EnemyFollow enemy;
	private bool cinematicActivated = false;

	void OnTriggerEnter(Collider other)
	{
		if (cinematicActivated) return;

		Debug.Log("Que empiece la cinematica");

		if (other.CompareTag("Player"))
		{
			cinematicActivated = true;
			enemy.FollowPlayer();
		}
	}
}
