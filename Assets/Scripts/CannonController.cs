using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CannonController : MonoBehaviour
{
    //cannon Rotation Variables
    public float speed;
    public float friction;
    public float lerpSpeed;
    float xDegrees;
    float yDegrees;
    Quaternion fromRotation;
    Quaternion toRotation;
    public Camera playerCamera;
    public int UpdateLives;

    //Variables for le cannon shooting
    public GameObject cannonBall;
    public Transform shotPos;
    public GameObject explosion;
    public float firePower;
    public int powerMultiplier = 100;

    [SerializeField]
    private int _lives = 3;
    private UIManager _uiManager;

    [SerializeField]
    private CannonBall _cannonball;


    Vector3 lookRotation = Vector3.zero;
    Vector2 moveDirection = Vector2.zero;

    //Initiatlisation....COMMENCE!

    void Start()
    {
        firePower *= powerMultiplier;

        _uiManager = GameObject.Find("UI Manager").GetComponent<UIManager>();
        if (_uiManager == null)
        {
            Debug.LogWarning("UI Manager is NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {

        lookRotation = lookRotation + new Vector3(moveDirection.x, moveDirection.y, 0) * speed * Time.deltaTime * -1;
        transform.localRotation = Quaternion.Euler(lookRotation.y, lookRotation.x, 0);
    }

    public void Damage()
    {
        _lives -= 1;
        _uiManager.UpdateLives(_lives);

    }
    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
    }

    void OnMove(InputValue value)
    {
        moveDirection = value.Get<Vector2>();
    }

    public void OnFireCannon()
    {
        GameObject cannonBallCopy = Instantiate(cannonBall, shotPos.position, shotPos.rotation) as GameObject;
        Rigidbody cannonBallRB = cannonBallCopy.GetComponent<Rigidbody>();
        cannonBallRB.AddForce(cannonBallRB.transform.forward * firePower);
        Instantiate(explosion, shotPos.position, shotPos.rotation);
    }
}