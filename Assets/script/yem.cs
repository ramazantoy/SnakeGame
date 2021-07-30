using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class yem : MonoBehaviour
{
    public TMPro.TextMeshProUGUI skor_txt;
    int skor = 0;
    hareket kuyruk;
    private void Start()
    {
        kuyruk = GameObject.Find("bas").GetComponent<hareket>();
    }

    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "bas")
        {
            skor += 10;
            skor_txt.text = "Skor : " + skor;
            hareket.hiz = hareket.hiz + 4f;
            yerDegis();
            kuyruk.kuyrukArttir();
        }
        else if (other.gameObject.tag == "kuyruk")
        {
            yerDegis();
        }


    }
    private void Update()
    {
        transform.Rotate(0, 250 * Time.deltaTime, 0);
    }

    [System.Obsolete]
    void yerDegis()
    {
      
        float z_ekseni = Random.RandomRange(-17f, -1.3f);
        float x_ekseni = Random.RandomRange(-8f, 10f);
        transform.position = new Vector3(x_ekseni, transform.position.y, z_ekseni);
    }

}
