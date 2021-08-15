using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatapultController : MonoBehaviour
{
    public Canvas catapultArrowCanvas;
    public GameObject spawnable;

    public Soldier.Weapon currentSoldier = Soldier.Weapon.Sword;

    private void Start()
    {
        catapultArrowCanvas= GetComponent<Canvas>();
    }
    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            catapultArrowCanvas.transform.position = new Vector3(catapultArrowCanvas.transform.position.x, catapultArrowCanvas.transform.position.y, hit.point.z);
            //Debug.LogError("hit:: "+hit.collider.gameObject.name);
        }
    }

    public float catapultSpring = 0f;
    public float catSpringLoading = 60f;

    public Vector3 spawnPositionOffset = new Vector3();

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            catapultSpring += Time.deltaTime * catSpringLoading;
            catapultSpring = Mathf.Clamp(catapultSpring, 0f, 100f);
        }else
        {
            if(catapultSpring > 5)
            {
                Debug.Log("Launch :: " + catapultSpring);
                //spawn
                GameObject go= Instantiate(spawnable, transform.position + spawnPositionOffset, Quaternion.identity);
                Flight f = go.GetComponent<Flight>();
                f.isFlying = true;
                f.Initialize(catapultSpring);
                Soldier s = go.GetComponent<Soldier>();
                s.side = Soldier.Side.Player;
                s.sightDistance = 50f;
                s.randomiseWeapon = false;
                s.weapon = currentSoldier;
                PlayerManager.Instance.removeSoldier(currentSoldier);
                MonoBehaviour.FindObjectsOfType<SelectUi>()[0].UpdateUI();
            }
            catapultSpring = 0;
        }
        catapultArrowCanvas.GetComponentInChildren<Slider>().value = catapultSpring;
    }
}
