using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hareket : MonoBehaviour
{
    public GameObject kuyruk;
    List<GameObject> kuyruklar;
    Vector3 eski_kordinat;
    GameObject eski_kuyruk;
   public static float hiz = 25f;
    void Start()
    {
        kuyruklar = new List<GameObject>();
     for(int i = 0; i < 5; i++)
        {
            GameObject yeni_kuyruk = Instantiate(kuyruk, transform.position, Quaternion.identity);
            kuyruklar.Add(yeni_kuyruk);
        }
        InvokeRepeating("hareketEt", 0.0f,0.1f);
    }

    // Update is called once per frame
  void hareketEt()
    {
        eski_kordinat = transform.position;
        transform.Translate(0, 0, hiz * Time.deltaTime);
        kuyrukTakip();
    }
    void kuyrukTakip()
    {
        kuyruklar[0].transform.position = eski_kordinat;
        eski_kuyruk = kuyruklar[0];
        kuyruklar.RemoveAt(0);
        kuyruklar.Add(eski_kuyruk);
    }
    public void dondur(float aci)
    {
        transform.Rotate(0, aci, 0);
    }
    public void kuyrukArttir()
    {
        GameObject yeni_kuyruk = Instantiate(kuyruk, transform.position, Quaternion.identity);
        kuyruklar.Add(yeni_kuyruk);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "duvar")
        {
            SceneManager.LoadScene("SampleScene");
        }
        if (other.gameObject.tag == "kuyruk")
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

}
