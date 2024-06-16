using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _velocity;
    [SerializeField] private float _destroyTime;
    [SerializeField] private float _gravity;
    float stepLength;

    public float Velocity => _velocity;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, _destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        stepLength = Time.deltaTime * _velocity;

        Movement();
        Gravity();
        Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out RaycastHit hit, stepLength);
        if (hit.collider != null)
        {

            if (hit.collider.gameObject.transform.root.TryGetComponent(out Drone _drone))
            {

                Debug.Log(hit.collider.name);
                _drone.GetComponent<Destructible>().Dead();

            }

            Debug.Log(hit.collider.name);
            Destroy(gameObject);
        }
    }

    private void Movement()
    {
        transform.position += transform.forward * stepLength;
    }

    private void Gravity()
    {
        Vector3 gravity = new Vector3(0, _gravity * Time.deltaTime, 0);
        transform.position = transform.position - gravity;
    }


    private void OnDrawGizmos()
    {
        Vector3 VectorTo = transform.forward * stepLength;
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine (this.transform.localPosition, transform.localPosition + VectorTo);
    }
}
