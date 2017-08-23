using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour {
	public float timer; //Tiempo inicial
	public bool spawning; //Verifica si se spawnea
	public Transform[] locations; //Localizaciones del spawn
	public int locationSelect; //Localizacion selecionada
	public GameObject[] objects; //Objetos a spawnear
	public int objectSelect; //Objeto selecionado
	public float spawnTime; //Tiempo de spawneo

	// Use this for initialization
	void Start () {
		spawning = false; //Se desactiva el spawneo al inciar
		timer = 0; //Se establece el tiempo en 0
	}
	
	// Update is called once per frame
	void Update () {
		//Si es falso el spawneo
		if (!spawning) {
			//Empieza a sumar el tiempo incial
			timer += Time.deltaTime;
		}
		//Si el tiempo inicial alcanza al tiempo de spawneo
		if (timer >= spawnTime) {
			//Inicia la funcion Spawn
			Spawn ();
		}
	}
	//Funcion Spawn, mediante la cual se realizara la creacion del objeto en una localizacion random
	void Spawn() {
		spawning = true; //Se activa el spawneo
		timer = 0; //Se reestablece a 0 el tiempo inicial
		locationSelect = Random.Range (0, locations.Length); //Se establece una localizacion random
		objectSelect = Random.Range (0, objects.Length); //Se establece un objeto random
		GameObject newObject; //Se crea una variable para alojar el objeto seleccionado
		newObject = objects [objectSelect]; //Se aloja el objeto selecionado en la nueva variable
		Transform newLocation; //Se crea una variable para alojar la localizacion seleccionada
		newLocation = locations [locationSelect]; //Se aloja la localizacion seleccionada en la nueva variable
		//Se crea el objeto a spawnear en la posicion y rotacion de la localizacion seleccionada
		GameObject nowSpawn = Instantiate (newObject, newLocation.position, newLocation.rotation);
		spawning = false; //Se desactiva el spawneo
	}
}
