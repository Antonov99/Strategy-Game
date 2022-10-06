using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// класс описывает все взаимодействия с внутриигровой валютой
// включая постройку зданий и найм юнитов

public class money : MonoBehaviour
{
    AudioSource aud;
    public AudioClip bolshe;
    public AudioClip zdanie;
    public AudioClip nehvataet;

    public GameObject casern;
    public GameObject mine;
    public GameObject plavilnya;
    public GameObject tent;
    public GameObject tent1;
    public GameObject tent2;
    public GameObject tent3;
    public GameObject tent4;
    public GameObject tent5;
    public GameObject kuznya;
    public Button warriorsButton;

    public int Mcost;
    public int Ccost;
    public int Pcost;
    public int Acost;

    public int Zhiteli;
    public int warriorsNow;

    public Text Tmoney;
    public Text Tcasern;
    public Text Tpeople;
    public Text Tarmor;
    public Text Tgold;
    public Text Tzhiteli;

    public WarController V1;
    public Vector3 Offset;


    public float cash;
    public float prirost;
    public float time;
    private float timeStart;

    public Button bAttack;

    void Start()
    {
        aud = GetComponent<AudioSource>();
        Tmoney.text = Mcost + "$";
        Tcasern.text = Ccost + "$";
        Tpeople.text = Pcost + "$";
        Tarmor.text = Acost + "$";
        if (PlayerPrefs.HasKey("cash"))
        {
            cash = PlayerPrefs.GetFloat("cash");
        }
        timeStart = time;
    }

    void Update()
    {
        Tgold.text = "Золото: " + cash + "$";
        Tzhiteli.text = "Воины: " + warriorsNow + "/" + Zhiteli;

        time -= Time.deltaTime;

        if (time <= 0)
        {
            cash += prirost;
            time = timeStart;
            PlayerPrefs.SetFloat("cash", cash);
        }
    }

    public void mon()
    {
        if (cash >= Mcost)
        {
            if (!mine.activeSelf)
            {
                mine.SetActive(true);
                cash -= Mcost;
                Mcost += 10;
                Tmoney.text = Mcost + "$";
                prirost += 1;
                aud.PlayOneShot(zdanie);
            }
            else if (!plavilnya.activeSelf)
            {
                plavilnya.SetActive(true);
                cash -= Mcost;
                Tmoney.text = "Sold";
                prirost += 1;
                aud.PlayOneShot(zdanie);
                Mcost = -1;
            }
        }
        else
        {
            aud.Stop();
            aud.PlayOneShot(bolshe);
        }
    }

    public void cas()
    {
        if (cash >= Ccost)
        {
            if (!casern.activeSelf)
            {
                casern.SetActive(true);
                cash -= Ccost;
                Tcasern.text = "Sold";
                warriorsButton.interactable = true;
                aud.PlayOneShot(zdanie);
                Ccost = -1;
            }
        }
        else
        {
            aud.Stop();
            aud.PlayOneShot(bolshe);
        }
    }
    public void people()
    {
        if (cash >= Pcost)
        {
            if (!tent.activeSelf)
            {
                tent.SetActive(true);
                cash -= Pcost;
                Pcost += 5;
                Tpeople.text = Pcost + "$";
                aud.PlayOneShot(zdanie);
                Zhiteli += 2;
            }
            else if (!tent1.activeSelf)
            {
                tent1.SetActive(true);
                cash -= Pcost;
                Pcost += 5;
                Tpeople.text = Pcost + "$";
                aud.PlayOneShot(zdanie);
                Zhiteli += 2;
            }
            else if (!tent2.activeSelf)
            {
                tent2.SetActive(true);
                cash -= Pcost;
                Pcost += 10;
                Tpeople.text = Pcost + "$";
                aud.PlayOneShot(zdanie);
                Zhiteli += 2;
            }
            else if (!tent3.activeSelf)
            {
                tent3.SetActive(true);
                cash -= Pcost;
                Pcost += 10;
                Tpeople.text = Pcost + "$";
                aud.PlayOneShot(zdanie);
                Zhiteli += 4;
            }
            else if (!tent4.activeSelf)
            {
                tent4.SetActive(true);
                cash -= Pcost;
                Pcost += 10;
                Tpeople.text = Pcost + "$";
                aud.PlayOneShot(zdanie);
                Zhiteli += 4;
            }
            else if (!tent5.activeSelf)
            {
                tent5.SetActive(true);
                cash -= Pcost;
                Tpeople.text = "Sold";
                aud.PlayOneShot(zdanie);
                Zhiteli += 4;
                Pcost = -1;
            }
        }
        else
        {
            aud.Stop();
            aud.PlayOneShot(bolshe);
        }
    }

    public void kuz()
    {
        if (cash >= Acost)
        {
            if (!kuznya.activeSelf)
            {
                kuznya.SetActive(true);
                cash -= Acost;
                Tarmor.text = "Sold";
                aud.PlayOneShot(zdanie);
                Acost = -1;
            }
        }
        else
        {
            aud.Stop();
            aud.PlayOneShot(bolshe);
        }
    }

    public void spawn1()
    {
        if (Zhiteli > 0 && warriorsNow < Zhiteli)
        {
            if (cash >= 5)
            {
                var Warrior=Instantiate(V1, Offset, transform.rotation);
                bAttack.onClick.AddListener(Warrior.Attack);
                cash -= 5;
                warriorsNow++;
            }
            else
            {
                aud.Stop();
                aud.PlayOneShot(bolshe);
            }
        }
        else
        {
            aud.Stop();
            aud.PlayOneShot(nehvataet);
        }
    }
}
