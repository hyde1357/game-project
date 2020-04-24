using UnityEngine.EventSystems;
using UnityEngine;

/* Controls the player. Here we choose our "focus" and where to move. */

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController1 : MonoBehaviour {


	public LayerMask movementMask;	// Filter out everything not walkable

	Camera cam;			// Reference to our camera
	PlayerMotor motor;	// Reference to our motor

	// Get references
	void Start () {
		cam = Camera.main;
		motor = GetComponent<PlayerMotor>();
	}
	
	// Update is called once per frame
	void Update () {

		if (EventSystem.current.IsPointerOverGameObject())
			return;

		// If we press left mouse
		if (Input.GetMouseButtonDown(0))
		{
			// We create a ray
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			// If the ray hits
			if (Physics.Raycast(ray, out hit, 100, movementMask))
			{
				motor.MoveToPoint(hit.point);   // Move to where we hit

			}
		}

		// If we press right mouse
		if (Input.GetMouseButtonDown(1))
		{
			// We create a ray
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			// If the ray hits
			if (Physics.Raycast(ray, out hit, 100))
			{

			}
		}
	}

	// Set our focus to a new focus
	
}
