using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace ModernLangToolsApp
{
    //delegát az üzenetekhez
    public delegate void Notification(string message);
    class Program
    {
        static void Main(string[] args)
        {
            
            F2();
            F3();
            F4();
            Console.ReadKey();
        }

        [Description("Feladat2")]
        static public void F2() 
        {
            Jedi jedi1 = new Jedi();
            jedi1.Name = "skywalker";
            jedi1.MidiChlorianCount = 20000;

            //szerializálás xml-be
            XmlSerializer serializer = new XmlSerializer(typeof(Jedi));
            FileStream stream = new FileStream("jedi.txt", FileMode.Create);
            serializer.Serialize(stream, jedi1);
            stream.Close();

            //beolvasás xml-ből
            XmlSerializer ser = new XmlSerializer(typeof(Jedi));
            FileStream fs = new FileStream("jedi.txt", FileMode.Open);
            Jedi clone = (Jedi)ser.Deserialize(fs);
            fs.Close();
        }

        [Description("Feladat3")]
        static public void F3() 
        {
            JediCouncil Tanács = new JediCouncil();

            Jedi jedi1 = new Jedi();
            jedi1.Name = "Égjáró Anakin";
            jedi1.MidiChlorianCount = 20000;

            Jedi jedi2 = new Jedi();
            jedi1.Name = "Pataki Attila";
            jedi1.MidiChlorianCount = 20;

            //event test, enélkül nem írt ki semmit
            Tanács.CouncilChanged += MessageReceived;

            //tanácshoz adás
            Tanács.Add(jedi1);
            Tanács.Add(jedi2);
            Tanács.Remove();
            Tanács.Remove();
        }


        [Description("Feladat4")]
        static public void F4()
        {
            JediCouncil Tanács = new JediCouncil();

            Jedi jedi1 = new Jedi();
            jedi1.Name = "Égjáró Anakin";
            jedi1.MidiChlorianCount = 20000;

            Jedi jedi2 = new Jedi();
            jedi2.Name = "Pataki Attila";
            jedi2.MidiChlorianCount = 20;

            Jedi jedi3 = new Jedi();
            jedi3.Name = "Harry Potter";
            jedi3.MidiChlorianCount = 250;

            Tanács.CouncilChanged += MessageReceived;

            Tanács.Add(jedi1);
            Tanács.Add(jedi2);
            Tanács.Add(jedi3);

            foreach (var item in Tanács.GetBeginners())
            {
                Console.WriteLine(item.Name);
            }

            Tanács.Remove();
            Tanács.Remove();
            Tanács.Remove();
            
        }
        
        static void MessageReceived(string message) 
        {
            Console.WriteLine(message); 
        }

    }


}
