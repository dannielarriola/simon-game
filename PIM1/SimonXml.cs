using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace PIM1
{
    // clase que se encarga de manejar el archivo xml que guarda el juego
    class SimonXml
    {
        XmlDocument Doc;
        public List<Secuencia> secuencias = new List<Secuencia>();
        // Obtengo o genero el xml del juego
        public SimonXml(string file)
        {
            Doc = new XmlDocument();
            // cargo el xml o lo creo
            if (File.Exists(file))
            {
                Doc.Load(file);
            } else
            {
                XmlTextWriter archivoxml = new XmlTextWriter(file, System.Text.Encoding.UTF8);
                archivoxml.Formatting = Formatting.Indented;
                archivoxml.Indentation = 2;
                archivoxml.WriteStartDocument(true);
                archivoxml.WriteStartElement("Simon");
                
                archivoxml.WriteEndElement();
                archivoxml.WriteEndDocument();
                archivoxml.Close();
                Doc.Load(file);
            }
        }

        // Convierto el xml en una lista de objetos secuencia
        public void ConvertXmlToSecuencia()
        {
            XmlNodeList secs = Doc.SelectNodes("descendant::secuencia");
            int juego = 1;
            foreach (XmlNode sec in secs)
            {
                Secuencia secuencia = new Secuencia(juego);
                XmlNodeList objetos = sec.SelectNodes("descendant::objeto");
                int idObjeto = 1;
                foreach (XmlNode obj in objetos)
                {
                    int id = idObjeto;
                    int valor = Convert.ToInt32(obj.SelectSingleNode("valor").InnerText);
                    int anterior = Convert.ToInt32(obj.SelectSingleNode("anterior").InnerText);
                    int posterior = Convert.ToInt32(obj.SelectSingleNode("posterior").InnerText);

                    Objeto objeto = new Objeto(id, anterior, valor, posterior);
                    secuencia.AddObjeto(objeto);

                    idObjeto++;
                }
                secuencias.Add(secuencia);
                juego++;
            }
        }

        // convierto el objeto y lo guardo en el xml
        public void saveToFile(string file, List<Secuencia> secs)
        {
            XmlTextWriter archivoxml = new XmlTextWriter(file, System.Text.Encoding.UTF8);
            archivoxml.Formatting = Formatting.Indented;
            archivoxml.Indentation = 2;
            archivoxml.WriteStartDocument(true);
            archivoxml.WriteStartElement("Simon");
            foreach (Secuencia secuencia in secs)
            {
                archivoxml.WriteStartElement("secuencia", "");
                archivoxml.WriteElementString("juego", secuencia.Juego.ToString());
                foreach (Objeto objeto in secuencia.GetObjetos())
                {
                    archivoxml.WriteStartElement("objeto", "");
                    archivoxml.WriteElementString("id", objeto.Id.ToString());
                    archivoxml.WriteElementString("valor", objeto.Valor.ToString());
                    archivoxml.WriteElementString("anterior", objeto.Anterior.ToString());
                    archivoxml.WriteElementString("posterior", objeto.Posterior.ToString());
                    archivoxml.WriteEndElement();
                }
                archivoxml.WriteEndElement();
            }
            archivoxml.WriteEndElement();
            archivoxml.WriteEndDocument();
            archivoxml.Close();
        }
    }
}
