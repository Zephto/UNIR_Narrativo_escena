using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
	public NavMeshAgent enemy;
	public Transform player;

	void Update()
	{
		enemy.SetDestination(player.position);
	}


	public void FollowPlayer()
	{
		//Aqui activar la cinematica de perseguir
	}
}
