using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Web;
public class wat1 : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMesh texto;
    void Start()
    {
         Console.WriteLine("Haciendo una petición al servio de clientes....");

                //se define la url del método de la api.
                string url = "https://reinventate-mx.herokuapp.com/";
                string token = "tu token de acceso";

                //Se configura la petición.
                HttpWebRequest peticion;
                peticion = WebRequest.Create(url) as HttpWebRequest;
                peticion.ContentType = "application/json; charset=utf-8";
                peticion.Method = "GET";

                // Respuesta
                try
                {
                    HttpWebResponse respuesta = peticion.GetResponse() as HttpWebResponse;
                    //Si la peticion fue correcta
                    if ((int)respuesta.StatusCode == 200)
                    {
                        var reader = new StreamReader(respuesta.GetResponseStream());
                        string s = reader.ReadToEnd();
                        var arr = JsonConvert.DeserializeObject(s);
                        
                        string n = arr.ToString();
                        texto.text=n;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

