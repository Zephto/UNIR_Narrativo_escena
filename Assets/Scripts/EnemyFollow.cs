using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
	public NavMeshAgent enemy;
	public Transform player;


	[Header("Cameras")]
	public GameObject Camera1;
	public GameObject Camera2;
	public GameObject Camera3;
	public GameObject Camera4;

	public GameObject explosionParticles;

	private Animator anim;
	private bool canRun = false;
	private bool isAnimationActivated = false;

	void Start()
	{
		anim = this.GetComponent<Animator>();
	}

	void Update()
	{
		if (canRun)
		{
			enemy.SetDestination(player.position);
		}
	}


	public void FollowPlayer()
	{
		if (!isAnimationActivated)
		{
			isAnimationActivated = true;
			StartCoroutine(AttackAnimation());
		}

		//Aqui activar la cinematica de perseguir
	}

	private IEnumerator AttackAnimation()
	{
		Camera1.SetActive(true);
		yield return new WaitForSeconds(2f);

		Camera2.SetActive(true);
		yield return new WaitForSeconds(3f);

		explosionParticles.SetActive(true);
		yield return new WaitForSeconds(1f);
		Camera3.SetActive(true);
		yield return new WaitForSeconds(1.5f);
		anim.SetTrigger("rage");

		yield return new WaitForSeconds(1.5f);
		Camera4.SetActive(true);

		yield return new WaitForSeconds(2f);
		Camera1.SetActive(false);
		Camera2.SetActive(false);
		Camera3.SetActive(false);
		Camera4.SetActive(false);

		anim.SetTrigger("run");
		canRun = true;
	}
}
