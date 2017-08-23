using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour {

	public Text life; //Vida del personaje representada en la interfaz grafica
	public Text score; //Puntuacion representada en la interfaz durante el juego
	public Text time; //Tiempo representado en la interfaz
	public Text finalScore; //Puntuacion final representada en la interfaz grafica de "GameOver"
	public Text generalHighscore; //Mayor puntuacion historica representada en la interfaz grafica de "GameOver"
	public float gameTime; //Tiempo establecido a la escena
	public int gameScore; //Escore sumado durante la partida
	public int highscore; //Mayor puntuacion historica
	public GameObject Menu; //Interfaz grafica de "Menu"
	public GameObject GameOver; //Interfaz Grafica de "GameOver"
	static GameObject player; //Jugador

	// Use this for initialization
	void Start () {
		Time.timeScale = 1; //Se establece el valor 1 para llevar el tiempo normal de la ecena
		Menu.SetActive (false); //Se desactiva la interfaz grafia de "Menu"
		GameOver.SetActive (false); //Se desactiva la interfaz grafica de "GameOver"
		player = GameObject.FindGameObjectWithTag ("Player"); //Se establece el objeto jugador para acceder a sus componentes
		OnLoad (); //Se cargan los datos guardados en PlayerPrefs
	}
	
	// Update is called once per frame
	void Update () {
		//Si el tiempo es mayor a cero empezara a restarse en 1 segundo a la vez
		if (gameTime > 0) {
			gameTime -= Time.deltaTime;
		}
		//Si la variable Player no es nula, el tiempo de escena es menor o igual a cero o el valor "playerHealth"
		//del componente Player es igual o menor a cero, se cumplen los siguientes parametros
		if (player != null) {
			if (gameTime <= 0 || player.GetComponent<Player> ().playerHealth <= 0) {
				gameTime = 0; //El tiempo de la escena regresa a 0
				GameOver.SetActive (true); //Se activa la interfaz grafica "GameOver"
				Time.timeScale = 0; //Se detiene el tiempo
			}
			time.text = "Time: " + (int) gameTime; //Se representa el valor gameTime en la interfaz grafica
			score.text = finalScore.text = "Score: " + gameScore; //Se representa el valor score en la interfaz

			//Si el puntaje historico es mayor al puntaje actual
			if (highscore > gameScore) {
				//Se representa en la interfaz el puntaje historico
				generalHighscore.text = "Highscore: " + highscore;
			}
			//Si el puntaje actual es mayor al puntaje historico
			else {
				//Se representa en la interfaz el puntaje actual
				generalHighscore.text = "Highscore: " + gameScore;
			}
			//Se representa el valor "playerHealth" del componente Player en la interfaz grafica
			life.text = "Life: " + player.GetComponent<Player> ().playerHealth;
		}
	}
	//Si el usuario oprime el boton de pause, activa esta funcion
	public void Pause (){
		Menu.SetActive (true); //Se activa la interfaz grafica "Menu"
		Time.timeScale = 0; //Se detiene el tiempo
	}
	//Si el usuario oprime en el boton continue de la interfaz grafica Pause, activa esta funcion
	public void Continue () {
		Menu.SetActive (false); //Se desactiva la interfaz grafica "Menu"
		Time.timeScale = 1; //Se establece el tiempo normal de la escena
	}
	//Si el usuario oprime en el boton exit de la interfaz grafica Pause o GameOver, activa esta funcion
	public void Exit (){
		SceneManager.LoadScene("MainMenu", LoadSceneMode.Single); //Se carga la escena MainMenu
		OnSave (); //Se guardan los datos a traves de la funcion OnSave
	}
	//Si el usuario oprime el boton reset de la interfaz grafica Pause o GameOver, activara esta funcion
	public void Reset (){
		SceneManager.LoadScene("Map1", LoadSceneMode.Single); //Se cargara de nuevo la escena actual
		OnSave (); //Se guardan los datos a traves de la funcion OnSave
	}
	//Funcion donde se establecen los datos a cargar
	public void OnLoad () {
		highscore = PlayerPrefs.GetInt ("Highscore"); //Se cargan los datos del playerPrefs "Highscore" y se establecen a la variable highscore
	}
	//Funcion mediante la cual se guardan datos
	public void OnSave () {
		//Si el puntaje actual es mayor al puntaje historico
		if (gameScore > highscore) {
			//Se guarda el puntaje actual en el valor del PlayerPrefs "Highscore"
			PlayerPrefs.SetInt ("Highscore", GetComponent<Level>().gameScore);
		}
	}
}
