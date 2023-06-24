using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScriptCharacter : MonoBehaviour
{
    //public GameObject subCanvas;
    //public GameObject CustomCanvas;
    //public float subMinPosY, subMaxPosY;

    float speed = 1.2F;
    float targetY, targetSize = 200F;

    Player player;

    SwipeScript swipe;

    public Sprite[] cape;
    public Sprite[] body;
    public Sprite[] cloths;
    public Sprite[] weapon;
    public Sprite[] hair;
    public Sprite[] face;
    public Sprite[] hat;

    public Sprite[] equips;



    //private int idCape, idBody, idCloths, idWeapon, idHair, idFace, idHat;

    public GameObject Cape, Body, Cloths, Weapon, Hair, Face, Hat;



    // Use this for initialization
    void Start()
    {
        player = new Player();
        player.Load();


        swipe = new SwipeScript();

        //subCanvas.transform.position = new Vector3(CustomCanvas.transform.position.x, CustomCanvas.transform.position.y + subMinPosY, CustomCanvas.transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        Cape.GetComponent<Image>().sprite = cape[player.idCape];
        Body.GetComponent<Image>().sprite = body[player.idBody];
        Cloths.GetComponent<Image>().sprite = cloths[player.idCloths];
        Weapon.GetComponent<Image>().sprite = weapon[player.idWeapon];
        Hair.GetComponent<Image>().sprite = hair[player.idHair];
        Face.GetComponent<Image>().sprite = face[player.idFace];
        Hat.GetComponent<Image>().sprite = hat[player.idHat];

        //Debug.Log("Cape: " + player.idCape + " Body: " + player.idBody + "Cloths: " + player.idCloths +
        //    " Weapon: " + player.idWeapon + " Hair: " + player.idHair + " Face: " + player.idFace + " Hat: " + player.idHat);

        #region Comments
        //float _swipeY = 0;
        //swipe.Update(_swipeY);
        //if (_swipeY != 0)
        //{
        //    if (_swipeY > 0)
        //    {
        //    }
        //    else if (_swipeY < 0)
        //    {
        //    }
        //}

        //float _posY = subCanvas.transform.position.y;
        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        //{
        //    Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
        //    subCanvas.transform.Translate(0, touchDeltaPosition.y * speed, 0);
        //}
        //    Vector2 touchScrollPosition = Input.mouseScrollDelta;
        //    subCanvas.transform.Translate(0, touchScrollPosition.y * speed*10, 0);
        //if (subCanvas.transform.position.y < CustomCanvas.transform.position.y + subMinPosY)
        //{
        //    subCanvas.transform.position = new Vector3(CustomCanvas.transform.position.x, CustomCanvas.transform.position.y + subMinPosY, CustomCanvas.transform.position.z);
        //}
        //if (subCanvas.transform.position.y > CustomCanvas.transform.position.y + subMaxPosY)
        //{
        //    subCanvas.transform.position = new Vector3(CustomCanvas.transform.position.x, CustomCanvas.transform.position.y + subMaxPosY, CustomCanvas.transform.position.z);
        //}

        #endregion

    }

    #region Buttons


    public void BtnHat()
    {
        player.idHat = player.idHat + 1 >= hat.Length ? 0 : player.idHat + 1;
    }

    public void BtnHair()
    {
        player.idHair = player.idHair + 1 >= hair.Length ? 0 : player.idHair + 1;
    }

    public void BtnFace()
    {
        player.idFace = player.idFace + 1 >= face.Length ? 0 : player.idFace + 1;
    }

    public void BtnBody()
    {
        player.idBody = player.idBody + 1 >= body.Length ? 0 : player.idBody + 1;
    }

    public void BtnCloth()
    {
        player.idCloths = player.idCloths + 1 >= cloths.Length ? 0 : player.idCloths + 1;
    }

    public void BtnWeapon()
    {
        player.idWeapon = player.idWeapon + 1 >= weapon.Length ? 0 : player.idWeapon + 1;
    }

    public void BtnCape()
    {
        player.idCape = player.idCape + 1 >= cape.Length ? 0 : player.idCape + 1;
    }

    public void BtnSaveCharacter()
    {
        player.SaveOutfit();
    }

    public void BtnReturn()
    {
        SceneManager.LoadScene("sceneMenu");
    }
    #endregion

}

