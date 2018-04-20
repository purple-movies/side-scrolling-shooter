using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
	[SerializeField] private PlayerController playerController;

	private float verticalAxis = 0f;

	private void Update ()
	{
		verticalAxis = Input.GetAxis(InputConstants.VERTICAL);

		if (verticalAxis != 0)
			playerController.moveVertically(verticalAxis);

		if (Input.GetButtonDown(InputConstants.FIRE_1))
			playerController.fireWeaponA();	
	}
}
