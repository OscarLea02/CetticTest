using System.Collections;
using UnityEngine;

public class WeaponController : MonoBehaviour {

	public bool spawning; //Verifica si se spawnea
	public Transform[] locations; //Localizaciones del spawn
	public int locationSelect; //Localizacion selecionada
	public GameObject objects; //Objeto selecionado
	public float fireRate; //Delay entre disparo
	private float nextFire = 0.0f; //Inicio del delay
	public AudioSource audioSource; //Audio de disparo

	void Start (){
		audioSource = GetComponent<AudioSource> (); //Se establece el componente AudioSource agregado al objeto
	}
	void Update (){
		//Si se oprime el boton "Fire1" establecidos en los input de unity como "left Ctrl" y el delay de disparo ha transcurrido
		if (Input.GetButton ("Fire1") &&  Time.time > nextFire) {
			//Regresa al valor establecido de delay
			nextFire = Time.time + fireRate;
			//Inicia la funcion Spawn enviando el valor "fireRate"
			Spawn (fireRate);
		}
	}
	void Spawn(float time) {
		//Se reproduce el AudioClip establecido en el inspecto
		audioSource.Play ();
		locationSelect = Random.Range (0, locations.Length); //Se selecciona una localizacion random
		GameObject newObject; //Se crea una nueva variable para alojar el objeto a spawnear
		newObject = objects; //Se establece el objeto a spawnear en la variable nueva
		Transform newLocation; //Se crea una nueva variable para alojar la localizacion de spawneo
		newLocation = locations [locationSelect]; //Se establece la localizacion de spawneo en la nueva variable
		//Se instancia o spawnea el objeto seleccionado en la posicion y rotacion de la localizacion seleccionada
		GameObject nowShot = Instantiate (newObject, newLocation.position, newLocation.rotation);
	}
}
