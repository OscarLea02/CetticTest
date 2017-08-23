using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour {

	public int Lifetime; //Tiempo de vida del objeto
	public float Speed = 80; //Velocidad normal del objeto
	public float SpeedMax = 80; //Velocidad Maxima del objeto
	public float SpeedMult = 1; //Multiplicador de la velocidad

	private void Start()
	{
		//Se destruye el objeto al tiempo establecido en "Lifetime"
		Destroy(gameObject, Lifetime);
	}

	private void FixedUpdate()
	{
	//Se establece la velocidad y el eje de movimiento del objeto a traves del componente Rigidbody
	GetComponent<Rigidbody>().velocity = transform.forward*Speed;
	
		if (this.GetComponent<Rigidbody> ().velocity.normalized != Vector3.zero) 
			this.transform.forward = this.GetComponent<Rigidbody> ().velocity.normalized;
		//Si la velocidad es menor a la velocidad maxima
		if(Speed < SpeedMax){
			//Se multiplica la velocidad por el valor asignado en "SpeedMult"
			Speed += SpeedMult * Time.fixedDeltaTime;
		}
	}
}
