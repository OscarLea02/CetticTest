using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private Rigidbody rb;
	public int enemyVelocity; //Velocidad del enemigo
	public int enemyHealth; //Vida del enemigo
	public int damage; //Dano del enemigo
	static GameObject player; //Jugador
	static GameObject level; //Nivel
	public GameObject effect; //Efecto al destruirse
	public int points; //Puntos que da este objeto

	// Use this for initialization
	void Start () {
		//Se busca el objeto principal de la escena para acceder a sus componentes
		level = GameObject.FindGameObjectWithTag ("Scene");
		//Se busca el objeto jugador para acceder a sus componentes
		player = GameObject.FindGameObjectWithTag ("Player");
		//Se establece el componente Rigidbody agregado al objeto
		rb = this.gameObject.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Se establece el movimiento y la velocidad del objeto establecido en la variable "enemyVelocity"
		//El movimiento se realiza en el eje Z usando la funcion "velocity" del componente Rigidbody
		rb.velocity = new Vector3(0, 0, -enemyVelocity);

		//Cuando la vida del enemigo sea igual o menor a 0 se llama la funcion "Dead"
		if (enemyHealth <= 0) {
			Dead ();
		}
	}
	//Esta funcion se activa cuando algun objeto con el tag definido collisione con este objeto
	void OnTriggerEnter (Collider col) {
		if (col.gameObject.tag == "spaceEnd") {
			Destroy (this.gameObject);
		}
		if (col.gameObject.tag == "Player") {
			//Si coliciona con el jugador, restara el damage definido al "playerHealth", que es una variable
			//del componente Player
			player.GetComponent<Player> ().playerHealth -= damage;
			//Enseguida se instancia el objeto efecto en la posicion y rotacion de este objeto
			Instantiate (effect, transform.position, transform.rotation);
			//Destruye este objeto
			Destroy (this.gameObject);
		}
		if (col.gameObject.tag == "Bullet") {
			//Al colisionar con el objeto de tag "Bullet", se restara el valor a "enemyHealth"
			enemyHealth -= 25;
		}
	}
	//La funcion Dead es llamada si la variable "enemyHealth" tiene un valor igual o menor a 0
	//aqui se define que ocurrira si el objeto pierde todos sus puntos de vida
	void Dead(){
		//Se instancia el objeto efecto en la posicion y rotacion de este objeto
		Instantiate (effect, transform.position, transform.rotation);
		//Se agregan 2 segundos mas a la ecena
		level.GetComponent<Level> ().gameTime += 2;
		//Se agrega el valor "points" a la puntuacion del jugador
		level.GetComponent<Level> ().gameScore += points;
		//Destruye este objeto
		Destroy (this.gameObject);
	}
}
