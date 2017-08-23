using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public int playerHealth; //Puntos de vida del jugador
	public int playerVelocity; //Velocidad del jugador
	private Vector3 playerPosition = Vector3.zero; //Se establece la posicion base del objeto

	void Update () {
		//Alojamos en una variable el componente CharacterController colocado al objeto
		CharacterController controller = GetComponent<CharacterController> ();
		//Establecemos la posicion del objeto en los ejes X y Y usando el control Horizontal y Vertical
		playerPosition = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
		//Establecemos la velocidad del objeto al cambiar de posicion, asignada anteriormente en la variable PlayerVelocity
		playerPosition *= playerVelocity;
		//Usamos la funcion Move del componente CharacterController alojado en la variable "controller"
		//Para que realice el cambio de posicion a la velocidad asignada en segundos
		controller.Move (playerPosition * Time.deltaTime);

		//Realiza la funcion Dead si la vida del personaje representada en la variable "playerHealth" es igual o menor a 0
		if (playerHealth <= 0) {
			Dead ();
		}
	}
	// Dead es llamado si la vida del personaje representada en la variable "playerHealth" llega a 0 o menos
	void Dead() {
		Destroy (this.gameObject);
	}
}
