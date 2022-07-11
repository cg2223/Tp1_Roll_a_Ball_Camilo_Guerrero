using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//importer le système d'interface utilisateur
using UnityEngine.UI;
//système de input d'importation
using UnityEngine.InputSystem;

public class JoueurControleur : MonoBehaviour
{
    //vitesse du joueur
    public float speed = 5;
    //variable de comptage
    public Text countText;
    //variable pour le gagnant
    public Text vousGagnez;
    //corps rigide variable
    private Rigidbody rb;
    //variable de comptage de cubes
    private int count;


    //variables pour le mouvement de la sphère en x et y
    private float movementX;
    private float movementY;


    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        //commencer à zéro pour compter les cubes
        count = 0;
        SetCountText();
        vousGagnez.text = "";
    }

    void OnMove(InputValue movementValeur)
    {

        Vector2 movementVector = movementValeur.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;

    }


    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Saisir"))
       {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }
    void SetCountText ()
    {
       countText.text = "Count:" + count.ToString();
        if (count >= 8)
        {
            vousGagnez.text = "Vous Gagnez";
        }
    }
}
