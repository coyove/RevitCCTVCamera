using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CameraPlugin
{
    //class CameraProfile
    //{
    //    public string name;
    //    public double sensorWidth;
    //    public double sensorHeight;
    //    public double focalLength;
    //}

    class CameraConfig
    {
        public class SensorType
        {
            public string name;
            public double width;
            public double height;
        }

        public class LensType
        {
            public string name;
            public double length;
        }

        public class ResolutionType
        {
            public string name;
            public int width;
            public int height;
        }

        public static string ReadSetting(string key)
        {

            XmlDocument doc = new XmlDocument();
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/settings.config";

            if (File.Exists(path))
            {
                doc.Load(path);
            }

            XmlNode node = doc.DocumentElement.SelectSingleNode("/configuration/" + key);
            return node?.Attributes["value"].Value;
        }

        public static List<SensorType> ReadSensors()
        {

            XmlDocument doc = new XmlDocument();
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/settings.config";

            if (File.Exists(path))
            {
                doc.Load(path);
            }

            List<SensorType> ret = new List<SensorType>();

            XmlNode node = doc.DocumentElement.SelectSingleNode("/configuration");
            foreach(XmlNode n in node.ChildNodes)
            {
                if(n.Name == "sensor")
                {
                    var tmp = new SensorType();
                    tmp.name = n.Attributes["name"].Value;
                    tmp.width = double.Parse(n.Attributes["width"].Value);
                    tmp.height = double.Parse(n.Attributes["height"].Value);

                    ret.Add(tmp);
                }
            }

            return ret;
            
        }

        public static List<LensType> ReadLenses()
        {

            XmlDocument doc = new XmlDocument();
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/settings.config";

            if (File.Exists(path))
            {
                doc.Load(path);
            }

            List<LensType> ret = new List<LensType>();

            XmlNode node = doc.DocumentElement.SelectSingleNode("/configuration");
            foreach (XmlNode n in node.ChildNodes)
            {
                if (n.Name == "lens")
                {
                    var tmp = new LensType();
                    tmp.name = n.Attributes["name"].Value;
                    tmp.length = double.Parse(n.Attributes["length"].Value);

                    ret.Add(tmp);
                }
            }

            return ret;

        }

        public static List<ResolutionType> ReadResolutions()
        {

            XmlDocument doc = new XmlDocument();
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/settings.config";

            if (File.Exists(path))
            {
                doc.Load(path);
            }

            List<ResolutionType> ret = new List<ResolutionType>();

            XmlNode node = doc.DocumentElement.SelectSingleNode("/configuration");
            foreach (XmlNode n in node.ChildNodes)
            {
                if (n.Name == "resolution")
                {
                    var tmp = new ResolutionType();
                    tmp.name = n.Attributes["name"].Value;
                    tmp.width = int.Parse(n.Attributes["width"].Value);
                    tmp.height = int.Parse(n.Attributes["height"].Value);

                    ret.Add(tmp);
                }
            }

            return ret;

        }

        public static bool SaveSetting(string key, string value)
        {

            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/settings.config";

            if (File.Exists(path))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                XmlNode node = doc.DocumentElement.SelectSingleNode("/configuration/" + key);
                if(node != null)
                {
                    node.Attributes["value"].Value = value;
                    doc.Save(path);
                    return true;
                }
            }

            return false;
        }
    }
}