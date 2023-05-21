using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionFlipScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private Transform _centerPoint;

    public float rotationSpeed = 90f;
    private bool isRotating = false;
    private float targetRotation = 0f;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _player.GetComponent<Player>().TogglePhasing();
            Vector3 targetPosition = new Vector3(_centerPoint.position.x, transform.position.y, transform.position.z);
            if (!isRotating)
            {
                targetRotation += 180f;
                isRotating = true;
            }
        }

        if (isRotating)
        {
            float step = rotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0f, 0f, targetRotation), step);

            if (Quaternion.Angle(transform.rotation, Quaternion.Euler(0f, 0f, targetRotation)) < 0.1f)
            {
                isRotating = false; // Stop rotating when the target rotation is reached
                _player.GetComponent<Player>().TogglePhasing();
            }
        }
    }
}