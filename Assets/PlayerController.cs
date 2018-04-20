using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private const float VERTICAL_MULTIPLIER = 10f;
	private const float VERTICAL_OFFSET = 1f;

	[SerializeField] private Rigidbody2D body;
	[SerializeField] private GameObject projectilePrefab;
	[SerializeField] private Transform projectileSpawnPoint;
	[SerializeField] private Transform upperBound;
	[SerializeField] private Transform lowerBound;

	private Vector3 tempPosition;
	private float maxYOffset; 
	private float minYOffset;

	public void moveVertically(float value)
	{
		body.AddForce(new Vector2(0f, value * VERTICAL_MULTIPLIER));
	}

	public void fireWeaponA()
	{
		var projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);
		projectile.GetComponent<Projectile>().launch(100f);
	}

	private void Start()
	{
		maxYOffset = upperBound.position.y - VERTICAL_OFFSET;
		minYOffset = lowerBound.position.y + VERTICAL_OFFSET;
	}

	private void Update() 
	{
		if (transform.position.y >= maxYOffset) setYClamp(maxYOffset);
		else if (transform.position.y <= minYOffset) setYClamp(minYOffset);
	}

	private void setYClamp(float value)
	{
		body.velocity = Vector2.zero;
		tempPosition = transform.position;
		tempPosition.y = value;
		transform.position = tempPosition;
	}
}
