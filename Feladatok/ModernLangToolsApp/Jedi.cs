using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace ModernLangToolsApp
{
    [XmlRoot("Jedi") ]
    public class Jedi
    {
        
        private string name;
        private int midiChlorianCount;
        //az XmlAttribute neve jelenik meg a kiírásokban
        [XmlAttribute("Nev")]
        public string Name { get => name; set => name = value; }

        [XmlAttribute("MidiChlorianSzam")]
        public int MidiChlorianCount
        {
            get { return midiChlorianCount; }
            set
            {
                if (value  <= 10) throw new ArgumentException("You are not a true jedi!");
                midiChlorianCount = value;
            }
        }
    }
}
