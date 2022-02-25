using UnityEngine;
 using UnityEngine.UI;
public class Tank : MonoBehaviour
{
	public Transform destination;
	public UnityEngine.AI.NavMeshAgent agent;

	public float healthLeft = 10;
	public Image health;

	private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Projectile")
        {
			healthLeft--;
			health.fillAmount = healthLeft/10;
			if(healthLeft <= 0)
			{
				gameManagerScript.score+= 100;
				gameManagerScript.enemiesDestroyed+= 1;
				Destroy(gameObject);
			}
        }
    }
	void Update ()
	{
		agent.SetDestination(destination.position);
		
		if (Vector3.Distance(transform.position, destination.position) <= 2f)
		{
			gameManagerScript.livesLeft--;
			Destroy(gameObject);
			return;
		}
	}
}
