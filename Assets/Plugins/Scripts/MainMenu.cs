using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public int score; //Valor del puntaje actual
	public Text highscore; //Valor del mayor puntaje
	public GameObject HowToPlay; //Objeto de la interfaz grafica "HowToPlay"

	void Start () {
		//Se cargan los datos establecidos en la funcion OnLoad
		OnLoad ();
		HowToPlay.SetActive (false); //Se desactiva la interfaz grafica "HowToPlay"
	}
	
	// Update is called once per frame
	void Update () {
		highscore.text = "Highscore: " + score; //Se representa en la interfaz grafica el valor "score"
	}
	//Funcion mediante la cual se cargan los datos necesarios
	void OnLoad () {
		//Se establece el valor guardado en PlayerPrefs "Highscore" a la variable "score"
		score = PlayerPrefs.GetInt ("Highscore");
	}
	//Si el usuario oprime el boton Play, activara esta funcion
	public void Play () {
		//Se carga la escena "Map1"
		SceneManager.LoadScene("Loader", LoadSceneMode.Single);
	}
	//Si el usuario oprime el boton "Como Jugar", se activara esta funcion
	public void HowPlay () {
		HowToPlay.SetActive (true); //Se activa la interfaz grafica "HowToPlay"
	}
	//Si el usuario oprime el boton "Salir"
	public void Salir () {
		HowToPlay.SetActive (false); //Se desactiva la interfaz grafica "HowToPlay"
	}
}
