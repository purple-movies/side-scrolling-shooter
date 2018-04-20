using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	[SerializeField] private Rigidbody2D body;
	private Vector2 force2D = new Vector2();

	public void launch(float force)
	{
		force2D.x = force;
		body.AddForce(force2D);
	}
}
