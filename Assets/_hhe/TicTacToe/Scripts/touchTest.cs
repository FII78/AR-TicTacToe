using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class touchTest : MonoBehaviour
{
    [SerializeField]
    private TMP_Text TextInfos;


    PhotonView view;

    Ray ray;
    RaycastHit hit;
    // Use this for initialization
    public GameObject ex;
    public GameObject oh;
    private float count = 0;


    #region PlayersTurnNr Logick
    private int MAXPLAYERS = 2;
    private int PlayersTurnNr = 1;
    #endregion

    void Start ()
    {
        view = GetComponent<PhotonView>();

        //TextInfos.text = "Start";
    }

    void Update()
    {
        //TextInfos.text = "LocalPlayer ActorNumber: " + 
        //    PhotonNetwork.LocalPlayer.ActorNumber.ToString() +
        //    " PlayersTurnNr.: " + PlayersTurnNr;

        #region PlayersTurnNr Logick

        //if (PhotonNetwork.LocalPlayer.ActorNumber != PlayersTurnNr)  //Error OwnerAnchor always = 0
        //{
        //    TextInfos.text = "Not your turn: " +
        //            PhotonNetwork.LocalPlayer.ActorNumber.ToString() +
        //            " This players turn: " + PlayersTurnNr;
        //    return;
        //}
        #endregion


        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            Debug.DrawRay(ray.origin, ray.direction * 20, Color.red);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {

                #region PlayersTurnNr Logick
                if (PlayersTurnNr >= MAXPLAYERS)
                {
                    PlayersTurnNr = 1;
                }
                else
                {
                    PlayersTurnNr++;
                }
                #endregion
                //Debug.Log("Count" + count);
                view.RPC("exoh_prefab", RpcTarget.All, hit.transform.position, Quaternion.identity, PlayersTurnNr);

            }
        }
	}

    [PunRPC]
    void exoh_prefab(Vector3 Pos, Quaternion quaat, int playersTurnNr)
    {
        PlayersTurnNr = playersTurnNr;
        if (count % 2 == 0)
        {
            GameObject Go = Instantiate(oh, Pos, quaat) as GameObject;
        }
        else if (count % 1 == 0)
        {
            GameObject Go = Instantiate(ex, Pos, quaat) as GameObject;
        }
        count++;
    }
}
