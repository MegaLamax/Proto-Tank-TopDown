using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMove : MonoBehaviour
{
    public float t_Speed;
    public float t_TurnSpeed;
    private string t_MovementAxisName;
    private string t_TurnAxiesName;
    private Rigidbody t_Rigidbody;
    private float t_MovementInputValue;
    private float t_TurnInputValue;

    private void Awake()
    {
        //guarda el Rigidbody del tanque
        t_Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        
        t_Rigidbody.isKinematic = false;
        t_MovementInputValue = 0f;
        t_TurnInputValue = 0f;
    }

    private void OnDisable()
    {
        t_Rigidbody.isKinematic = true;
    }

    void Start()
    {
     t_MovementAxisName = "Vertical";
     t_TurnAxiesName = "Horizontal";      
    }

    void Update()
    {
      t_MovementInputValue = Input.GetAxis(t_MovementAxisName);
      t_TurnInputValue = Input.GetAxis(t_TurnAxiesName);      
    }
    
    void FixedUpdate()
    {
        //aca creamos las funciones para mover el tanke mediate las fisicas.
        //en este manejamos el movimiento del tanque.
        Move();
        //Y aca la rotacion.
        Turn();
    }

    private void Move()
    {
        /*creo una Vector3 variable llamada "movement", en donde voy a guardar
        el movmiento frontal del tanque*/
      Vector3 movement = transform.forward * t_MovementInputValue * t_Speed * Time.deltaTime;
      
      t_Rigidbody.MovePosition (t_Rigidbody.position + movement);
    }

    private void Turn()
    {
      float turn = t_TurnInputValue * t_TurnSpeed * Time.deltaTime;
      /*en pocas palabras los Quaternion sirven para guardar rotaciones
      y van de la mano con las fisicas*/
      Quaternion turnRotation = Quaternion.Euler (0f,turn,0f);

      t_Rigidbody.MoveRotation (t_Rigidbody.rotation * turnRotation);
    }
    
}
    
   