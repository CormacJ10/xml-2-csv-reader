using System;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;

namespace xml2csv
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    using (FileStream fs = private new FileStream("testfile.xml", FileMode.Open)){
        XmlSerializer serializer = new XmlSerializer(typeof(Sequence[]));
        var data = (Sequence[])serializer.Deserialize(fs);
        List<string> list = new List<string>();
        foreach (var item in data)
        {
            List<string> ss = new List<string>();
            foreach (var point in item.SourcePath) ss.Add(point.X + "," + point.Y);
            list.Add(string.Join(",", ss));
        }
        File.WriteAllLines("export.csv", list);
    }

    public class Sequence
    {
        public Point[] SourcePath { get; set; }
    }

}


