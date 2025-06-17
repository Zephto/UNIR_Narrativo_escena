using UnityEngine;

public class Trigger : MonoBehaviour
{
	public EnemyFollow enemy;
	private bool cinematicActivated = false;

	void OnCollisionEnter(Collision collision)
	{
		if (cinematicActivated) return;

		if (collision.gameObject.CompareTag("Player"))
		{
			cinematicActivated = true;
			enemy.FollowPlayer();
		}
	}
}
